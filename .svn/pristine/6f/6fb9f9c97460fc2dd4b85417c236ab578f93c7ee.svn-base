using Entitas;
using UnityEngine;

namespace Core.GameLevels
{
    /// <summary>
    /// Система загрузки уровней
    /// </summary>
    public sealed class CompleteLoadGameLevelSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<LevelEntity> _cleanUpGameLevelCompletedEventGroup;

        public CompleteLoadGameLevelSystem(GameContext gameContext, LevelContext levelContext)
        {
            _gameContext = gameContext;
            _cleanUpGameLevelCompletedEventGroup = levelContext.GetGroup(LevelMatcher.CleanUpGameLevelCompleted);
        }

        public void Execute()
        {
            foreach (var levelEntity in _cleanUpGameLevelCompletedEventGroup.GetEntities())
            {
                var currentGameLevel = _gameContext.userDataEntity.userDataGameLevel.value;
                var nextLevelSchema = _gameContext.currentGameLevelEntity.gameLevelsLoadRule.value.GetNextLevel(currentGameLevel, out var levelIndex);

                var gameEntity = _gameContext.CreateEntity();
                var levelSchema = Object.Instantiate(nextLevelSchema);
                levelSchema.GameObjectName = nextLevelSchema.GameObjectName;
                levelSchema.Init(gameEntity);

                levelEntity.Destroy();
            }
        }
    }
}