using System;
using TMPro;

namespace Project.Gameplay.UI
{
    [Serializable]
    internal struct StackCountViewComponent
    {
        public string Name;
        public TextMeshProUGUI TextComponent;
        public StackTag StackTag;
    }
}