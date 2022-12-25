using System.Collections.Generic;
using Entitas;

namespace Core.Input
{
    public class ButtonStartGameReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly StateContext _stateContext;

        public ButtonStartGameReactSystem(InputContext inputContext, StateContext stateContext): base (inputContext)
        {
            _stateContext = stateContext;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ButtonStartGame);
        }
        
        
        protected override bool Filter(InputEntity entity)
        {
            return true;
        }
        
        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var e in entities)
            {
                _stateContext.appStateEntity.transitionGame = true;
            }
        }
    }
}