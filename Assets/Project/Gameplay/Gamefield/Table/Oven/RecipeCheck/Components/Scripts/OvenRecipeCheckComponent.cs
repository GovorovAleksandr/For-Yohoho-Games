using System;
using UnityEngine;

namespace Project.Gameplay
{
    [Serializable]
    internal struct OvenRecipeCheckComponent
    {
        public ItemConfig ResultItemPrefab;

        public int BunTarget;
        public int CutletTarget;
        public int SauseTarget;
        public int VegetablesTarget;
    }
}