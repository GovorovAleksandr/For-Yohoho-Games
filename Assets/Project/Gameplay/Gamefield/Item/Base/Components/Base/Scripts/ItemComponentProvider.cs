using Project.Reusable;
using UnityEngine;
using Voody.UniLeo;

namespace Project.Gameplay
{
    [RequireComponent(typeof(EntityReference))]
    internal class ItemComponentProvider : MonoProvider<ItemComponent>
    {
        private void Awake()
        {
            value.Transform = transform;
            value.EntityReferece = GetComponent<EntityReference>();
        }
    }
}