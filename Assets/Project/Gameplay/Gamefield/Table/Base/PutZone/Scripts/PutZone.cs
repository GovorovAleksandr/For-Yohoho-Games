using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PutZone : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";

        [SerializeField] private EntityReference _entityReference;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PLAYER_TAG)) return;

            if (other.TryGetComponent(out EntityReference playerEntityReference))
                Send(playerEntityReference.Entity);
        }

        private void Send(EcsEntity entity)
        {
            entity.Get<TrySendItemEvent>().Recipient = _entityReference.Entity;
        }
    }
}