namespace GameCamera
{
    public sealed class GameCameraSystems : Feature
    {
        public GameCameraSystems(GameContext gameContext)
        {
            Add(new VirtualCameraSetTargetReactSystem(gameContext));

            Add(new CalculateXAxisAngleFromCameraSystem(gameContext));
            Add(new WantToGetGameRendererCameraReactSystem(gameContext));

            Add(new VirtualCameraLiveReactSystem(gameContext));
        }
    }
}