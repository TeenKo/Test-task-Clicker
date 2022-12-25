using System;
using Adapters;

namespace Core.Analytics
{
    public interface IAnalyticsService
    {
        void Initialize(Action complete, Action<string> failed);
        void ApplicationOnFocus(bool focus);
        void ApplicationOnPause(bool pause);
        void GameLevelStart(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters);
        void GameLevelFinish(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters);
    }
}