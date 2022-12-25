// using Core.Configs;
// using Entitas;
//
// namespace Deprecated.GameStore
// {
//     public class InitializeGameStoreSystem : IInitializeSystem
//     {
//         private readonly Contexts _contexts;
//
//         public InitializeGameStoreSystem(Contexts contexts)
//         {
//             _contexts = contexts;
//
//             contexts.game.isStaticStoreSimpleCatalog = true;
//             contexts.game.isStaticStorePremiumCatalog = true;
//         }
//
//         public void Initialize()
//         {
//             var storeCatalogConfig = ConfigsCatalogsManager.GetConfig<StoreCatalogConfig>();
//             
//             StartLoadSimpleStore(storeCatalogConfig);
//             StartLoadPremiumStore(storeCatalogConfig);
//         }
//
//         private void StartLoadSimpleStore(in StoreCatalogConfig storeCatalogConfig)
//         {
//             GameEntity simpleCatalogEntity = _contexts.game.storeSimpleCatalogEntity;
//             simpleCatalogEntity.AddDataKey("SimpleStore");
//             simpleCatalogEntity.systemTriggerLoadData = true;
//
//             for (int i = 0; i < storeCatalogConfig.SimpleStoreCatalog.items.Length; i++)
//             {
//                 var storeItemEntity = _contexts.game.CreateEntity();
//                 storeItemEntity.AddStoreSimpleItem(storeCatalogConfig.SimpleStoreCatalog.items[i]);
//                 storeItemEntity.AddDataKey($"{simpleCatalogEntity.dataKey.value}Item_{i}");
//                 storeItemEntity.systemTriggerLoadData = true;
//             }
//         }
//
//         private void StartLoadPremiumStore(in StoreCatalogConfig storeCatalogConfig)
//         {
//             GameEntity premiumCatalogEntity = _contexts.game.storePremiumCatalogEntity;
//             premiumCatalogEntity.AddDataKey("PremiumStore");
//             premiumCatalogEntity.systemTriggerLoadData = true;
//
//             for (int i = 0; i < storeCatalogConfig.PremiumStoreCatalog.items.Length; i++)
//             {
//                 var storeItemEntity = _contexts.game.CreateEntity();
//                 storeItemEntity.AddStorePremiumItem(storeCatalogConfig.PremiumStoreCatalog.items[i]);
//                 storeItemEntity.AddDataKey($"{premiumCatalogEntity.dataKey.value}Item_{i}");
//                 storeItemEntity.systemTriggerLoadData = true;
//             }
//         }
//     }
// }