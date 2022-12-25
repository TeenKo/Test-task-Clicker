//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UserDataGameLevelPlayTimeListenerComponent userDataGameLevelPlayTimeListener { get { return (UserDataGameLevelPlayTimeListenerComponent)GetComponent(GameComponentsLookup.UserDataGameLevelPlayTimeListener); } }
    public bool hasUserDataGameLevelPlayTimeListener { get { return HasComponent(GameComponentsLookup.UserDataGameLevelPlayTimeListener); } }

    public void AddUserDataGameLevelPlayTimeListener(System.Collections.Generic.List<IUserDataGameLevelPlayTimeListener> newValue) {
        var index = GameComponentsLookup.UserDataGameLevelPlayTimeListener;
        var component = (UserDataGameLevelPlayTimeListenerComponent)CreateComponent(index, typeof(UserDataGameLevelPlayTimeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUserDataGameLevelPlayTimeListener(System.Collections.Generic.List<IUserDataGameLevelPlayTimeListener> newValue) {
        var index = GameComponentsLookup.UserDataGameLevelPlayTimeListener;
        var component = (UserDataGameLevelPlayTimeListenerComponent)CreateComponent(index, typeof(UserDataGameLevelPlayTimeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUserDataGameLevelPlayTimeListener() {
        RemoveComponent(GameComponentsLookup.UserDataGameLevelPlayTimeListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherUserDataGameLevelPlayTimeListener;

    public static Entitas.IMatcher<GameEntity> UserDataGameLevelPlayTimeListener {
        get {
            if (_matcherUserDataGameLevelPlayTimeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UserDataGameLevelPlayTimeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUserDataGameLevelPlayTimeListener = matcher;
            }

            return _matcherUserDataGameLevelPlayTimeListener;
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
public partial class GameEntity {

    public void AddUserDataGameLevelPlayTimeListener(IUserDataGameLevelPlayTimeListener value) {
        var listeners = hasUserDataGameLevelPlayTimeListener
            ? userDataGameLevelPlayTimeListener.value
            : new System.Collections.Generic.List<IUserDataGameLevelPlayTimeListener>();
        listeners.Add(value);
        ReplaceUserDataGameLevelPlayTimeListener(listeners);
    }

    public void RemoveUserDataGameLevelPlayTimeListener(IUserDataGameLevelPlayTimeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = userDataGameLevelPlayTimeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveUserDataGameLevelPlayTimeListener();
        } else {
            ReplaceUserDataGameLevelPlayTimeListener(listeners);
        }
    }
}
