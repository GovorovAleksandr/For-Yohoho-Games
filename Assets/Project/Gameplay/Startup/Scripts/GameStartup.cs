using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;
using Voody.UniLeo;

namespace Project.Gameplay
{
    internal class GameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new();
            _systems = new(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private void AddInjections()
        {

        }

        private void AddSystems()
        {
            _systems.
                Add(new EntityInitializeSystem()).
                Add(new PlayerInputSystem()).
                Add(new MovementSystem()).
                Add(new ItemStackSystem()).
                Add(new ItemExchangeSystem()).
                Add(new FactoryTimerBlockSystem()).
                Add(new ItemFactorySystem()).
                Add(new PushItemSystem());
        }

        private void AddOneFrames()
        {
            _systems.
                OneFrame<InitializeEntityRequest>().
                OneFrame<ItemExchangeEvent>().
                OneFrame<PushItemEvent>();
        }

        private void Update() => _systems.Run();

        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}