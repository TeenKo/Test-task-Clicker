using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Core.Input
{
    [Game]
    public sealed class JoystickComponent : IComponent
    {
    }

    [Game]
    public sealed class JoystickFloatingTypeComponent : IComponent
    {
    }
    
    [Game]
    public sealed class JoystickDynamicTypeComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickInputComponent : IComponent
    {
        public Vector2 value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickHandleRangeComponent : IComponent
    {
        public float value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickDeadZoneComponent : IComponent
    {
        public float value;
    }
    
    [Game, Event(EventTarget.Self)]
    public sealed class JoystickMoveThresholdComponent : IComponent
    {
        public float value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickAxisOptionsComponent : IComponent
    {
        public AxisOptions value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickSnapXComponent : IComponent
    {
        public bool value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickSnapYComponent : IComponent
    {
        public bool value;
    }

    [Game]
    public sealed class JoystickBaseRectComponent : IComponent
    {
        public RectTransform value;
    }

    [Game]
    public sealed class JoystickCanvasComponent : IComponent
    {
        public Canvas value;
    }


    [Game]
    public sealed class JoystickCameraComponent : IComponent
    {
        public Camera value;
    }

    [Game]
    public sealed class JoystickActiveComponent : IComponent
    {
    }

    #region Joystick background & handle

    [Game]
    public sealed class JoystickBackgroundComponent : IComponent
    {
        public RectTransform value;
    }


    [Game]
    public sealed class JoystickHandleComponent : IComponent
    {
        public RectTransform value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickBackgroundAnchoredPositionComponent : IComponent
    {
        public Vector2 value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickHandleAnchoredPositionComponent : IComponent
    {
        public Vector2 value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickBackgroundSetActiveComponent : IComponent
    {
        public bool value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickHandleSetActiveComponent : IComponent
    {
        public bool value;
    }

    #endregion


    #region gamepad axis

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickHorizontalAxisComponent : IComponent
    {
        public float value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickVerticalAxisComponent : IComponent
    {
        public float value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickDirectionComponent : IComponent
    {
        public Vector2 value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickViewpointComponent : IComponent
    {
        public Vector2 value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class JoystickDirectionAngleComponent : IComponent
    {
        public float value;
    }
    
    [Game, Event(EventTarget.Self)]
    public sealed class JoystickOffsetAngleComponent : IComponent
    {
        public float value;
    }

    #endregion
}