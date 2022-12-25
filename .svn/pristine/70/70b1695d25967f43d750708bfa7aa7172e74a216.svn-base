using System.Collections.Generic;
using Entitas;

namespace Core.InAppPurchases
{
    public sealed class InitializingCompleteSystem : ReactiveSystem<InAppPurchaseEntity>
    {
        private readonly InAppPurchaseContext _inAppPurchaseContext;

        public InitializingCompleteSystem(InAppPurchaseContext inAppPurchaseContext) : base(inAppPurchaseContext)
        {
            _inAppPurchaseContext = inAppPurchaseContext;
        }

        protected override ICollector<InAppPurchaseEntity> GetTrigger(IContext<InAppPurchaseEntity> context)
        {
            return context.CreateCollector(InAppPurchaseMatcher.InAppPurchaseServiceInitialized);
        }

        protected override bool Filter(InAppPurchaseEntity entity)
        {
            return entity.isInAppPurchaseServiceInitialized;
        }

        protected override void Execute(List<InAppPurchaseEntity> entities)
        {
            var productEntitiesGroup = _inAppPurchaseContext.GetGroup(InAppPurchaseMatcher.ProductId);

            foreach (var inAppPurchaseEntity in productEntitiesGroup.GetEntities())
            {
                var isPurchased = _inAppPurchaseContext.service.value.RequestProductStatus(inAppPurchaseEntity.productId.value);
                inAppPurchaseEntity.ReplaceProductStatus(isPurchased);
            }
        }
    }
}