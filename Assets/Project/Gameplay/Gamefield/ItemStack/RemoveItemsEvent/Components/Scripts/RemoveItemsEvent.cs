using System.Collections.Generic;

namespace Project.Gameplay
{
    internal struct RemoveItemsEvent
    {
        public IEnumerable<ItemComponent> Items;
    }
}