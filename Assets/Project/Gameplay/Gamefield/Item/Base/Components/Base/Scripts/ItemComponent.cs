using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    internal struct ItemComponent
    {
        public ItemTypes Type;
        public Transform Transform;
        public EntityReference EntityReferece;
    }
}