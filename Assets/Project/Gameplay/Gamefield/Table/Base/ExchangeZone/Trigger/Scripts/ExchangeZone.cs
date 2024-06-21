using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;
using Voody.UniLeo;

namespace Project.Gameplay
{
    [RequireComponent(typeof(EntityReference))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class ExchangeZone : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";
        
        private EntityReference _entityLink;

        private void Awake() => _entityLink = GetComponent<EntityReference>();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PLAYER_TAG)) return;

            if(other.TryGetComponent(out EntityReference playerEntityLink))
            {
                Debug.Log(playerEntityLink.Entity.IsAlive());
                ItemExchangeEvent itemExchange = new()
                {
                    From = _entityLink.Entity,
                    To = playerEntityLink.Entity
                };


                WorldHandler.GetWorld().SendMessage(itemExchange);
            }
        }
    }
}