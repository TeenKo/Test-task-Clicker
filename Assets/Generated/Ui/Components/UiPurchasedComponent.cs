//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public PurchasedComponent purchased { get { return (PurchasedComponent)GetComponent(UiComponentsLookup.Purchased); } }
    public bool hasPurchased { get { return HasComponent(UiComponentsLookup.Purchased); } }

    public void AddPurchased(bool newValue) {
        var index = UiComponentsLookup.Purchased;
        var component = (PurchasedComponent)CreateComponent(index, typeof(PurchasedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePurchased(bool newValue) {
        var index = UiComponentsLookup.Purchased;
        var component = (PurchasedComponent)CreateComponent(index, typeof(PurchasedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePurchased() {
        RemoveComponent(UiComponentsLookup.Purchased);
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

    static Entitas.IMatcher<UiEntity> _matcherPurchased;

    public static Entitas.IMatcher<UiEntity> Purchased {
        get {
            if (_matcherPurchased == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.Purchased);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherPurchased = matcher;
            }

            return _matcherPurchased;
        }
    }
}
