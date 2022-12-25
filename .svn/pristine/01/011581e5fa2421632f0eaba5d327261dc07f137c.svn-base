using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public sealed class JoystickRefreshAxisSystem : ReactiveSystem<GameEntity>
    {
        public JoystickRefreshAxisSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.JoystickInput);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isJoystick &&
                   entity.hasJoystickInput &&
                   entity.hasJoystickAxisOptions &&
                   entity.hasJoystickSnapX &&
                   entity.hasJoystickSnapY;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var joystickEntity in entities)
            {
                var input = joystickEntity.joystickInput.value;
                var axisOptions = joystickEntity.joystickAxisOptions.value;
                var snapX = joystickEntity.joystickSnapX.value;
                var snapY = joystickEntity.joystickSnapY.value;

                var horizontal = snapX ? JoystickTools.SnapFloat(input.x, input, axisOptions, AxisOptions.Horizontal) : input.x;
                var vertical = snapY ? JoystickTools.SnapFloat(input.y, input, axisOptions, AxisOptions.Vertical) : input.y;
                var direction = new Vector2(horizontal, vertical);
                var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + joystickEntity.joystickOffsetAngle.value;

                joystickEntity.ReplaceJoystickHorizontalAxis(horizontal);
                joystickEntity.ReplaceJoystickVerticalAxis(vertical);
                joystickEntity.ReplaceJoystickDirection(direction);
                joystickEntity.ReplaceJoystickDirectionAngle(angle);
            }
        }
    }
}