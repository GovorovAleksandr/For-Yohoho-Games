using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class ItemExchangeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemExchangeEvent> _stackFilter = null;

        public void Run()
        {
            foreach(var i in _stackFilter)
            {
                ref var exchange = ref _stackFilter.Get1(i);

                ref var from = ref exchange.From;
                ref var to = ref exchange.To;

                var item = from.Get<ItemStackComponent>().Stack.Pop();
                to.Get<PushItemEvent>().Item = item;
            }
        }
    }
}