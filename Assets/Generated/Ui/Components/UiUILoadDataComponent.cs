//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    static readonly Core.DataStorage.UILoadData uILoadDataComponent = new Core.DataStorage.UILoadData();

    public bool systemTriggerUILoadData {
        get { return HasComponent(UiComponentsLookup.UILoadData); }
        set {
            if (value != systemTriggerUILoadData) {
                var index = UiComponentsLookup.UILoadData;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : uILoadDataComponent;

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

    static Entitas.IMatcher<UiEntity> _matcherUILoadData;

    public static Entitas.IMatcher<UiEntity> UILoadData {
        get {
            if (_matcherUILoadData == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.UILoadData);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherUILoadData = matcher;
            }

            return _matcherUILoadData;
        }
    }
}
