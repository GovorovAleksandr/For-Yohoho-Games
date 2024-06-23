using Leopotam.Ecs;
using UnityEngine;

namespace Project.Reusable
{
    internal class SellSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoneyBalanceComponent> _balanceFilter = null;
        private readonly EcsFilter<SellEvent> _sellEventfilter = null;

        public void Run()
        {
            foreach(var i in _sellEventfilter)
            {
                ref var sellEntity = ref _sellEventfilter.GetEntity(i);

                if (!sellEntity.Has<Sellable>()) continue;

                ref var item = ref sellEntity.Get<Sellable>();

                foreach (var j in _balanceFilter)
                {
                    ref var balanceComponent = ref _balanceFilter.Get1(j);
                    balanceComponent.Balance += item.Cost;
                }

                Object.Destroy(item.GameObject);
            }
        }
    }
}