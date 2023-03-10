//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class LevelUpPriceEventSystem : Entitas.ReactiveSystem<UiEntity> {

    readonly System.Collections.Generic.List<ILevelUpPriceListener> _listenerBuffer;

    public LevelUpPriceEventSystem(Contexts contexts) : base(contexts.ui) {
        _listenerBuffer = new System.Collections.Generic.List<ILevelUpPriceListener>();
    }

    protected override Entitas.ICollector<UiEntity> GetTrigger(Entitas.IContext<UiEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(UiMatcher.LevelUpPrice)
        );
    }

    protected override bool Filter(UiEntity entity) {
        return entity.hasLevelUpPrice && entity.hasLevelUpPriceListener;
    }

    protected override void Execute(System.Collections.Generic.List<UiEntity> entities) {
        foreach (var e in entities) {
            var component = e.levelUpPrice;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.levelUpPriceListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnLevelUpPrice(e, component.value);
            }
        }
    }
}
