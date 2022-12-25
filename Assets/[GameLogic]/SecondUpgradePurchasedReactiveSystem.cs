using Core.Configs;
using Entitas;
using System.Collections.Generic;

public class SecondUpgradePurchasedReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;
    private GameConfig _gameConfig;

    public SecondUpgradePurchasedReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.SecondUpgradePurchased.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return true;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.secondUpgradePurchased.value)
            {
                var businnes = _gameConfig.businesses[entity.index.value];
                var bonusMultiply = businnes.second.multiplyIncome / 100;

                entity.ReplaceSecondMultiply(bonusMultiply);

                var uiEntity = _contexts.ui.CreateEntity();
                uiEntity.isChangeBusinessValue = true;
                uiEntity.AddIndex(entity.index.value);
            }
        }
    }
}