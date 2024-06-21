using Leopotam.Ecs;

namespace Project.Gameplay
{
    internal class ItemStackSystem : IEcsInitSystem
    {
        private readonly EcsFilter<ItemStackComponent> _filter = null;

        public void Init()
        {
            foreach(var i  in _filter)
            {
                ref var component = ref _filter.Get1(i);
                component.Stack = new();
            }
        }
    }
}