// using System.Collections.Generic;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public class LoadDataPremiumStoreItemFailSystem : ReactiveSystem<GameEntity>
//     {
//         private Contexts _context;
//
//         public LoadDataPremiumStoreItemFailSystem(Contexts context) : base(context.game)
//         {
//             _context = context;
//         }
//
//         protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//         {
//             return context.CreateCollector(GameMatcher.LoadingDataFailed);
//         }
//
//         protected override bool Filter(GameEntity entity)
//         {
//             return entity.hasStorePremiumItem;
//         }
//
//         protected override void Execute(List<GameEntity> entities)
//         {
//             foreach (var e in entities)
//             {
//                 e.AddStoreItemSold(e.storePremiumItem.value.isSold);
//                 e.AddStoreItemSelected(e.storePremiumItem.value.isSold);
//                 e.AddStorePremiumItemOpenParts(0);
//
//                 e.systemTriggerSaveData = true;
//                 e.systemTriggerLoadingDatasuccessful = true;
//
//                 Dbg.Log($"Предмет {e.dataKey.value} создан и помечен как не куплен");
//             }
//         }
//     }
// }