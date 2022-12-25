using System.Collections.Generic;
using Entitas;

namespace GameCamera
{
    public sealed class VirtualCameraLiveReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _virtualCamerasGroup;

        public VirtualCameraLiveReactSystem(GameContext gameContext) : base(gameContext)
        {
            _virtualCamerasGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.VirtualCamera,
                GameMatcher.VirtualCameraIndex,
                GameMatcher.VirtualCameraPriority));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RequestSetVirtualCameraLive.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                var liveIndex = requestEntity.requestSetVirtualCameraLive.value;
                if (liveIndex >= _virtualCamerasGroup.GetEntities().Length) return;

                foreach (var virtualCameraEntity in _virtualCamerasGroup.GetEntities())
                {
                    var isLive = virtualCameraEntity.virtualCameraIndex.value == liveIndex;
                    virtualCameraEntity.isVirtualCameraLive = isLive;
                    virtualCameraEntity.ReplaceVirtualCameraPriority(isLive ? 1 : 0);
                }
            }
        }
    }
}