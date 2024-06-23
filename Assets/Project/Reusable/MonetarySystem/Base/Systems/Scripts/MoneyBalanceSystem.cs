using Leopotam.Ecs;

namespace Project.Reusable
{
    public class MoneyBalanceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoneyBalanceComponent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {

            }
        }
    }
}