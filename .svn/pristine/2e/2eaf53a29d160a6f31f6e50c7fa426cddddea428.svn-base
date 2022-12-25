using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public sealed class JoystickTouchMovedReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> _joystickGroup;

        public JoystickTouchMovedReactSystem(InputContext inputContext, GameContext gameContext) : base(inputContext)
        {
            _joystickGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Joystick,
                GameMatcher.JoystickBackground,
                GameMatcher.JoystickCanvas,
                GameMatcher.JoystickAxisOptions,
                GameMatcher.JoystickHandleRange,
                GameMatcher.JoystickDeadZone,
                GameMatcher.JoystickCamera,
                GameMatcher.JoystickMoveThreshold,
                GameMatcher.JoystickActive));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchMovePosition);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasTouchPhase &&
                   entity.touchPhase.value == TouchPhase.Moved;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                var inputPosition = inputEntity.touchMovePosition.value;

                foreach (var joystickEntity in _joystickGroup.GetEntities())
                {
                    var background = joystickEntity.joystickBackground.value;
                    var scaleFactor = joystickEntity.joystickCanvas.value.scaleFactor;
                    var axisOptions = joystickEntity.joystickAxisOptions.value;
                    var handleRange = joystickEntity.joystickHandleRange.value;
                    var deadZone = joystickEntity.joystickDeadZone.value;
                    var camera = joystickEntity.joystickCamera.value;

                    var position = RectTransformUtility.WorldToScreenPoint(camera, background.position);
                    var radius = background.sizeDelta / 2;
                    var input = (inputPosition - position) / (radius * scaleFactor);
                    JoystickTools.FormatInput(axisOptions, ref input);
                    if (joystickEntity.isJoystickDynamicType)
                    {
                        var moveThreshold = joystickEntity.joystickMoveThreshold.value;
                        if (input.magnitude > moveThreshold)
                        {
                            var difference = input.normalized * (input.magnitude - moveThreshold) * radius;
                            background.anchoredPosition += difference;
                        }
                    }

                    JoystickTools.HandleInput(input.magnitude, input.normalized, deadZone, ref input);
                    var anchoredPosition = input * radius * handleRange;

                    joystickEntity.ReplaceJoystickInput(input);
                    joystickEntity.ReplaceJoystickHandleAnchoredPosition(anchoredPosition);
                    joystickEntity.ReplaceJoystickViewpoint(camera.ScreenToViewportPoint(inputPosition));
                }
            }
        }
    }
}