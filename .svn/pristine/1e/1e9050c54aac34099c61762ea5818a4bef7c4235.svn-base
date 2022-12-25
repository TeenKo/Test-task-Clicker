using Adapters.InAppPurchase;
using Entitas;

namespace Core.InAppPurchases
{
    public sealed class InitializeSystem : IInitializeSystem
    {
        private readonly InAppPurchaseContext _inAppPurchaseContext;

        internal InitializeSystem(InAppPurchaseContext inAppPurchaseContext)
        {
            _inAppPurchaseContext = inAppPurchaseContext;
            _inAppPurchaseContext.SetService(new UnityInAppPurchasesService());
        }

        public void Initialize()
        {
            _inAppPurchaseContext.serviceEntity.service.value.Initialize(
                () => { _inAppPurchaseContext.serviceEntity.isInAppPurchaseServiceInitialized = true; },
                () => { });
        }
    }
}