#if CINEMACHINE
using Cinemachine;
using Core.Extension;
using Entitas;
using UnityEngine;

namespace GameCamera
{
    public sealed class VirtualCameraView : MonoBehAdvGame, IVirtualCameraPriorityListener,
        IVirtualCameraFollowTargetListener, IVirtualCameraLookAtTargetListener
    {
        private CinemachineVirtualCamera _virtualCamera;

        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public void OnVirtualCameraPriority(GameEntity entity, int value)
        {
            _virtualCamera.m_Priority = value;
        }

        public void OnVirtualCameraFollowTarget(GameEntity entity, Transform value)
        {
            _virtualCamera.m_Follow = value;
        }

        public void OnVirtualCameraLookAtTarget(GameEntity entity, Transform value)
        {
            _virtualCamera.m_LookAt = value;
        }
    }
}
#endif