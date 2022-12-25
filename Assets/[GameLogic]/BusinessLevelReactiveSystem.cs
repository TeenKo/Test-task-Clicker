using Entitas;
using System.Collections.Generic;

public class BusinessLevelReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;

    public BusinessLevelReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.BusinessLevel.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return true;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.purchased.value == false && entity.businessLevel.value > 0)
            {
                entity.ReplacePurchased(true);
            }

            if (entity.businessLevel.value > 1)
            {
                var uiEntity = _contexts.ui.CreateEntity();
                uiEntity.isChangeBusinessValue = true;
                uiEntity.AddIndex(entity.index.value);
            }
        }
    }
}