using System.Collections.Generic;
using Entitas;

namespace Core.ApplicationStates
{
    public class RestartLevelTransitionListenerSystem : ReactiveSystem<StateEntity>
    {
        private readonly StateContext _stateContext;

        public RestartLevelTransitionListenerSystem(StateContext stateContext) : base(stateContext)
        {
            _stateContext = stateContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Restart);
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            _stateContext.appStateEntity.transitionMainMenu = true;
        }
    }
}