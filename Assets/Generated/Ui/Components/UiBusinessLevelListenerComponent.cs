//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public BusinessLevelListenerComponent businessLevelListener { get { return (BusinessLevelListenerComponent)GetComponent(UiComponentsLookup.BusinessLevelListener); } }
    public bool hasBusinessLevelListener { get { return HasComponent(UiComponentsLookup.BusinessLevelListener); } }

    public void AddBusinessLevelListener(System.Collections.Generic.List<IBusinessLevelListener> newValue) {
        var index = UiComponentsLookup.BusinessLevelListener;
        var component = (BusinessLevelListenerComponent)CreateComponent(index, typeof(BusinessLevelListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBusinessLevelListener(System.Collections.Generic.List<IBusinessLevelListener> newValue) {
        var index = UiComponentsLookup.BusinessLevelListener;
        var component = (BusinessLevelListenerComponent)CreateComponent(index, typeof(BusinessLevelListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBusinessLevelListener() {
        RemoveComponent(UiComponentsLookup.BusinessLevelListener);
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

    static Entitas.IMatcher<UiEntity> _matcherBusinessLevelListener;

    public static Entitas.IMatcher<UiEntity> BusinessLevelListener {
        get {
            if (_matcherBusinessLevelListener == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.BusinessLevelListener);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherBusinessLevelListener = matcher;
            }

            return _matcherBusinessLevelListener;
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

    public void AddBusinessLevelListener(IBusinessLevelListener value) {
        var listeners = hasBusinessLevelListener
            ? businessLevelListener.value
            : new System.Collections.Generic.List<IBusinessLevelListener>();
        listeners.Add(value);
        ReplaceBusinessLevelListener(listeners);
    }

    public void RemoveBusinessLevelListener(IBusinessLevelListener value, bool removeComponentWhenEmpty = true) {
        var listeners = businessLevelListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveBusinessLevelListener();
        } else {
            ReplaceBusinessLevelListener(listeners);
        }
    }
}
