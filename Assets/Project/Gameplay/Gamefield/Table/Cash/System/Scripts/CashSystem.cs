using Leopotam.Ecs;
using Project.Reusable;

namespace Project.Gameplay
{
    internal class CashSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CashComponent, ItemStackComponent, PushItemEvent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var stackComponent = ref _filter.Get2(i);

                foreach(var j in stackComponent.Stack)
                {
                    var itemEntity = j.EntityReferece.Entity;
                    if (!itemEntity.Has<Sellable>()) continue;
                    itemEntity.Get<SellEvent>();
                }
            }
        }
    }
}