using Core.Configs;
using Entitas;
using System.Collections.Generic;
using System.Linq;

public class GameStartedReactiveSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<UiEntity> _businessEntitiesGroup;
    private GameConfig _gameConfig;

    public GameStartedReactiveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _businessEntitiesGroup = contexts.ui.GetGroup(UiMatcher.Business);
        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameStarted.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var gameEntity = entities.FirstOrDefault();

        foreach (var businessEntity in _businessEntitiesGroup.GetEntities())
        {
            if (businessEntity.purchased.value)
            {
                if (gameEntity.isGameStarted)
                {
                    var uiEntity = _contexts.ui.CreateEntity();
                    uiEntity.isStartIncomeTimer = true;
                    uiEntity.AddIndex(businessEntity.index.value);
                }
                else
                {
                    businessEntity.ReplaceIncomeTimer(0);
                    businessEntity.RemoveIncomeTimer();
                }
            }
        }
    }
}