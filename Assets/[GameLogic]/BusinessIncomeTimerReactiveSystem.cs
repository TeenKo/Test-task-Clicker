using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class BusinessIncomeTimerReactiveSystem : ReactiveSystem<UiEntity>
{
    private Contexts _contexts;

    public BusinessIncomeTimerReactiveSystem(Contexts contexts) : base(contexts.ui)
    {
        _contexts = contexts;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
    {
        return context.CreateCollector(UiMatcher.IncomeTimer.Added());
    }

    protected override bool Filter(UiEntity entity)
    {
        return entity.hasIncomeTimer;
    }

    protected override void Execute(List<UiEntity> entities)
    {
        foreach (var entity in entities)
        {
            var timeValue = entity.incomeTimer.value - Time.deltaTime;

            if (timeValue <= 0)
            {
                var uiEntity = _contexts.ui.CreateEntity();
                uiEntity.isGetMoney = true;
                uiEntity.AddIndex(entity.index.value);

                entity.RemoveIncomeTimer();
                continue;
            }

            entity.ReplaceIncomeTimer(timeValue);
        }
    }
}