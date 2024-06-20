using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class ItemFactorySystem : IEcsRunSystem
    {
        private EcsFilter<ItemFactoryComponent> _factoryFilter = null;

        public void Run()
        {
            foreach(var i in _factoryFilter)
            {
                ref var factory = ref _factoryFilter.Get1(i);
                factory.TimeSinceLastSpawn += Time.deltaTime;

                if(factory.TimeSinceLastSpawn >= factory.SpawnInterval)
                {
                    factory.TimeSinceLastSpawn = 0;

                    var prefab = factory.Prefab;
                    var parent = factory.Parent;
                    var position = factory.SpawnPosition + parent.transform.position;

                    var spawnedObject = Object.Instantiate(prefab, position, Quaternion.identity, parent);
                }
            }
        }
    }
}