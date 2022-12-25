using System.Collections.Generic;
using Entitas;

namespace GameCamera
{
    public sealed class VirtualCameraSetTargetReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _virtualCamerasGroup;

        public VirtualCameraSetTargetReactSystem(GameContext gameContext) : base(gameContext)
        {
            _virtualCamerasGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.VirtualCamera,
                GameMatcher.VirtualCameraIndex));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.VirtualCameraTarget.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTransform;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var target = gameEntity.transform.value;
                foreach (var virtualCameraEntity in _virtualCamerasGroup.GetEntities())
                {
                    if (virtualCameraEntity.virtualCameraIndex.value != 0) continue;

                    virtualCameraEntity.ReplaceVirtualCameraFollowTarget(target);
                    virtualCameraEntity.ReplaceVirtualCameraLookAtTarget(target);
                    break;
                }

                return;
            }
        }
    }
}