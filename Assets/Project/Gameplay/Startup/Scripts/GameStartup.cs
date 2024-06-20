using Leopotam.Ecs;
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
            AddSystems();
            AddOneFrames();

            _systems.Init();
        }

        private void AddInjections()
        {

        }

        private void AddSystems()
        {
            _systems.
                Add(new PlayerInputSystem()).
                Add(new MovementSystem()).
                Add(new ItemFactorySystem());
        }

        private void AddOneFrames()
        {
            _systems.
                OneFrame<ItemExchangeEvent>();
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