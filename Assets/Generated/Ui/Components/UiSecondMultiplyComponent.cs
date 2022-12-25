//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public SecondMultiplyComponent secondMultiply { get { return (SecondMultiplyComponent)GetComponent(UiComponentsLookup.SecondMultiply); } }
    public bool hasSecondMultiply { get { return HasComponent(UiComponentsLookup.SecondMultiply); } }

    public void AddSecondMultiply(float newValue) {
        var index = UiComponentsLookup.SecondMultiply;
        var component = (SecondMultiplyComponent)CreateComponent(index, typeof(SecondMultiplyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSecondMultiply(float newValue) {
        var index = UiComponentsLookup.SecondMultiply;
        var component = (SecondMultiplyComponent)CreateComponent(index, typeof(SecondMultiplyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSecondMultiply() {
        RemoveComponent(UiComponentsLookup.SecondMultiply);
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

    static Entitas.IMatcher<UiEntity> _matcherSecondMultiply;

    public static Entitas.IMatcher<UiEntity> SecondMultiply {
        get {
            if (_matcherSecondMultiply == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.SecondMultiply);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherSecondMultiply = matcher;
            }

            return _matcherSecondMultiply;
        }
    }
}
