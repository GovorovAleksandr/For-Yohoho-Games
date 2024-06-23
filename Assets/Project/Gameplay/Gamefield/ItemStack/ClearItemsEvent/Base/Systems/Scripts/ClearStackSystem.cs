using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    public class ClearStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemStackComponent, ClearStackEvent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var stackComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                foreach(var item in stackComponent.Stack)
                    Object.Destroy(item.Transform.gameObject);

                stackComponent.Stack.Clear();

                entity.Get<SuccessfullyClear>();
                entity.Del<ClearStackEvent>();
            }
        }
    }
}