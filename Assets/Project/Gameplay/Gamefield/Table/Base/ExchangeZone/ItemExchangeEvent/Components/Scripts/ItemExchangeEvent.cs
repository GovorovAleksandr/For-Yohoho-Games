using Leopotam.Ecs;

namespace Project.Gameplay
{
    internal struct ItemExchangeEvent
    {
        public EcsEntity From;
        public EcsEntity To;
    }
}