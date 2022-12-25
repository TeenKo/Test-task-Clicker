#if IAPService && UNITY_PURCHASING
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
using System;
using System.Linq;
using Core.InAppPurchasesService;
using Main.Configs;
using UnityEngine;

namespace Adapters.InAppPurchase
{
    public sealed class UnityInAppPurchasesService : IInAppPurchasesService
    {
        private IStoreController _controller;
        private IExtensionProvider _extensions;

        private CrossPlatformValidator _validator;

        private Action<bool> _onInitializingComplete;
        private Action<bool, string> _onPurchaseComplete;

        private UnityInAppPurchasesConfig _config;

        public void Initialize(Action complete, Action failed)
        {
            var catalog = ProductCatalog.LoadDefaultCatalog();
            if (!catalog.IsEmpty() && catalog.enableCodelessAutoInitialization)
                throw new Exception(
                    $"{nameof(InAppPurchaseService)}.{nameof(Initialize)} Turn off toggle \"Automatically initialize UnityPurchasing\" in \"Window -> Unity IAP -> IAP Catalog\"!");
            
            if (!(AdaptersConfigs.InAppPurchasesConfig is UnityInAppPurchasesConfig config))
            {
                failed?.Invoke();
                return;
            }
            
            if (config.IsEmpty())
                throw new Exception(
                    $"{nameof(InAppPurchaseService)}.{nameof(Initialize)} {nameof(InAppPurchaseSettings)} was not created or empty!");

            _config = config;
            
            var module = StandardPurchasingModule.Instance();
            module.useFakeStoreUIMode = FakeStoreUIMode.Default;
            
            var builder = ConfigurationBuilder.Instance(module);

            foreach (var productCatalogItem in _config.ProductCatalogItems)
                builder.AddProduct(productCatalogItem.ID, productCatalogItem.Type);

            _validator =
                new CrossPlatformValidator(GooglePlayTangle.Data(), AppleTangle.Data(), Application.identifier);

            _onInitializingComplete = result =>
            {
                if (result) complete?.Invoke();
                else failed?.Invoke();
            };
            UnityPurchasing.Initialize(this, builder);
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _controller = controller;
            _extensions = extensions;

            _extensions.GetExtension<IAppleExtensions>().RegisterPurchaseDeferredListener(OnDeferred);

            _onInitializingComplete?.Invoke(true);
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // InitializationFailureReason.PurchasingUnavailable
            // InitializationFailureReason.AppNotKnown
            // InitializationFailureReason.NoProductsAvailable

            _onInitializingComplete?.Invoke(false);
        }

        /// <summary>
        /// Запросить статус продукта (true - если приобретен) 
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        public bool RequestProductStatus(string productId)
        {
            // todo: add methods to define subscription expire date

            return _controller.products.all.Any(product =>
                product.hasReceipt && product.definition.type == ProductType.NonConsumable &&
                product.definition.id == productId);
        }
        
        /// <summary>
        /// Запросить локализованную стоимость продукта 
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        public string RequestProductPrice(string productId)
        {
            if (string.IsNullOrEmpty(productId)) return string.Empty;

            foreach (var product in _controller.products.all)
            {
                if (product.definition.id == productId)
                {
                    return product.metadata.localizedPriceString;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Запросить покупку продукта
        /// </summary>
        /// <param name="productId">Id продукта</param>
        /// <param name="complete">Вызов при успешной покупке</param>
        /// <param name="failed">Вызов при неудаче</param>
        public void RequestPurchase(string productId, Action complete, Action<string> failed)
        {
            _onPurchaseComplete = (result, message) =>
            {
                if (result) complete?.Invoke();
                else failed?.Invoke(message);
            };

            var product = _controller.products.WithID(productId);
            if (product != null && product.availableToPurchase)
                _controller.InitiatePurchase(product);
            else
                _onPurchaseComplete?.Invoke(false, $"{productId}-{PurchaseFailureReason.ProductUnavailable}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            if (ValidatePurchasing(purchaseEvent.purchasedProduct))
                _onPurchaseComplete?.Invoke(true, purchaseEvent.purchasedProduct.definition.id);
            else
                OnPurchaseFailed(purchaseEvent.purchasedProduct, PurchaseFailureReason.SignatureInvalid);

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) =>
            _onPurchaseComplete?.Invoke(false, $"{product.definition.id}-{failureReason}");

        private bool ValidatePurchasing(Product product)
        {
            try
            {
                var result = _validator.Validate(product.receipt);

                return true;
            }
            catch (IAPSecurityException)
            {
                return false;
            }
        }

        /// <summary>
        /// Запросить восстановление приобретенных продуктов
        /// </summary>
        /// <param name="complete">Вызов при успешной покупке</param>
        /// <param name="failed">Вызов при неудаче</param>
        public void RequestRestoreTransactions(Action complete, Action failed)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _extensions.GetExtension<IGooglePlayStoreExtensions>()
                    .RestoreTransactions(result =>
                    {
                        if (result) complete?.Invoke();
                        else failed?.Invoke();
                    });
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _extensions.GetExtension<IAppleExtensions>()
                    .RestoreTransactions(result =>
                    {
                        if (result) complete?.Invoke();
                        else failed?.Invoke();
                    });
            }
            else
                complete?.Invoke();
        }

        private void OnDeferred(Product item)
        {
            Debug.Log("Purchase deferred: " + item.definition.id);
        }
    }
}
#endif