//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    static readonly Core.DataStorage.UISaveData uISaveDataComponent = new Core.DataStorage.UISaveData();

    public bool systemTriggerUISaveData {
        get { return HasComponent(UiComponentsLookup.UISaveData); }
        set {
            if (value != systemTriggerUISaveData) {
                var index = UiComponentsLookup.UISaveData;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : uISaveDataComponent;

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

    static Entitas.IMatcher<UiEntity> _matcherUISaveData;

    public static Entitas.IMatcher<UiEntity> UISaveData {
        get {
            if (_matcherUISaveData == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.UISaveData);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherUISaveData = matcher;
            }

            return _matcherUISaveData;
        }
    }
}