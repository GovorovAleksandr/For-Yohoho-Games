using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    [RequireComponent(typeof(EntityReference))]
    internal class StackTag : MonoBehaviour
    {
        public EntityReference EntityReference => GetComponent<EntityReference>();
    }
}