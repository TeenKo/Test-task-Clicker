#if IAPService && UNITY_PURCHASING
using UnityEngine.Purchasing;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adapters.InAppPurchase
{
#if !IAPService
    public enum ProductType
    {
        Consumable,
        NonConsumable,
        Subscription
    }
#endif

    [CreateAssetMenu(fileName = "UnityInAppPurchasesConfig", menuName = "Configs/Adapters/UnityInAppPurchasesConfig", order = 0)]
    public sealed class UnityInAppPurchasesConfig : InAppPurchasesConfig
    {
        [SerializeField] public ProductCatalogItem[] productCatalogItems;

        public IEnumerable<ProductCatalogItem> ProductCatalogItems => productCatalogItems;

        public override string GetRemoveAdsProductId()
        {
            foreach (var productCatalogItem in productCatalogItems)
                if (productCatalogItem.IsRemoveAdsProduct)
                    return productCatalogItem.ID;

            return string.Empty;
        }

        public bool IsEmpty() => productCatalogItems == null || productCatalogItems.Length == 0;
    }

    [Serializable]
    public class ProductCatalogItem
    {
        [SerializeField] private string id;
        [SerializeField] private ProductType type;
        [SerializeField] private bool isRemoveAdsProduct;
        public string ID => id;
        public ProductType Type => type;
        public bool Purchased { get; set; }

        public bool IsRemoveAdsProduct => isRemoveAdsProduct;
    }
}