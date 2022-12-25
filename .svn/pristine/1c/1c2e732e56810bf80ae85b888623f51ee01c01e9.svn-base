namespace Core.Analytics
{
    public sealed class AnalyticSystems : Entitas.Systems
    {
        public AnalyticSystems(AnalyticContext analyticContext, GameContext gameContext, StateContext stateContext)
        {
            // common analytics systems
            Add(new InitializeAnalyticsSystem(analyticContext));
            Add(new GameLevelStartReactSystem(analyticContext, gameContext, stateContext));
            Add(new GameLevelFinishWithWinReactSystem(analyticContext, gameContext, stateContext));
            // Add(new GameLevelFinishWithLooseReactSystem(analyticContext, gameContext, stateContext));

#if AppMetrica
            Add(new AppMetrica.InitializeAppMetricaSystem(analyticContext));
            Add(new AppMetrica.AppMetricaGameLevelStartReactSystem(analyticContext));
            Add(new AppMetrica.AppMetricaGameLevelFinishReactSystem(analyticContext));
            Add(new AppMetrica.AppMetricaApplicationOnPauseReactSystem(analyticContext));
#endif

#if FacebookSDK
            Add(new Facebook.InitializeFacebookSystem(analyticContext));
#endif
            
#if FirebaseSDK
            Add(new Firebase.InitializeFirebaseSystem(analyticContext));
            Add(new Firebase.InitializingFirebaseCompleteSystem(analyticContext));
#endif

#if VoodooSDK
            Add(new Voodoo.InitializeVoodooSystem(analyticContext));
            Add(new Voodoo.VoodooGameLevelStartReactSystem(analyticContext));
            Add(new Voodoo.VoodooGameLevelFinishReactSystem(analyticContext));
#endif
        }
    }
}