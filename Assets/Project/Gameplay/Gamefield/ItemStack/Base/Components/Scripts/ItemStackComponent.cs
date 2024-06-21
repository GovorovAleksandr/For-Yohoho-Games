using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
    internal struct ItemStackComponent
    {
        public Stack<IItem> Stack;
        public IItem LastItem;
        public Transform Parent;
    }
}