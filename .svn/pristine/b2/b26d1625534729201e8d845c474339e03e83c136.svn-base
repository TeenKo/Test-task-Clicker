using Entitas;
using UnityEngine;

namespace GameCamera
{
    public sealed class CalculateXAxisAngleFromCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camerasGroup;
        private readonly IGroup<GameEntity> _elementsGroup;

        public CalculateXAxisAngleFromCameraSystem(GameContext gameContext)
        {
            _camerasGroup = gameContext.GetGroup(GameMatcher.GameRendererCamera);
            _elementsGroup = gameContext.GetGroup(GameMatcher.XAxisRotation);
        }

        public void Execute()
        {
            foreach (var cameraEntity in _camerasGroup.GetEntities())
            {
                cameraEntity.gameRendererCamera.value.transform.rotation.ToAngleAxis(out var angle, out var _);
                var rotation = Quaternion.AngleAxis(angle, Vector3.right);
                foreach (var elementEntity in _elementsGroup.GetEntities())
                {
                    elementEntity.ReplaceXAxisRotation(rotation);
                }
            }
        }
    }
}