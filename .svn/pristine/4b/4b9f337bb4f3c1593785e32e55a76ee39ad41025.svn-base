using System.Collections.Generic;
using Adapters;
using Entitas;

namespace Core.Analytics.Voodoo
{
    public sealed class VoodooGameLevelStartReactSystem : ReactiveSystem<AnalyticEntity>
    {
        private readonly AnalyticContext _analyticContext;

        public VoodooGameLevelStartReactSystem(AnalyticContext analyticContext) : base(analyticContext)
        {
            _analyticContext = analyticContext;
        }

        protected override ICollector<AnalyticEntity> GetTrigger(IContext<AnalyticEntity> context)
        {
            return context.CreateCollector(AnalyticMatcher.GameLevelStart.Added());
        }

        protected override bool Filter(AnalyticEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AnalyticEntity> entities)
        {
            foreach (var entity in entities)
            {
                _analyticContext.voodooService.value.GameLevelStart(new AnalyticsConfig.EventGameLevelParameters(
                    entity.gameLevelNumber.value,
                    entity.gameLevelName.value,
                    entity.gameLevelCount.value,
                    entity.gameLevelDiff.value,
                    entity.gameLevelLoop.value,
                    entity.gameLevelRandom.value,
                    entity.gameLevelType.value,
                    entity.gameLevelMode.value)
                );

                entity.Destroy();
            }
        }
    }
}