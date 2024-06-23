using System;
using UnityEngine;

namespace Project.Reusable
{
    [Serializable]
    internal struct Sellable
    {
        public int Cost;
        [HideInInspector] public GameObject GameObject;
    }
}