// using System.Collections.Generic;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public class PurchasePremiumStoreRandomItemSystem : ReactiveSystem<GameEntity>
//     {
//         private readonly Contexts _contexts;
//
//         public PurchasePremiumStoreRandomItemSystem(Contexts contexts) : base(contexts.game)
//         {
//             _contexts = contexts;
//         }
//
//         protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//         {
//             return context.CreateCollector(GameMatcher.StoreTryPurchaseRandomStoreItem.Added());
//         }
//
//         protected override bool Filter(GameEntity entity)
//         {
//             return entity.isStaticStorePremiumCatalog;
//         }
//
//         protected override void Execute(List<GameEntity> entities)
//         {
//             IGroup<GameEntity> catalogItemGroup = _contexts.game.GetGroup(GameMatcher.StorePremiumItem);
//
//             List<GameEntity> roulette = new List<GameEntity>();
//             foreach (var storeItemEntity in catalogItemGroup.GetEntities())
//                 if (storeItemEntity.storeItemSold.value == false)
//                 {
//                     roulette.Add(storeItemEntity);
//                     // storeItemEntity.isStoreItemRouleteVisual = true;
//                 }
//
//             if (roulette.Count == 0)
//                 return;
//
//             GameEntity winEntity = roulette[UnityEngine.Random.Range(0, roulette.Count)];
//
//             if (winEntity.storePremiumItemOpenParts.value + 1 == winEntity.storePremiumItemTotalParts.value)
//             {
//                 winEntity.ReplaceStoreItemSold(true);
//                 //перенести в визуальную рулетку
//                 winEntity.isStoreUnlockItem = true;
//                 winEntity.requestStoreTrySelectStoreItem = true;
//             }
//             else
//             {
//                 //перенести в визуальную рулетку
//                 winEntity.ReplaceStorePremiumItemOpenParts(winEntity.storePremiumItemOpenParts.value + 1);
//             }
//
//             winEntity.systemTriggerSaveData = true;
//         }
//     }
// }