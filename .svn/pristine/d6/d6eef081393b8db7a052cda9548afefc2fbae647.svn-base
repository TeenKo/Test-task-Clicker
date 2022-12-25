using Adapters.AppsFlyerAnalytics;
using Entitas;

namespace Core.Analytics.AppMetrica
{
    public sealed class InitializeAppMetricaSystem : IInitializeSystem
    {
        private readonly AnalyticContext _contexts;

        internal InitializeAppMetricaSystem(AnalyticContext context)
        {
            _contexts = context;
            var appMetricaServiceEntity = _contexts.SetAppMetricaService(new Adapters.AppMetricaAnalytics.AppMetrica());
            appMetricaServiceEntity.AddAppsFlyerService(new AppsFlyer());
        }

        public void Initialize()
        {
            _contexts.appMetricaServiceEntity.appMetricaService.value.Initialize(() => { }, s => { });
        }
    }
}