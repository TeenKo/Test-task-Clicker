using System.Collections.Generic;
using Entitas;

namespace Core.Input
{
    public class ButtonCompleteGameReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly StateContext _stateContext;

        public ButtonCompleteGameReactSystem(InputContext inputContext, StateContext stateContext): base (inputContext)
        {
            _stateContext = stateContext;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ButtonCompleteGame.Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _stateContext.appStateEntity.transitionCompleteLevel = true;
        }
    }
}