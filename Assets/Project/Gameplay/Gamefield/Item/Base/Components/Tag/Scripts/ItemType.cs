using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    [RequireComponent(typeof(EntityReference))]
    internal class ItemType : MonoBehaviour
    {
        [SerializeField] ItemTypes _type;
        public ItemTypes Type => _type;
        public Transform Transform => transform;
        public EntityReference EntityReference => GetComponent<EntityReference>();
    }
}