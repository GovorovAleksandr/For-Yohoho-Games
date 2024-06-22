using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Gameplay
{
    internal class OvenRecipeCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OvenRecipeCheckComponent, ItemStackComponent, SuccessfullyPush> _filter = null;

        public void Run()
        {
            foreach(var i in _filter)
            {
                ref var recipeCheckComponent = ref _filter.Get1(i);
                ref var stackComponent = ref _filter.Get2(i);
                ref var entity = ref _filter.GetEntity(i);

                var stack = stackComponent.Stack;

                var buns = stack.Where(item => item.Type == ItemTypes.Bun);
                var cutlets = stack.Where(item => item.Type == ItemTypes.Cutlet);
                var sauses = stack.Where(item => item.Type == ItemTypes.Sause);
                var vegetables = stack.Where(item => item.Type == ItemTypes.Vegetables);

                if (buns.Count() < recipeCheckComponent.BunTarget) continue;
                if (cutlets.Count() < recipeCheckComponent.CutletTarget) continue;
                if (sauses.Count() < recipeCheckComponent.SauseTarget) continue;
                if (vegetables.Count() < recipeCheckComponent.VegetablesTarget) continue;

                List<ItemComponent> itemsToDestroy = new();

                for (int j = 0; j < recipeCheckComponent.BunTarget; j++)
                    itemsToDestroy.Add(buns.ElementAt(j));

                for (int j = 0; j < recipeCheckComponent.CutletTarget; j++)
                    itemsToDestroy.Add(cutlets.ElementAt(j));

                for (int j = 0; j < recipeCheckComponent.SauseTarget; j++)
                    itemsToDestroy.Add(sauses.ElementAt(j));

                for (int j = 0; j < recipeCheckComponent.VegetablesTarget; j++)
                    itemsToDestroy.Add(vegetables.ElementAt(j));

                Debug.Log(itemsToDestroy.Count);

                entity.Get<RemoveItemsEvent>().Items = itemsToDestroy;
                entity.Get<OvenCookComponent>().ResultItemPrefab = recipeCheckComponent.ResultItemPrefab;
            }
        }
    }
}