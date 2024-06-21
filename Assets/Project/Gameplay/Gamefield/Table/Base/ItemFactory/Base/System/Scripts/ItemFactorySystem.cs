using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class ItemFactorySystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<ItemFactoryComponent>.
            Exclude<FactoryTimerBlockComponent, FactoryFull> _factoryFilter = null;

        public void Run()
        {
            foreach(var i in _factoryFilter)
            {
                ref var factory = ref _factoryFilter.Get1(i);

                var prefab = factory.Prefab;
                var parent = factory.Parent;
                var position = factory.SpawnPosition + parent.transform.position;

                var spawnedObject = Object.Instantiate(prefab, position, Quaternion.identity, parent);
                ItemComponent item = new(spawnedObject);

                ref var entity = ref _factoryFilter.GetEntity(i);
                entity.Get<PushItemEvent>().Item = item;

                factory.CurrentSpawns++;

                if(factory.CurrentSpawns == factory.MaxSpawns) entity.Get<FactoryFull>();

                entity.Get<FactoryTimerBlockComponent>().TimeLeft = factory.SpawnInterval;
            }
        }
    }
}