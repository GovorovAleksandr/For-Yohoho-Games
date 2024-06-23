using System;

namespace Project.Gameplay
{
    [Serializable]
    internal struct ItemFactoryComponent
    {
        public ItemType Prefab;
        public float SpawnInterval;
    }
}