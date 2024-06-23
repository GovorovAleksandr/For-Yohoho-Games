using Leopotam.Ecs;
using Project.Reusable;

namespace Project.Gameplay.UI
{
    internal class BalanceViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BalanceViewComponent> _viewFilter = null;
        private readonly EcsFilter<MoneyBalanceComponent> _balanceFilter = null;

        public void Run()
        {
            foreach(var i in _balanceFilter)
            {
                ref var balanceComponent = ref _balanceFilter.Get1(i);
                var balance = balanceComponent.Balance;

                foreach(var j in _viewFilter)
                {
                    ref var viewComponent = ref _viewFilter.Get1(j);

                    var text = $"{viewComponent.Name}: {balance}";
                    viewComponent.TextComponent.text = text;
                }
            }
        }
    }
}