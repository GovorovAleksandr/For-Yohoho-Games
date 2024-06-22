using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    public class OvenCookSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<OvenCookComponent>.
            Exclude<StackFull> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var cookComponent = ref _filter.Get1(i);

                var spawnedObject = Object.Instantiate(cookComponent.ResultItemPrefab);

                ItemComponent item = new()
                {
                    Type = spawnedObject.Type,
                    Transform = spawnedObject.transform
                };

                ref var entity = ref _filter.GetEntity(i);
                
                entity.Get<PushItemEvent>().ItemComponent = item;

                Debug.Log("burger");
            }
        }
    }
}