using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    internal class RemoveItemsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemStackComponent, RemoveItemsEvent> _filter;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var stackComponent = ref _filter.Get1(i);
                ref var removeItemsEvent = ref _filter.Get2(i);
                ref var entity = ref _filter.GetEntity(i);

                foreach(var item in removeItemsEvent.Items) Object.Destroy(item.Transform.gameObject);

                stackComponent.Stack.Remove(removeItemsEvent.Items);

                Debug.Log("remove");
            }
        }
    }
}