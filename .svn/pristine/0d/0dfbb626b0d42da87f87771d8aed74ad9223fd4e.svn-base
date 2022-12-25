#if FacebookSDK && !UNITY_EDITOR
using System;
using Facebook.Unity;

namespace Adapters.FacebookAnalytics
{
    public sealed class Facebook : IFacebookService
    {
        public void Initialize(Action complete, Action<string> failed)
        {
            if (!FB.IsInitialized)
                FB.Init(InitCallback, OnHide);
            else
                FB.ActivateApp();
            
            complete?.Invoke();
        }

        private void InitCallback()
        {
            if (FB.IsInitialized) FB.ActivateApp();
        }

        private static void OnHide(bool isGameShown)
        {
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