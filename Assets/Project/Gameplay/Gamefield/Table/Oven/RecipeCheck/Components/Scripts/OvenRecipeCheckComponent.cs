using Project.Reusable;
using System;

namespace Project.Gameplay
{
    [Serializable]
    internal struct OvenRecipeCheckComponent
    {
        public EntityReference ResultEntityReference;

        public int BunTarget;
        public int CutletTarget;
        public int SauseTarget;
        public int VegetablesTarget;
    }
}