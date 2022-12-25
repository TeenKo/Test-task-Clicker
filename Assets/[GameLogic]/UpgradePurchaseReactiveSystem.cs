using Entitas;
using System.Collections.Generic;

public class UpgradePurchaseReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;
    private IGroup<UiEntity> _businessEntitiesGroup;

    public UpgradePurchaseReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
        _businessEntitiesGroup = contexts.ui.GetGroup(UiMatcher.Business);
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.FirstUpgradePurchase.Added(), UiMatcher.SecondUpgradePurchase.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return true;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var business in _businessEntitiesGroup.GetEntities())
            {
                if (business.index.value == entity.index.value)
                {
                    if (entity.isFirstUpgradePurchase)
                    {
                        business.ReplaceFirstUpgradePurchased(true);
                    }

                    if (entity.isSecondUpgradePurchase)
                    {
                        business.ReplaceSecondUpgradePurchased(true);
                    }
                }
            }
        }

        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}