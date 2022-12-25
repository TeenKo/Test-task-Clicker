using System.Collections.Generic;
using Entitas;

namespace Core.Analytics.Firebase
{
    /// <summary>
    /// Система инициализации сервиса
    /// </summary>
    public sealed class InitializeFirebaseSystem : IInitializeSystem
    {
        private readonly AnalyticContext _analyticContext;

        public InitializeFirebaseSystem(AnalyticContext analyticContext)
        {
            _analyticContext = analyticContext;
            _analyticContext?.SetFirebaseService(new Adapters.FirebaseAnalytics.Firebase());
        }

        public void Initialize()
        {
            _analyticContext.firebaseServiceEntity.firebaseService.value.Initialize(Complete, Failed);
        }

        private void Complete()
        {
            _analyticContext.firebaseServiceEntity.isFirebaseServiceInitialized = true;
        }

        private void Failed(string reason)
        {
            Dbg.LogWarning("Firebase service initialized failed!");
        }
    }
    
    /// <summary>
    /// Система обработки инициализации сервиса
    /// </summary>
    public sealed class InitializingFirebaseCompleteSystem : ReactiveSystem<AnalyticEntity>
    {
        private readonly AnalyticContext _analyticContext;

        public InitializingFirebaseCompleteSystem(AnalyticContext analyticContext) : base(analyticContext)
        {
            _analyticContext = analyticContext;
        }

        protected override ICollector<AnalyticEntity> GetTrigger(IContext<AnalyticEntity> context)
        {
            return context.CreateCollector(AnalyticMatcher.FirebaseServiceInitialized);
        }

        protected override bool Filter(AnalyticEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AnalyticEntity> entities)
        {
            // auto load ads when service was initialized
        }
    }
}