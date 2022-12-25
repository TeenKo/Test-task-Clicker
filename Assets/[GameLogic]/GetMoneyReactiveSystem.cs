using Core.Configs;
using Entitas;
using System.Collections.Generic;
using System.Linq;

public class GetMoneyReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;
    private IGroup<UiEntity> _businessEntitiesGroup;
    private GameConfig _gameConfig;

    public GetMoneyReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
        _businessEntitiesGroup = contexts.ui.GetGroup(UiMatcher.Business);
        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.GetMoney.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return _contexts.game.currentGameEntity.isGameStarted;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var businessEntity in _businessEntitiesGroup.GetEntities())
            {
                if (businessEntity.index.value == entity.index.value)
                {
                    var business = _gameConfig.businesses[businessEntity.index.value];
                    var currentMoney = _contexts.game.userDataEntity.userDataMoney.value;
                    var endMoneyValue = currentMoney + businessEntity.income.value;

                    _contexts.game.userDataEntity.ReplaceUserDataMoney(endMoneyValue);

                    businessEntity.ReplaceIncomeTimer(business.delayIncome);
                }
            }
        }

        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}