using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public sealed class JoystickTouchEndedReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> _joystickGroup;

        public JoystickTouchEndedReactSystem(InputContext inputContext, GameContext gameContext) : base(inputContext)
        {
            _joystickGroup = gameContext.GetGroup(GameMatcher.Joystick);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchPhase);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.touchPhase.value == TouchPhase.Ended;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var joystickEntity in _joystickGroup.GetEntities())
            {
                joystickEntity.ReplaceJoystickBackgroundSetActive(false);
                joystickEntity.ReplaceJoystickHandleSetActive(false);
                joystickEntity.ReplaceJoystickInput(Vector2.zero);
                joystickEntity.ReplaceJoystickHandleAnchoredPosition(Vector2.zero);
            }
        }
    }
}