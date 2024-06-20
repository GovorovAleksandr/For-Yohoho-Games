using Leopotam.Ecs;

namespace Project.Gameplay
{
    internal class ItemStackSystem : IEcsRunSystem
    {
        private EcsFilter<ItemExchangeEvent> _stackFilter = null;
        private EcsWorld _world = null;

        public void Run()
        {
            foreach(var i in _stackFilter)
            {
                var exchange = _stackFilter.Get1(i);

                var from = exchange.From;
                var to = exchange.To;

                var item = from.Stack.Pop();
                to.Stack.Push(item);
            }
        }
    }
}