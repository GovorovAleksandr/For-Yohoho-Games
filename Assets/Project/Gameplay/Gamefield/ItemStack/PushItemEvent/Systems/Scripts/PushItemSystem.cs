using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class PushItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PushItemEvent, ItemStackComponent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var itemComponent = ref _filter.Get1(i);
                ref var item = ref itemComponent.Item;
                ref var stackComponent = ref _filter.GetEntity(i).Get<ItemStackComponent>();

                stackComponent.Stack.Push(item);

                ref var lastItem = ref stackComponent.LastItem;
                
                var itemTransform = item.GameObject.transform;
                itemTransform.parent = stackComponent.Parent;

                if (lastItem != null)
                {
                    var lastTransform = lastItem.GameObject.transform;

                    itemTransform.position = lastTransform.position + Vector3.up;
                }

                lastItem = item;
            }
        }
    }
}