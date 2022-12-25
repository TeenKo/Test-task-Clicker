using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public sealed class JoystickTouchBeganReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> _joystickGroup;

        public JoystickTouchBeganReactSystem(InputContext inputContext, GameContext gameContext) : base(inputContext)
        {
            _joystickGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Joystick,
                GameMatcher.JoystickBaseRect,
                GameMatcher.JoystickCamera,
                GameMatcher.JoystickBackground,
                GameMatcher.JoystickActive));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchPhase);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.touchPhase.value == TouchPhase.Began &&
                   entity.hasTouchDownPosition;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                var inputPosition = inputEntity.touchDownPosition.value;

                foreach (var joystickEntity in _joystickGroup.GetEntities())
                {
                    var baseRect = joystickEntity.joystickBaseRect.value;
                    var camera = joystickEntity.joystickCamera.value;
                    var background = joystickEntity.joystickBackground.value;
                    var anchoredPositionBack =
                        JoystickTools.ScreenPointToAnchoredPosition(inputPosition, baseRect, camera, background);

                    joystickEntity.ReplaceJoystickInput(Vector2.zero);
                    joystickEntity.ReplaceJoystickBackgroundAnchoredPosition(anchoredPositionBack);
                    joystickEntity.ReplaceJoystickBackgroundSetActive(true);
                    joystickEntity.ReplaceJoystickHandleSetActive(true);
                    joystickEntity.ReplaceJoystickHandleAnchoredPosition(Vector2.zero);
                    joystickEntity.ReplaceJoystickViewpoint(camera.ScreenToViewportPoint(inputPosition));
                }
            }
        }
    }
}