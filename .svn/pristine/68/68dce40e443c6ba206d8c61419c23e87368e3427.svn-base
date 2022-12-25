using Entitas;
using UnityEngine;

namespace Core.Analytics.Facebook
{
    /// <summary>
    /// Система инициализации сервиса
    /// </summary>
    public sealed class InitializeFacebookSystem : IInitializeSystem
    {
        private readonly AnalyticContext _analyticContext;

        public InitializeFacebookSystem(AnalyticContext analyticContext)
        {
            _analyticContext = analyticContext;
            _analyticContext?.SetFacebookService(new Adapters.FacebookAnalytics.Facebook());
        }

        public void Initialize()
        {
            _analyticContext.facebookService.value.Initialize(() => { }, s =>
                {
                    // Debug.Log($"InitializeFacebookSystem failed. Reason: {s}");
                }
            );
        }
    }
}