using Leopotam.Ecs;

namespace Project.Reusable
{
    public static class WorldExtenrion
    {
        public static void SendMessage<T>(this EcsWorld world, ref T message) where T : struct
        {
            world.NewEntity().Get<T>() = message;
        }
    }
}