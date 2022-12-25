using Entitas;
using System.Collections.Generic;
using System.Linq;

public class BusinessLevelUpReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;
    private IGroup<UiEntity> _businessEntitiesGroup;

    public BusinessLevelUpReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
        _businessEntitiesGroup = contexts.ui.GetGroup(UiMatcher.Business);
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.Purchase.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return true;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        var entity = entities.FirstOrDefault();
        var userDataEntity = _contexts.game.userDataEntity;

        foreach (var businessEntity in _businessEntitiesGroup.GetEntities())
        {
            if (entity.index.value == businessEntity.index.value)
            {
                if (userDataEntity.userDataMoney.value >= businessEntity.levelUpPrice.value)
                {
                    float endMoneyValue = userDataEntity.userDataMoney.value - businessEntity.levelUpPrice.value;
                    userDataEntity.ReplaceUserDataMoney(endMoneyValue);

                    businessEntity.ReplaceBusinessLevel(businessEntity.businessLevel.value + 1);

                    entity.Destroy();
                    break;
                }
            }
        }
    }
}