using Leopotam.Ecs;
using UnityEngine;

namespace Project.Gameplay
{
    internal class FactoryTimerBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FactoryTimerBlockComponent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                if (entity.Has<StackFull>()) continue;

                ref var timeLeft = ref _filter.Get1(i).TimeLeft;
                timeLeft -= Time.deltaTime;

                if (timeLeft > 0) continue;
                entity.Del<FactoryTimerBlockComponent>();
            }
        }
    }
}