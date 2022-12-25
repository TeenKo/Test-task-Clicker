using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.InAppPurchases
{
    [InAppPurchase, Unique]
    public sealed class ServiceComponent : IComponent
    {
        public IInAppPurchasesService value;
    }

    [InAppPurchase, Event(EventTarget.Self)]
    public sealed class InAppPurchaseServiceInitializedComponent : IComponent
    {
    }

    [InAppPurchase]
    public sealed class RemoveAdsComponent : IComponent
    {
        
    }

    [InAppPurchase]
    public sealed class ProductIdComponent : IComponent
    {
        public string value;
    }

    [InAppPurchase, Event(EventTarget.Self)]
    public sealed class ProductStatusComponent : IComponent
    {
        public bool value;
    }

    [InAppPurchase, Event(EventTarget.Self)]
    public sealed class ProductPriceComponent : IComponent
    {
        public string value;
    }

    [InAppPurchase, FlagPrefix("Request")]
    public sealed class PurchaseProductComponent : IComponent
    {
    }

    [InAppPurchase, FlagPrefix("Request")]
    public sealed class RestoreProductsComponent : IComponent
    {
    }
}