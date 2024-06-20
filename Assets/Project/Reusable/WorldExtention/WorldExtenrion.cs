using Leopotam.Ecs;

namespace Project.Reusable
{
    public static class WorldExtenrion
    {
        public static void SendMessage<T>(this EcsWorld world, T message) where T : struct
        {
            world.NewEntity().Get<T>() = message;
        }
    }
}