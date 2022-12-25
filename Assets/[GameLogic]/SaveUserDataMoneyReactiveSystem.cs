using Entitas;
using System.Collections.Generic;

public class SaveUserDataMoneyReactiveSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public SaveUserDataMoneyReactiveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UserDataMoney.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return _contexts.game.currentGameEntity.isGameStarted;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.systemTriggerSaveData = true;
        }
    }
}