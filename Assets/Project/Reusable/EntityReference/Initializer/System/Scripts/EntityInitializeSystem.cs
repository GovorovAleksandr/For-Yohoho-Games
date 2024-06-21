using Leopotam.Ecs;
using UnityEngine;

namespace Project.Reusable
{
    public class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var request = ref _filter.Get1(i);
                request.Reference.Entity = entity;
                Debug.Log(entity.IsAlive());
                Debug.Log("gsfdfd");
            }
        }
    }
}