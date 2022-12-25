//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class StateEntity {

    public AnyDefeatListenerComponent anyDefeatListener { get { return (AnyDefeatListenerComponent)GetComponent(StateComponentsLookup.AnyDefeatListener); } }
    public bool hasAnyDefeatListener { get { return HasComponent(StateComponentsLookup.AnyDefeatListener); } }

    public void AddAnyDefeatListener(System.Collections.Generic.List<IAnyDefeatListener> newValue) {
        var index = StateComponentsLookup.AnyDefeatListener;
        var component = (AnyDefeatListenerComponent)CreateComponent(index, typeof(AnyDefeatListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyDefeatListener(System.Collections.Generic.List<IAnyDefeatListener> newValue) {
        var index = StateComponentsLookup.AnyDefeatListener;
        var component = (AnyDefeatListenerComponent)CreateComponent(index, typeof(AnyDefeatListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyDefeatListener() {
        RemoveComponent(StateComponentsLookup.AnyDefeatListener);
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
public sealed partial class StateMatcher {

    static Entitas.IMatcher<StateEntity> _matcherAnyDefeatListener;

    public static Entitas.IMatcher<StateEntity> AnyDefeatListener {
        get {
            if (_matcherAnyDefeatListener == null) {
                var matcher = (Entitas.Matcher<StateEntity>)Entitas.Matcher<StateEntity>.AllOf(StateComponentsLookup.AnyDefeatListener);
                matcher.componentNames = StateComponentsLookup.componentNames;
                _matcherAnyDefeatListener = matcher;
            }

            return _matcherAnyDefeatListener;
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
public partial class StateEntity {

    public void AddAnyDefeatListener(IAnyDefeatListener value) {
        var listeners = hasAnyDefeatListener
            ? anyDefeatListener.value
            : new System.Collections.Generic.List<IAnyDefeatListener>();
        listeners.Add(value);
        ReplaceAnyDefeatListener(listeners);
    }

    public void RemoveAnyDefeatListener(IAnyDefeatListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyDefeatListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyDefeatListener();
        } else {
            ReplaceAnyDefeatListener(listeners);
        }
    }
}