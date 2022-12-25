using System.Collections.Generic;
using Entitas;

namespace Core.InAppPurchases
{
    /// <summary>
    /// Система обработки запросов покупки продуктов
    /// </summary>
    public sealed class PurchaseRequestProcessingSystem : ReactiveSystem<InAppPurchaseEntity>
    {
        private readonly InAppPurchaseContext _inAppPurchaseContext;

        public PurchaseRequestProcessingSystem(InAppPurchaseContext inAppPurchaseContext) : base(inAppPurchaseContext)
        {
            _inAppPurchaseContext = inAppPurchaseContext;
        }
        
        protected override ICollector<InAppPurchaseEntity> GetTrigger(IContext<InAppPurchaseEntity> context)
        {
           return context.CreateCollector(InAppPurchaseMatcher.PurchaseProduct);
        }
        
        protected override bool Filter(InAppPurchaseEntity entity)
        {
           return entity.hasProductId;
        }

        protected override void Execute(List<InAppPurchaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                _inAppPurchaseContext.service.value.RequestPurchase(entity.productId.value, () => Complete(entity), reason => Failed(entity, reason));
            }
        }

        private void Complete(InAppPurchaseEntity entity)
        {
            Dbg.Log($"Purchase product complete!");
            
            entity.ReplaceProductStatus(true);
            entity.requestPurchaseProduct = false;
        }

        private void Failed(InAppPurchaseEntity entity, string reason)
        {
            Dbg.Log($"Purchase product fail reason = {reason}");

            entity.requestPurchaseProduct = false;
        }
    }
}