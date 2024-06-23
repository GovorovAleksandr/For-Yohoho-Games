using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class PushItemSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<ItemStackComponent, PushItemEvent>.
            Exclude<StackFull> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var stackComponent = ref _filter.Get1(i);
                ref var pushComponent = ref _filter.Get2(i);
                ref var entity = ref _filter.GetEntity(i);

                ref var item = ref pushComponent.ItemComponent;

                stackComponent.Stack.Push(item);

                var itemTransform = item.Transform;
                itemTransform.parent = stackComponent.ItemsParent;

                var stackCount = Mathf.Max(1, stackComponent.Stack.Count);
                itemTransform.localPosition = Vector3.up * stackCount;

                if (stackComponent.Stack.Count == stackComponent.MaxItemCount) entity.Get<StackFull>();

                entity.Get<SuccessfullyPush>().Item = item;
            }
        }
    }
}