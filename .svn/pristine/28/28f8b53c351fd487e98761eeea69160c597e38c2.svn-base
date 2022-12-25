#if AppMetrica && !UNITY_EDITOR
using Core.Configs;

namespace Adapters.AppsFlyerAnalytics
{
    public sealed class AppsFlyer : IAppsFlyerService
    {
        public AppsFlyer()
        {
            var config = ConfigsCatalogsManager.GetConfig<AppsFlyerConfig>();
            AppsFlyerSDK.AppsFlyer.setIsDebug(config.IsDebug);
            AppsFlyerSDK.AppsFlyer.initSDK(config.DevKey, config.AppID, null);
            AppsFlyerSDK.AppsFlyer.startSDK();
        }
    }
}
#endif

