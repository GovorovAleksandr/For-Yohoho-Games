using Voody.UniLeo;

namespace Project.Gameplay
{
    internal class ItemStackComponentProvider : MonoProvider<ItemStackComponent>
    {
        private void Awake() => value.Parent = transform;
    }
}