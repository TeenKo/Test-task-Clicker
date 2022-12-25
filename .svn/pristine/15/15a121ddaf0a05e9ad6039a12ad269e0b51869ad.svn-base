#if !FacebookSDK || UNITY_EDITOR
using System;

namespace Adapters.FacebookAnalytics
{
    public sealed class Facebook : IFacebookService
    {
        public void Initialize(Action complete, Action<string> failed)
        {
            complete?.Invoke();
        }

        public void ApplicationOnFocus(bool focus)
        {
        }

        public void ApplicationOnPause(bool pause)
        {
        }

        public void GameLevelStart(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
        }

        public void GameLevelFinish(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
        }
    }
}
#endif