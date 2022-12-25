using System.Collections.Generic;
using Adapters;
using Entitas;

namespace Core.Analytics.AppMetrica
{
    public sealed class AppMetricaGameLevelFinishReactSystem : ReactiveSystem<AnalyticEntity>
    {
        private readonly  AnalyticContext _analyticContext;

        public AppMetricaGameLevelFinishReactSystem(AnalyticContext analyticContext) : base(analyticContext)
        {
            _analyticContext = analyticContext;
        }

        protected override ICollector<AnalyticEntity> GetTrigger(IContext<AnalyticEntity> context)
        {
            return context.CreateCollector(AnalyticMatcher.GameLevelFinish.Added());
        }

        protected override bool Filter(AnalyticEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AnalyticEntity> entities)
        {
            foreach (var entity in entities)
            {
                _analyticContext.appMetricaService.value.GameLevelFinish(new AnalyticsConfig.EventGameLevelParameters(
                    entity.gameLevelNumber.value,
                    entity.gameLevelName.value,
                    entity.gameLevelCount.value,
                    entity.gameLevelDiff.value,
                    entity.gameLevelLoop.value,
                    entity.gameLevelRandom.value,
                    entity.gameLevelType.value,
                    entity.gameLevelMode.value,
                    entity.gameLevelResult.value,
                    entity.gameLevelTime.value,
                    entity.gameLevelProgress.value,
                    entity.gameLevelContinueForAd.value)
                );
            }
        }
    }
}