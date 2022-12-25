using System.Collections.Generic;
using Entitas;

namespace Core.InAppPurchases
{
    /// <summary>
    /// Система обработки восстановления не расходуемых покупок
    /// </summary>
    public sealed class RestoreTransactionProcessingSystem : ReactiveSystem<InAppPurchaseEntity>
    {
        private readonly InAppPurchaseContext _inAppPurchaseContext;
        private readonly IGroup<InAppPurchaseEntity> _productsGroup;

        public RestoreTransactionProcessingSystem(InAppPurchaseContext inAppPurchaseContext) : base(inAppPurchaseContext)
        {
            _inAppPurchaseContext = inAppPurchaseContext;
            _productsGroup =  _inAppPurchaseContext.GetGroup(InAppPurchaseMatcher.ProductId);
        }

        protected override ICollector<InAppPurchaseEntity> GetTrigger(IContext<InAppPurchaseEntity> context)
        {
           return context.CreateCollector(InAppPurchaseMatcher.RestoreProducts);
        }

        protected override bool Filter(InAppPurchaseEntity entity)
        {
           return entity.isInAppPurchaseServiceInitialized;
        }

        protected override void Execute(List<InAppPurchaseEntity> entities)
        {
            _inAppPurchaseContext.service.value.RequestRestoreTransactions(Complete, Failed);
        }

        private void Complete()
        {
            Dbg.Log("RestoreTransactions Complete");
            
            foreach (var inAppPurchaseEntity in _productsGroup.GetEntities())
            {
                inAppPurchaseEntity.ReplaceProductStatus(true);
            }

            _inAppPurchaseContext.serviceEntity.requestRestoreProducts = false;
        }

        private void Failed()
        {
            Dbg.Log("RestoreTransactions Failed");

            _inAppPurchaseContext.serviceEntity.requestRestoreProducts = false;
        }
    }
}