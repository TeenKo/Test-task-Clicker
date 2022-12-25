using System.Collections.Generic;
using Entitas;

namespace GameCamera
{
    public sealed class WantToGetGameRendererCameraReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _gameRendererCameraGroup;

        public WantToGetGameRendererCameraReactSystem(GameContext gameContext) : base(gameContext)
        {
            _gameRendererCameraGroup = gameContext.GetGroup(GameMatcher.GameRendererCamera);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.WantToGetGameRendererCamera.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.isWantToGetGameRendererCamera = false;
                foreach (var gameRendererEntity in _gameRendererCameraGroup.GetEntities())
                {
                    gameEntity.ReplaceGameRendererCamera(gameRendererEntity.gameRendererCamera.value);
                    break;
                }
            }
        }
    }
}