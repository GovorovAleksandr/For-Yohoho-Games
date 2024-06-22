using System;

namespace Project.Gameplay
{
    [Serializable]
    internal struct ItemFactoryComponent
    {
        public ItemConfig Prefab;
        public float SpawnInterval;
    }
}