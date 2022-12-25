//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class UserDataMoneyEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IUserDataMoneyListener> _listenerBuffer;

    public UserDataMoneyEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IUserDataMoneyListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.UserDataMoney)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasUserDataMoney && entity.hasUserDataMoneyListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.userDataMoney;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.userDataMoneyListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnUserDataMoney(e, component.value);
            }
        }
    }
}
