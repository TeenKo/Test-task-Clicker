using Adapters;
using Adapters.AppsFlyerAnalytics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Analytics
{
    #region common

    [Analytic, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class GameLevelStartComponent : IComponent
    {
    }

    [Analytic, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class GameLevelFinishComponent : IComponent
    {
    }

    // parameters send on start and finish
    [Analytic]
    public sealed class GameLevelNumberComponent : IComponent
    {
        public int value;
    }

    [Analytic]
    public sealed class GameLevelNameComponent : IComponent
    {
        public string value;
    }

    [Analytic]
    public sealed class GameLevelCountComponent : IComponent
    {
        public int value;
    }

    [Analytic]
    public sealed class GameLevelDiffComponent : IComponent
    {
        public string value;
    }

    [Analytic]
    public sealed class GameLevelLoopComponent : IComponent
    {
        public int value;
    }

    [Analytic]
    public sealed class GameLevelRandomComponent : IComponent
    {
        public bool value;
    }

    [Analytic]
    public sealed class GameLevelTypeComponent : IComponent
    {
        public string value;
    }

    [Analytic]
    public sealed class GameLevelModeComponent : IComponent
    {
        public string value;
    }

    // parameters send only on level finish
    [Analytic]
    public sealed class GameLevelResultComponent : IComponent
    {
        public string value;
    }

    [Analytic]
    public sealed class GameLevelTimeComponent : IComponent
    {
        public int value;
    }

    [Analytic]
    public sealed class GameLevelProgressComponent : IComponent
    {
        public int value;
    }

    [Analytic]
    public sealed class GameLevelContinueForAdComponent : IComponent
    {
        public int value;
    }


    // application react
    [Analytic, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class ApplicationFocusUnityEventComponent : IComponent
    {
        public bool value;
    }

    [Analytic, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class ApplicationPauseUnityEventComponent : IComponent
    {
        public bool value;
    }

    #endregion


    #region appmetrica & appsflyer

    [Analytic, Unique]
    public sealed class AppMetricaServiceComponent : IComponent
    {
        public IAnalyticsService value;
    }
    
    [Analytic]
    public sealed class AppsFlyerServiceComponent : IComponent
    {
        public IAppsFlyerService value;
    }

    [Analytic]
    public sealed class AppMetricaGameLevelStartEventComponent : IComponent
    {
        public AnalyticsConfig.EventGameLevelParameters value;
    }

    [Analytic]
    public sealed class AppMetricaGameLevelFinishEventComponent : IComponent
    {
        public AnalyticsConfig.EventGameLevelParameters value;
    }

    #endregion


    #region facebook

    [Analytic, Unique]
    public sealed class FacebookServiceComponent : IComponent
    {
        public IAnalyticsService value;
    }

    #endregion


    #region firebase

    [Analytic, Unique]
    public sealed class FirebaseServiceComponent : IComponent
    {
        public IAnalyticsService value;
    }

    [Analytic, Event(EventTarget.Self)]
    public sealed class FirebaseServiceInitializedComponent : IComponent
    {
    }

    #endregion


    #region voodoo

    [Analytic, Unique]
    public sealed class VoodooServiceComponent : IComponent
    {
        public IAnalyticsService value;
    }

    [Analytic]
    public sealed class VoodooGameLevelStartEventComponent : IComponent
    {
        public AnalyticsConfig.EventGameLevelParameters value;
    }

    [Analytic]
    public sealed class VoodooGameLevelFinishEventComponent : IComponent
    {
        public AnalyticsConfig.EventGameLevelParameters value;
    }
    
    #endregion
}