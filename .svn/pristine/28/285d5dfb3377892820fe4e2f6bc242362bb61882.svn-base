using System.Collections.Generic;
using Entitas;

namespace Core.ApplicationStates
{
    public sealed class CompleteLevelTransitionListenerSystem : ReactiveSystem<StateEntity>
    {
        private readonly LevelContext _levelContext;
        private readonly StateContext _stateContext;

        public CompleteLevelTransitionListenerSystem(StateContext stateContext, LevelContext levelContext) : base(stateContext)
        {
            _levelContext = levelContext;
            _stateContext = stateContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.CompleteLevel);
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            _levelContext.CreateEntity().eventLoadNextGameLevel = true;
            _stateContext.appStateEntity.transitionMainMenu = true;
        }
    }
}