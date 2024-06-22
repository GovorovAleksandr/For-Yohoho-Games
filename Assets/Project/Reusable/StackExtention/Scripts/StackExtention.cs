using Project.Gameplay;
using System.Collections.Generic;
using System.Linq;

namespace Project.Reusable
{
    internal static class StackExtention
    {
        internal static void Remove(this Stack<ItemComponent> stack, ItemComponent item)
        {
            Stack<ItemComponent> temp = new();

            foreach (var i in stack)
            {
                if (i.Transform == item.Transform) continue;
                temp.Push(i);
            }
        }

        internal static void Remove(this Stack<ItemComponent> stack, IEnumerable<ItemComponent> items)
        {
            Stack<ItemComponent> temp = new();

            foreach (var i in stack)
            {
                if (items.Contains(i)) continue;
                temp.Push(i);
            }
        }
    }
}