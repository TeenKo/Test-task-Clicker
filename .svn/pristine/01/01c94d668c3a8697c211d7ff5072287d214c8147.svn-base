using Adapters.InAppPurchase;
using Core.Configs;

namespace Core.InAppPurchases
{
    /// <summary>
    /// Набор систем взаимодействия с сервисом внутриигровых покупок (Unity IAP)
    /// </summary>
    public sealed class InAppPurchaseSystems : Entitas.Systems
    {
        public InAppPurchaseSystems(AdvertisementContext advertisementContext, InAppPurchaseContext inAppPurchaseContext)
        {
            var unityInAppPurchasesConfig = ConfigsCatalogsManager.GetConfig<UnityInAppPurchasesConfig>();

            Add(new InitializeSystem(inAppPurchaseContext));
            Add(new InitializingCompleteSystem(inAppPurchaseContext));
            Add(new PurchaseRequestProcessingSystem(inAppPurchaseContext));
            Add(new RestoreTransactionProcessingSystem(inAppPurchaseContext));
            Add(new PurchaseHandlerSystem(advertisementContext, inAppPurchaseContext, unityInAppPurchasesConfig));
        }
    }
}