using Entitas;

namespace Core.GameLevels
{
    internal class StartLoadGameLevelSystem : IExecuteSystem
    {
        private readonly LevelContext _levelContexts;
        private readonly IGroup<LevelEntity> _loadLevelGroup;
        private readonly IGroup<GameEntity> _levelCleanupGroup;

        public StartLoadGameLevelSystem(GameContext gameContext, LevelContext levelContext)
        {
            _levelContexts = levelContext;

            _loadLevelGroup = levelContext.GetGroup(LevelMatcher.LoadNextGameLevel);
            _levelCleanupGroup = gameContext.GetGroup(GameMatcher.GameLevelCleanup);
        }

        public void Execute()
        {
            foreach (var levelEntity in _loadLevelGroup.GetEntities())
            {
                CleanUp();

                _levelContexts.CreateEntity().eventCleanUpGameLevelCompleted = true;
                levelEntity.Destroy();
            }
        }

        private void CleanUp()
        {
            foreach (var gameEntity in _levelCleanupGroup.GetEntities())
            {
                gameEntity.Destroy();
            }
        }
    }
}