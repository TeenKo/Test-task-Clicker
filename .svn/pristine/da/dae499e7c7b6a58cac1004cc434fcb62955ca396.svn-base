// using System.Collections.Generic;
// using Core.Configs;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public sealed class LoadDataSimpleStoreItemFailSystem : ReactiveSystem<GameEntity>
//     {
//         private readonly Contexts _context;
//         private readonly StoreCatalogConfig _config;
//     
//         public LoadDataSimpleStoreItemFailSystem(Contexts context) : base(context.game)
//         {
//             _context = context;
//             _config = ConfigsCatalogsManager.GetConfig<StoreCatalogConfig>();
//         }
//     
//         protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//         {
//             return context.CreateCollector(GameMatcher.LoadingDataFailed);
//         }
//     
//         protected override bool Filter(GameEntity entity)
//         {
//             return entity.hasStoreSimpleItem;
//         }
//     
//         protected override void Execute(List<GameEntity> entities)
//         {
//             _context.game.storeSimpleCatalogEntity.AddStoreCatalogPrice(_config.SimpleStoreCatalog.catalogPrice);
//             _context.game.storeSimpleCatalogEntity.systemTriggerSaveData = true;
//     
//             foreach (var e in entities)
//             {
//                 e.AddStoreItemSold(e.storeSimpleItem.value.isSold);
//                 e.AddStoreItemSelected(e.storeSimpleItem.value.isSold);               
//     
//                 e.systemTriggerSaveData = true;
//                 e.systemTriggerLoadingDatasuccessful = true;
//     
//                 Dbg.Log($"Предмет {e.dataKey.value} создан и помечен как не куплен");
//             }
//         }
//     }
// }