using Core.Configs;
using Entitas;
using System.Collections.Generic;

public class ChangeBusinessValueReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;
    private IGroup<UiEntity> _businessEntitiesGroup;
    private GameConfig _gameConfig;

    public ChangeBusinessValueReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
        _businessEntitiesGroup = contexts.ui.GetGroup(UiMatcher.Business);
        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.ChangeBusinessValue.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return true;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var businessEntity in _businessEntitiesGroup.GetEntities())
            {
                if (entity.index.value == businessEntity.index.value)
                {
                    businessEntity.ReplaceLevelUpPrice(_gameConfig.GetLevelPrice(businessEntity));
                    businessEntity.ReplaceIncome(_gameConfig.GetIncome(businessEntity));
                }
            }
        }

        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}