using Core.Extension;
using Core.GameLevels;
using UnityEngine;

namespace GameCamera
{
    public sealed class GameCameraView : MonoBehAdvGame
    {
        [SerializeField] private Camera gameRendererCamera;
        [SerializeField] private bool isCleanupOnLevelDestroy;
        public static Camera MainCamera { get; private set; }

#if CINEMACHINE
        [SerializeField] private VirtualCameraView[] virtualCameras;
#endif

        private void Awake()
        {
            MainCamera = gameRendererCamera;
        }

        private void Start()
        {
            var gameContext = Contexts.sharedInstance.game;
            var gameCameraEntity = gameContext.CreateEntity();
            Init(gameCameraEntity);
            gameCameraEntity.isGameCamera = true;
            if (isCleanupOnLevelDestroy) GameEntity.isGameLevelCleanup = true;
            
            gameCameraEntity.AddGameRendererCamera(MainCamera);

            CreateVirtualCameras(gameContext);
        }

#if CINEMACHINE
        private void CreateVirtualCameras(GameContext gameContext)
        {
            var index = 0;
            foreach (var virtualCamera in virtualCameras)
            {
                var virtualCameraEntity = gameContext.CreateEntity();
                virtualCamera.Init(virtualCameraEntity);

                virtualCameraEntity.isVirtualCamera = true;
                virtualCameraEntity.AddVirtualCameraIndex(index);
                virtualCameraEntity.AddVirtualCameraPriority(index == 0 ? 1 : 0);

                virtualCameraEntity.AddVirtualCameraPriorityListener(virtualCamera);
                virtualCameraEntity.AddVirtualCameraFollowTargetListener(virtualCamera);
                virtualCameraEntity.AddVirtualCameraLookAtTargetListener(virtualCamera);
                index++;
            }
        }
#else
        private void CreateVirtualCameras(GameContext gameContext) { }
#endif


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (transform.parent && transform.parent.TryGetComponent(out LevelSchema levelSchema))
                isCleanupOnLevelDestroy = true;
        }

        private void Reset()
        {
            if (gameRendererCamera) return;
            if (TryGetComponent(out Camera cameraComponent))
                gameRendererCamera = cameraComponent;
        }
#endif
    }
}