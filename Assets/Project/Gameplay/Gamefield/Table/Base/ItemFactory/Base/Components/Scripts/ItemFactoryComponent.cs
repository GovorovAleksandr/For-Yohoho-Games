using System;
using UnityEngine;

namespace Project.Gameplay
{
    [Serializable]
    internal struct ItemFactoryComponent
    {
        public GameObject Prefab;
        public float SpawnInterval;
        public int MaxSpawns;
        public Vector3 SpawnPosition;
        [HideInInspector] public int CurrentSpawns;
        [HideInInspector] public Transform Parent;
    }
}