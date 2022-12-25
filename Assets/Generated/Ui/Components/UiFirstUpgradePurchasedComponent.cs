//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public FirstUpgradePurchasedComponent firstUpgradePurchased { get { return (FirstUpgradePurchasedComponent)GetComponent(UiComponentsLookup.FirstUpgradePurchased); } }
    public bool hasFirstUpgradePurchased { get { return HasComponent(UiComponentsLookup.FirstUpgradePurchased); } }

    public void AddFirstUpgradePurchased(bool newValue) {
        var index = UiComponentsLookup.FirstUpgradePurchased;
        var component = (FirstUpgradePurchasedComponent)CreateComponent(index, typeof(FirstUpgradePurchasedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFirstUpgradePurchased(bool newValue) {
        var index = UiComponentsLookup.FirstUpgradePurchased;
        var component = (FirstUpgradePurchasedComponent)CreateComponent(index, typeof(FirstUpgradePurchasedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFirstUpgradePurchased() {
        RemoveComponent(UiComponentsLookup.FirstUpgradePurchased);
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

    static Entitas.IMatcher<UiEntity> _matcherFirstUpgradePurchased;

    public static Entitas.IMatcher<UiEntity> FirstUpgradePurchased {
        get {
            if (_matcherFirstUpgradePurchased == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.FirstUpgradePurchased);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherFirstUpgradePurchased = matcher;
            }

            return _matcherFirstUpgradePurchased;
        }
    }
}
