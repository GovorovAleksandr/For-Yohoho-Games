using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class TakeZone : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";
        
        [SerializeField] private EntityReference _entityReference;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PLAYER_TAG)) return;

            if(other.TryGetComponent(out EntityReference playerEntityReference))
                TrySend(playerEntityReference.Entity);
        }

        private void TrySend(EcsEntity entity)
        {
            _entityReference.Entity.Get<TrySendItemEvent>().Recipient = entity;
        }
    }
}