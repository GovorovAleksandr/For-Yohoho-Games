using Leopotam.Ecs;

namespace Project.Gameplay
{
    public class SuccessfullyClearSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SuccessfullyClear> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                entity.Del<SuccessfullyClear>();
            }
        }
    }
}