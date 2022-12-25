// using System.Collections.Generic;
// using Entitas;
//
// namespace Core.Input
// {
//     public class StoreGetRandomSimpleStoreItemButtonListenerSystem : ReactiveSystem<InputEntity>
//     {
//         private readonly Contexts _contexts;
//
//         public StoreGetRandomSimpleStoreItemButtonListenerSystem(Contexts contexts) : base (contexts.input)
//         {
//             _contexts = contexts;
//         }
//
//         protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
//         {
//             return context.CreateCollector(InputMatcher.ButtonGetSimpleStoreRandomItemByMoney.Added());
//         }
//         
//         protected override bool Filter(InputEntity entity)
//         {
//             return true;
//         }
//         
//         protected override void Execute(List<InputEntity> entities)
//         {
//             foreach (var e in entities)
//             {
//                 _contexts.game.storeSimpleCatalogEntity.requestStoreTryPurchaseRandomStoreItem = true;
//             }
//         }
//     }
// }