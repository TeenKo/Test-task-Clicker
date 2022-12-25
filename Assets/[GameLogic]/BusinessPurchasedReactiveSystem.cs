using Entitas;
using System.Collections.Generic;

public class BusinessPurchasedReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;

    public BusinessPurchasedReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.Purchased.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return entity.purchased.value && entity.index.value > 0;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasIncomeTimer == false)
            {
                var uiEntity = _contexts.ui.CreateEntity();
                uiEntity.isStartIncomeTimer = true;
                uiEntity.AddIndex(entity.index.value);
            }
        }
    }
}