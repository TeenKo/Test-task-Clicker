//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public SecondUpgradePurchasedComponent secondUpgradePurchased { get { return (SecondUpgradePurchasedComponent)GetComponent(UiComponentsLookup.SecondUpgradePurchased); } }
    public bool hasSecondUpgradePurchased { get { return HasComponent(UiComponentsLookup.SecondUpgradePurchased); } }

    public void AddSecondUpgradePurchased(bool newValue) {
        var index = UiComponentsLookup.SecondUpgradePurchased;
        var component = (SecondUpgradePurchasedComponent)CreateComponent(index, typeof(SecondUpgradePurchasedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSecondUpgradePurchased(bool newValue) {
        var index = UiComponentsLookup.SecondUpgradePurchased;
        var component = (SecondUpgradePurchasedComponent)CreateComponent(index, typeof(SecondUpgradePurchasedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSecondUpgradePurchased() {
        RemoveComponent(UiComponentsLookup.SecondUpgradePurchased);
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

    static Entitas.IMatcher<UiEntity> _matcherSecondUpgradePurchased;

    public static Entitas.IMatcher<UiEntity> SecondUpgradePurchased {
        get {
            if (_matcherSecondUpgradePurchased == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.SecondUpgradePurchased);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherSecondUpgradePurchased = matcher;
            }

            return _matcherSecondUpgradePurchased;
        }
    }
}
