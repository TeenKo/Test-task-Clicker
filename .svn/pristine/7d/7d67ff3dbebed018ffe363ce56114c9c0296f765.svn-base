// using System.Collections.Generic;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public class SelectStoreItemSystem : ReactiveSystem<GameEntity>
//     {
//         private readonly Contexts _contexts;
//         private readonly IGroup<GameEntity> _simpleStoreItemsGroup;
//         private readonly IGroup<GameEntity> _premiumStoreItemsGroup;
//
//         public SelectStoreItemSystem(Contexts contexts) : base(contexts.game)
//         {
//             _contexts = contexts;
//             _simpleStoreItemsGroup =
//                 contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.StoreItemSelected, GameMatcher.StoreSimpleItem));
//             _premiumStoreItemsGroup =
//                 contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.StoreItemSelected, GameMatcher.StorePremiumItem));
//         }
//
//         protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//         {
//             return context.CreateCollector(GameMatcher.StoreTrySelectStoreItem.Added());
//         }
//
//         protected override bool Filter(GameEntity entity)
//         {
//             return entity.storeItemSold.value == true && entity.storeItemSelected.value == false;
//         }
//
//         protected override void Execute(List<GameEntity> entities)
//         {
//             foreach (var e in entities)
//             {
//                 if (e.hasStoreSimpleItem)
//                 {
//                     foreach (var entity in _simpleStoreItemsGroup.GetEntities())
//                     {
//                         if (entity.storeItemSelected.value)
//                         {
//                             entity.ReplaceStoreItemSelected(false);
//                             entity.systemTriggerSaveData = true;
//                         }
//                     }
//
//                     e.ReplaceStoreItemSelected(true);
//                     e.systemTriggerSaveData = true;
//                 }
//                 else if (e.hasStorePremiumItem)
//                 {
//                     foreach (var entity in _premiumStoreItemsGroup.GetEntities())
//                     {
//                         if (entity.storeItemSelected.value)
//                         {
//                             entity.ReplaceStoreItemSelected(false);
//                             entity.systemTriggerSaveData = true;
//                         }
//                     }
//
//                     e.ReplaceStoreItemSelected(true);
//                     e.systemTriggerSaveData = true;
//                 }
//             }
//         }
//     }
// }