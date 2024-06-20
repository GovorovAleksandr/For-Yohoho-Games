using Voody.UniLeo;

namespace Project.Gameplay
{
    internal class ItemFactoryComponentProvider : MonoProvider<ItemFactoryComponent>
    {
        private void Awake() => value.Parent = transform;
    }
}