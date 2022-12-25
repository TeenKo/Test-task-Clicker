#if !FirebaseSDK || UNITY_EDITOR
using System;

namespace Adapters.FirebaseAnalytics
{
    public sealed class Firebase : IFirebaseService
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