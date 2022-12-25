using System.Collections.Generic;
using Entitas;

namespace Core.Input
{
    public sealed class JoystickActivateOnGameStartReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly IGroup<GameEntity> _joystickGroup;

        public JoystickActivateOnGameStartReactSystem(StateContext stateContext, GameContext gameContext) : base(stateContext)
        {
            _joystickGroup = gameContext.GetGroup(GameMatcher.Joystick);
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Game.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            foreach (var joystickEntity in _joystickGroup.GetEntities())
            {
                joystickEntity.isJoystickActive = true;
            }
        }
    }
}