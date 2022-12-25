using Core.Common;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public sealed class JoystickInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly Joystick _joystick;
        private readonly bool _initialized;

        public JoystickInitializeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _joystick = Object.FindObjectOfType<Joystick>();
            _initialized = _joystick;
        }

        public void Initialize()
        {
            if (_initialized == false) return;

            var joystickEntity = _gameContext.CreateEntity();
            _joystick.Init(joystickEntity);

            joystickEntity.isJoystick = true;
            joystickEntity.isJoystickFloatingType = !_joystick.IsDynamic;
            joystickEntity.isJoystickDynamicType = _joystick.IsDynamic;

            joystickEntity.AddJoystickHandleRange(_joystick.HandleRange);
            joystickEntity.AddJoystickDeadZone(_joystick.DeadZone);
            joystickEntity.AddJoystickMoveThreshold(_joystick.MoveThreshold);
            joystickEntity.AddJoystickBaseRect(_joystick.GetComponent<RectTransform>());
            joystickEntity.AddJoystickCanvas(_joystick.GetComponentInParent<Canvas>());
            joystickEntity.AddJoystickBackground(_joystick.Background);
            joystickEntity.AddJoystickHandle(_joystick.Handle);
            joystickEntity.AddJoystickInput(Vector2.zero);
            joystickEntity.AddJoystickHandleAnchoredPosition(Vector2.one);
            joystickEntity.AddJoystickAxisOptions(_joystick.AxisOptions);
            joystickEntity.AddJoystickSnapX(_joystick.SnapX);
            joystickEntity.AddJoystickSnapY(_joystick.SnapY);
            joystickEntity.AddJoystickBackgroundSetActive(false);
            joystickEntity.AddJoystickHandleSetActive(false);
            joystickEntity.AddJoystickHorizontalAxis(0.5f);
            joystickEntity.AddJoystickVerticalAxis(0.5f);
            joystickEntity.AddJoystickDirection(Vector2.zero);
            joystickEntity.AddJoystickDirectionAngle(0);
            joystickEntity.AddJoystickOffsetAngle(_joystick.OffsetAngle);

            var uiCamera = Object.FindObjectOfType<UICamera>();
            joystickEntity.AddJoystickCamera(uiCamera.GetCamera);

            // listeners
            joystickEntity.AddJoystickHandleAnchoredPositionListener(_joystick);
            joystickEntity.AddJoystickBackgroundAnchoredPositionListener(_joystick);
            joystickEntity.AddJoystickHandleSetActiveListener(_joystick);
            joystickEntity.AddJoystickBackgroundSetActiveListener(_joystick);
            joystickEntity.AddJoystickOffsetAngleListener(_joystick);
        }
    }
}