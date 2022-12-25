using Entitas;
using System.Collections.Generic;

public class SaveBusinessLevelReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;

    public SaveBusinessLevelReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.BusinessLevel.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return _contexts.game.currentGameEntity.isGameStarted;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.systemTriggerUISaveData = true;
        }
    }
}