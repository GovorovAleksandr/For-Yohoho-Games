using UnityEngine;

namespace Project.Gameplay
{
    internal class ItemConfig : MonoBehaviour
    {
        public ItemTypes Type => _type;
        [SerializeField] private ItemTypes _type;
    }
}