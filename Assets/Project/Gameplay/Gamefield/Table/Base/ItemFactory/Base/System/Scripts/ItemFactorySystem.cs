using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    internal class ItemFactorySystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<ItemFactoryComponent>.
            Exclude<FactoryTimerBlockComponent, StackFull> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var factory = ref _filter.Get1(i);

                var prefab = factory.Prefab;

                var spawnedObject = Object.Instantiate(prefab);

                var itemComponent = new ItemComponent()
                {
                    Transform = spawnedObject.Transform,
                    Type = spawnedObject.Type,
                    EntityReferece = spawnedObject.EntityReference
                };

                ref var entity = ref _filter.GetEntity(i);

                entity.Get<PushItemEvent>().ItemComponent = itemComponent;
                entity.Get<FactoryTimerBlockComponent>().TimeLeft = factory.SpawnInterval;
            }
        }
    }
}