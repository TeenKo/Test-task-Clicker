// using System.Collections.Generic;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public sealed class PurchaseSimpleStoreRandomItemSystem : ReactiveSystem<GameEntity>
//     {
//         private readonly Contexts _context;
//
//         public PurchaseSimpleStoreRandomItemSystem(Contexts context) : base(context.game)
//         {
//             _context = context;
//         }
//
//         protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//         {
//             return context.CreateCollector(GameMatcher.StoreTryPurchaseRandomStoreItem.Added());
//         }
//
//         protected override bool Filter(GameEntity entity)
//         {
//             return entity.isStaticStoreSimpleCatalog && entity.hasStoreCatalogPrice;
//         }
//
//         protected override void Execute(List<GameEntity> entities)
//         {
//             foreach (var e in entities)
//             {
//                 int itemPrice = e.storeCatalogPrice.value;
//                 int playerMoney = _context.game.currentPlayerDataEntity.playerMoney.value;
//
//                 if (playerMoney >= itemPrice)
//                 {
//                     IGroup<GameEntity> catalogItemGroup = _context.game.GetGroup(GameMatcher.StoreSimpleItem);
//
//
//                     List<GameEntity> roulette = new List<GameEntity>();
//                     foreach (var storeItemEntity in catalogItemGroup.GetEntities())
//                         if (storeItemEntity.storeItemSold.value == false)
//                         {
//                             roulette.Add(storeItemEntity);
//                             // storeItemEntity.isStoreItemRouleteVisual = true;
//                         }
//
//
//                     if (roulette.Count == 0)
//                         continue;
//
//                     _context.game.currentPlayerDataEntity.ReplacePlayerMoney(playerMoney - itemPrice);
//                     _context.game.currentPlayerDataEntity.systemTriggerSaveData = true;
//
//                     GameEntity winEntity = roulette[UnityEngine.Random.Range(0, roulette.Count)];
//                     winEntity.ReplaceStoreItemSold(true);
//
//                     winEntity.systemTriggerSaveData = true;
//
//                     //перенести в визуальную рулетку
//                     winEntity.isStoreUnlockItem = true;
//                     winEntity.requestStoreTrySelectStoreItem = true;
//
//                     Dbg.Log($"Предмет {winEntity.dataKey.value} получен");
//                 }
//                 else
//                 {
//                     Dbg.Log($"Не удалось купить предмет из каталога ");
//                 }
//             }
//         }
//     }
// }