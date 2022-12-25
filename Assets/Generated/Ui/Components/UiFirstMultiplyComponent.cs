//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public FirstMultiplyComponent firstMultiply { get { return (FirstMultiplyComponent)GetComponent(UiComponentsLookup.FirstMultiply); } }
    public bool hasFirstMultiply { get { return HasComponent(UiComponentsLookup.FirstMultiply); } }

    public void AddFirstMultiply(float newValue) {
        var index = UiComponentsLookup.FirstMultiply;
        var component = (FirstMultiplyComponent)CreateComponent(index, typeof(FirstMultiplyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFirstMultiply(float newValue) {
        var index = UiComponentsLookup.FirstMultiply;
        var component = (FirstMultiplyComponent)CreateComponent(index, typeof(FirstMultiplyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFirstMultiply() {
        RemoveComponent(UiComponentsLookup.FirstMultiply);
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

    static Entitas.IMatcher<UiEntity> _matcherFirstMultiply;

    public static Entitas.IMatcher<UiEntity> FirstMultiply {
        get {
            if (_matcherFirstMultiply == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.FirstMultiply);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherFirstMultiply = matcher;
            }

            return _matcherFirstMultiply;
        }
    }
}
