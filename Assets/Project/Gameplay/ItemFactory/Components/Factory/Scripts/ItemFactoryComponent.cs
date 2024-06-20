using System;
using UnityEngine;

namespace Project.Gameplay
{
    [Serializable]
    internal struct ItemFactoryComponent
    {
        public GameObject Prefab;
        public Vector3 SpawnPosition;
        public float SpawnInterval;
        [HideInInspector] public Transform Parent;
        [HideInInspector] public float TimeSinceLastSpawn;
    }
}