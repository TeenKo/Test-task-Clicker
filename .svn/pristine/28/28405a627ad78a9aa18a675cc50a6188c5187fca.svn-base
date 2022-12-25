using Entitas;

namespace Core.Analytics
{
    public sealed class InitializeAnalyticsSystem : IInitializeSystem
    {
        private readonly IContext<AnalyticEntity> _context;

        public InitializeAnalyticsSystem(IContext<AnalyticEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            GameCore.AppFocus += focus => { _context.CreateEntity().AddApplicationFocusUnityEvent(focus); };

            GameCore.AppPause += pause => { _context.CreateEntity().AddApplicationPauseUnityEvent(pause); };
        }
    }
}