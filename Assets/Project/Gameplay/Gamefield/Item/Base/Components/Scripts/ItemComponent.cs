using UnityEngine;

namespace Project.Gameplay
{
    internal struct ItemComponent : IItem
    {
        public GameObject GameObject { get; set; }

        public ItemComponent(GameObject gameObject) => GameObject = gameObject;
    }
}