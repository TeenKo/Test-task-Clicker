using System;

namespace Core.InAppPurchases
{
    public interface IInAppPurchasesService
    {
        void Initialize(Action complete, Action failed);
        bool RequestProductStatus(string productId);
        string RequestProductPrice(string productId);
        void RequestPurchase(string productId, Action complete, Action<string> failed);
        void RequestRestoreTransactions(Action complete, Action failed);
    }
}