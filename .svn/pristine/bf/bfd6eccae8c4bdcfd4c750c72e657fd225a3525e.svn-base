using System.Collections.Generic;
using Entitas;

namespace Core.Analytics.AppMetrica
{
    public sealed class AppMetricaApplicationOnPauseReactSystem : ReactiveSystem<AnalyticEntity>
    {
        private readonly AnalyticContext _analyticContext;

        public AppMetricaApplicationOnPauseReactSystem(AnalyticContext analyticContext) : base(analyticContext)
        {
            _analyticContext = analyticContext;
        }

        protected override ICollector<AnalyticEntity> GetTrigger(IContext<AnalyticEntity> context)
        {
            return context.CreateCollector(AnalyticMatcher.ApplicationPauseUnityEvent.Added());
        }

        protected override bool Filter(AnalyticEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AnalyticEntity> entities)
        {
            foreach (var entity in entities)
            {
                _analyticContext.appMetricaService.value.ApplicationOnPause(entity.applicationPauseUnityEvent.value);
            }
        }
    }
}