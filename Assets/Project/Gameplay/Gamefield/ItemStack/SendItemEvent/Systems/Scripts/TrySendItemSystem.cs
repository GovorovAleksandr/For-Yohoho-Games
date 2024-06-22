using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class TrySendItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemStackComponent, TrySendItemEvent> _stackFilter;

        public void Run()
        {
            foreach(var i in _stackFilter)
            {
                ref var stackComponent = ref _stackFilter.Get1(i);
                ref var sendItem = ref _stackFilter.Get2(i);
                ref var entity = ref _stackFilter.GetEntity(i);

                ref var recipient = ref sendItem.Recipient;

                if (!recipient.Has<ItemStackComponent>()) continue;
                if (recipient.Has<StackFull>()) continue;

                if(stackComponent.Stack.Count > 0)
                {
                    var item = stackComponent.Stack.Pop();
                    recipient.Get<PushItemEvent>().ItemComponent = item;
                }

                entity.Del<TrySendItemEvent>();
            }
        }
    }
}