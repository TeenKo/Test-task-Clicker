//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public SecondUpgradePurchasedListenerComponent secondUpgradePurchasedListener { get { return (SecondUpgradePurchasedListenerComponent)GetComponent(UiComponentsLookup.SecondUpgradePurchasedListener); } }
    public bool hasSecondUpgradePurchasedListener { get { return HasComponent(UiComponentsLookup.SecondUpgradePurchasedListener); } }

    public void AddSecondUpgradePurchasedListener(System.Collections.Generic.List<ISecondUpgradePurchasedListener> newValue) {
        var index = UiComponentsLookup.SecondUpgradePurchasedListener;
        var component = (SecondUpgradePurchasedListenerComponent)CreateComponent(index, typeof(SecondUpgradePurchasedListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSecondUpgradePurchasedListener(System.Collections.Generic.List<ISecondUpgradePurchasedListener> newValue) {
        var index = UiComponentsLookup.SecondUpgradePurchasedListener;
        var component = (SecondUpgradePurchasedListenerComponent)CreateComponent(index, typeof(SecondUpgradePurchasedListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSecondUpgradePurchasedListener() {
        RemoveComponent(UiComponentsLookup.SecondUpgradePurchasedListener);
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

    static Entitas.IMatcher<UiEntity> _matcherSecondUpgradePurchasedListener;

    public static Entitas.IMatcher<UiEntity> SecondUpgradePurchasedListener {
        get {
            if (_matcherSecondUpgradePurchasedListener == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.SecondUpgradePurchasedListener);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherSecondUpgradePurchasedListener = matcher;
            }

            return _matcherSecondUpgradePurchasedListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public void AddSecondUpgradePurchasedListener(ISecondUpgradePurchasedListener value) {
        var listeners = hasSecondUpgradePurchasedListener
            ? secondUpgradePurchasedListener.value
            : new System.Collections.Generic.List<ISecondUpgradePurchasedListener>();
        listeners.Add(value);
        ReplaceSecondUpgradePurchasedListener(listeners);
    }

    public void RemoveSecondUpgradePurchasedListener(ISecondUpgradePurchasedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = secondUpgradePurchasedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSecondUpgradePurchasedListener();
        } else {
            ReplaceSecondUpgradePurchasedListener(listeners);
        }
    }
}
