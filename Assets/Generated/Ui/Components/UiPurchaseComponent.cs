//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    static readonly PurchaseComponent purchaseComponent = new PurchaseComponent();

    public bool isPurchase {
        get { return HasComponent(UiComponentsLookup.Purchase); }
        set {
            if (value != isPurchase) {
                var index = UiComponentsLookup.Purchase;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : purchaseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherPurchase;

    public static Entitas.IMatcher<UiEntity> Purchase {
        get {
            if (_matcherPurchase == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.Purchase);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherPurchase = matcher;
            }

            return _matcherPurchase;
        }
    }
}