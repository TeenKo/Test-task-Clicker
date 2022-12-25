using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace GameCamera
{
    #region game renderer camera

    [Game]
    public sealed class GameCameraComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public sealed class GameRendererCameraComponent : IComponent
    {
        public Camera value;
    }

    #endregion
    
    #region virtual camera

    [Game]
    public sealed class VirtualCameraComponent : IComponent
    {
    }

    [Game]
    public sealed class VirtualCameraLiveComponent : IComponent
    {
    }

    [Game]
    public sealed class VirtualCameraIndexComponent : IComponent
    {
        public int value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class VirtualCameraPriorityComponent : IComponent
    {
        public int value;
    }

    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class VirtualCameraTargetComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public sealed class VirtualCameraFollowTargetComponent : IComponent
    {
        public Transform value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class VirtualCameraLookAtTargetComponent : IComponent
    {
        public Transform value;
    }

    [Game, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestSetVirtualCameraLiveComponent : IComponent
    {
        public int value;
    }

    #endregion

    #region misc

    [Game]
    public sealed class WantToGetGameRendererCameraComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public sealed class XAxisRotationComponent : IComponent
    {
        public Quaternion value;
    }

    #endregion
}