using System.Collections.Generic;
using Entitas;

namespace Core.Input
{
    public class ButtonRestartGameReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly StateContext _stateContext;
        private readonly LevelContext _levelContext;

        public ButtonRestartGameReactSystem(InputContext inputContext,LevelContext levelContext, StateContext stateContext): base (inputContext)
        {
            _stateContext = stateContext;
            _levelContext = levelContext;
        }
        
        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ButtonRestartGame.Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _levelContext.CreateEntity().eventLoadNextGameLevel = true;
            _stateContext.appStateEntity.transitionRestart = true;
        }
    }
}