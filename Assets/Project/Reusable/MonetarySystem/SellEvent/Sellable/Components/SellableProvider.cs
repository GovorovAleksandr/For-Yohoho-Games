using Voody.UniLeo;

namespace Project.Reusable
{
    internal class SellableProvider : MonoProvider<Sellable>
    {
        private void Awake() => value.GameObject = gameObject;
    }
}