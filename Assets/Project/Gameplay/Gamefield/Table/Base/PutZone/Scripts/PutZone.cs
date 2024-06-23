using Leopotam.Ecs;
using Project.Reusable;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PutZone : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";

        [SerializeField] private EntityReference _entityReference;
        [SerializeField] private List<ItemTypes> _types;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PLAYER_TAG)) return;

            if (other.TryGetComponent(out EntityReference playerEntityReference))
                TrySend(playerEntityReference.Entity);
        }

        private void TrySend(EcsEntity itemEntity)
        {
            ref var stackComponent = ref itemEntity.Get<ItemStackComponent>();
            if (stackComponent.Stack == null) return;
            if (stackComponent.Stack.Count == 0) return;
            var type = stackComponent.Stack.Peek().Type;

            if (!_types.Contains(type)) return;

            itemEntity.Get<TrySendItemEvent>().Recipient = _entityReference.Entity;
        }
    }
}