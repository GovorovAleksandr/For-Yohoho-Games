using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay.UI
{
    internal class StackCountViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StackCountViewComponent> _viewFilter = null;
        private readonly EcsFilter<ItemStackComponent> _pushStackFilter = null;

        public void Run()
        {
            foreach(var i in _pushStackFilter)
            {
                ref var stackComponent = ref _pushStackFilter.Get1(i);

                foreach(var j in _viewFilter)
                {
                    ref var viewComponent = ref _viewFilter.Get1(j);

                    ref var viewEntity = ref viewComponent.StackTag.EntityReference.Entity;
                    ref var targetStack = ref viewEntity.Get<ItemStackComponent>().Stack;

                    if (stackComponent.Stack != targetStack) continue;

                    var text = $"{viewComponent.Name}: {stackComponent.Stack.Count}";
                    viewComponent.TextComponent.text = text;
                }
            }
        }
    }
}