using Entitas;
using UnityEngine;

namespace Core.Analytics.Voodoo
{
    public sealed class InitializeVoodooSystem : IInitializeSystem
    {
        private readonly AnalyticContext _analyticContext;

        public InitializeVoodooSystem(AnalyticContext analyticContext)
        {
            _analyticContext = analyticContext;
            _analyticContext.SetVoodooService(new Adapters.VoodooAnalytics.Voodoo());
        }

        public void Initialize()
        {
            _analyticContext.voodooService.value.Initialize(
                () =>
                {
                    // Debug.Log("InitializeVoodooSystem successful");
                },
                s =>
                {
                    // Debug.Log($"InitializeVoodooSystem failed. Reason {s}");
                });
        }
    }
}