namespace Project.Gameplay
{
    internal struct PushItemEvent
    {
        public IItem Item;

        internal PushItemEvent(IItem item) => Item = item;
    }
}