using Project.Reusable;
using System;
using UnityEngine;

namespace Project.Gameplay
{
    [Serializable]
    internal struct OvenCookComponent
    {
        public ItemType ResultItemPrefab;
        public Transform ResultItemParent;
    }
}