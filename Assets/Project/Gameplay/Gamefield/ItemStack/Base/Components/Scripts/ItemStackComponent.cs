using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
    [Serializable]
    internal struct ItemStackComponent
    {
        public int MaxItemCount;
        public Transform ItemsParent;
        [HideInInspector] public Stack<ItemComponent> Stack;
    }
}