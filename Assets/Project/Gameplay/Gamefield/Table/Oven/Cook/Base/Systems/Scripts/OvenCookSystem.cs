using Leopotam.Ecs;
using Project.Reusable;
using UnityEngine;

namespace Project.Gameplay
{
    public class OvenCookSystem : IEcsRunSystem
    {
        private readonly
            EcsFilter<OvenCookComponent, ItemStackComponent, OvenCookEvent> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var cookComponent = ref _filter.Get1(i);
                ref var stackComponent = ref _filter.Get2(i);

                var spawnedObject = Object.Instantiate(cookComponent.ResultItemPrefab);

                var itemComponent = new ItemComponent()
                {
                    Transform = spawnedObject.Transform,
                    Type = spawnedObject.Type,
                    EntityReferece = spawnedObject.EntityReference
                };

                stackComponent.Stack.Push(itemComponent);

                ref var entity = ref _filter.GetEntity(i);

                var itemTransform = itemComponent.Transform;
                itemTransform.parent = cookComponent.ResultItemParent;

                var stackCount = Mathf.Max(1, stackComponent.Stack.Count);
                itemTransform.localPosition = Vector3.up * stackCount;

                entity.Get<SuccessfullyPush>();
                entity.Del<OvenCookEvent>();
            }
        }
    }
}