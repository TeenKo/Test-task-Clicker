//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class StateEntity {

    static readonly Core.ApplicationStates.GameComponent gameComponent = new Core.ApplicationStates.GameComponent();

    public bool transitionGame {
        get { return HasComponent(StateComponentsLookup.Game); }
        set {
            if (value != transitionGame) {
                var index = StateComponentsLookup.Game;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameComponent;

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
public sealed partial class StateMatcher {

    static Entitas.IMatcher<StateEntity> _matcherGame;

    public static Entitas.IMatcher<StateEntity> Game {
        get {
            if (_matcherGame == null) {
                var matcher = (Entitas.Matcher<StateEntity>)Entitas.Matcher<StateEntity>.AllOf(StateComponentsLookup.Game);
                matcher.componentNames = StateComponentsLookup.componentNames;
                _matcherGame = matcher;
            }

            return _matcherGame;
        }
    }
}