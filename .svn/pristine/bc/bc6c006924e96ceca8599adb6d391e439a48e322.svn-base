using System.Collections.Generic;
using Adapters;
using Adapters.InAppPurchase;
using Core.Configs;
using Entitas;

namespace Core.InAppPurchases
{
    public sealed class PurchaseHandlerSystem : ReactiveSystem<InAppPurchaseEntity>
    {
        private readonly AdvertisementContext _advertisementContext;
        private readonly InAppPurchaseContext _inAppPurchaseContext;
        private readonly InAppPurchasesConfig _unityInAppPurchasesConfig;

        public PurchaseHandlerSystem(AdvertisementContext advertisementContext, InAppPurchaseContext inAppPurchaseContext, UnityInAppPurchasesConfig unityInAppPurchasesConfig) : base(inAppPurchaseContext)
        {
            _advertisementContext = advertisementContext;
            _inAppPurchaseContext = inAppPurchaseContext;
            _unityInAppPurchasesConfig = unityInAppPurchasesConfig;
        }

        protected override ICollector<InAppPurchaseEntity> GetTrigger(IContext<InAppPurchaseEntity> context)
        {
           return context.CreateCollector(InAppPurchaseMatcher.ProductStatus);
        }

        protected override bool Filter(InAppPurchaseEntity entity)
        {
           return entity.productStatus.value;
        }

        protected override void Execute(List<InAppPurchaseEntity> entities)
        {
            // todo: add to component
            var removeAdsProductId = _unityInAppPurchasesConfig.GetRemoveAdsProductId();
            
            foreach (var inAppPurchaseEntity in entities)
            {
                if (inAppPurchaseEntity.productId.value == removeAdsProductId)
                {
                    _inAppPurchaseContext.serviceEntity.isRemoveAds = true;
                    _advertisementContext.serviceEntity.requestDisableAdvertisement = true;

                    Dbg.Log("Remove Ads Product = true");
                }
                
                //todo: при необходимости добавить прочие обработчики для покупок
            }
        }
    }
}