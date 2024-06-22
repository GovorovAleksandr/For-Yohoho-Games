using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;

namespace Project.Gameplay
{
    internal class StackFullSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemStackComponent, StackFull> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var stackComponent = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                if (stackComponent.Stack.Count < stackComponent.MaxItemCount) entity.Del<StackFull>();
            }
        }
    }
}