#if !IAPService
using System;
using System.Linq;
using Core.Configs;
using Core.InAppPurchases;

namespace Adapters.InAppPurchase
{
    public sealed class UnityInAppPurchasesService : IInAppPurchasesService
    {
        private string FailedPurchaseMessageWhenProductIdNotFound(string productId) =>
            $"{nameof(UnityInAppPurchasesService)}.{nameof(RequestPurchase)} Product id = {productId} not exists!";

        private UnityInAppPurchasesConfig _config;

        public void Initialize(Action complete, Action failed)
        {
            var config = ConfigsCatalogsManager.GetConfig<UnityInAppPurchasesConfig>();
            if (config == null) failed.Invoke();
            // if (!(AdaptersConfigsCatalog.InAppPurchasesConfig is UnityInAppPurchasesConfig config))
            // {
            //     failed?.Invoke();
            //     return;
            // }

            if (config.IsEmpty())
            {
                // Debug.Log($"{nameof(InAppPurchaseService)}.{nameof(Initialize)} {nameof(UnityInAppPurchasesConfig)} was not created or empty!");
                failed?.Invoke();
                return;
            }

            _config = config;
            complete?.Invoke();
        }

        public bool RequestProductStatus(string productId)
        {
            return _config.ProductCatalogItems.Any(product =>
                product.ID == productId && product.Type == ProductType.NonConsumable && product.Purchased);
        }

        public string RequestProductPrice(string productId)
        {
            return $"0";
        }

        public void RequestPurchase(string productId, Action complete, Action<string> failed)
        {
            var purchaseComplete = false;
            foreach (var productDefinition in _config.ProductCatalogItems)
            {
                if (productDefinition.ID != productId) continue;
                productDefinition.Purchased = true;
                purchaseComplete = true;
            }

            if (purchaseComplete == false)
            {
                failed?.Invoke(FailedPurchaseMessageWhenProductIdNotFound(productId));
                return;
            }

            complete?.Invoke();
        }

        public void RequestRestoreTransactions(Action complete, Action failed) => complete?.Invoke();
    }
}
#endif