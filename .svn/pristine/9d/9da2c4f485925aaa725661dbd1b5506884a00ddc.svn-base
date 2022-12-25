using Entitas;

namespace Core.GameLevels
{
    public sealed class GameLevelsSystems : Systems
    {
        public GameLevelsSystems(GameContext gameContext, LevelContext levelContext)
        {
            Add(new InitializeGameLevelsSystem(gameContext));
            Add(new CompleteLoadGameLevelSystem(gameContext, levelContext));
            Add(new StartLoadGameLevelSystem(gameContext, levelContext));
        }
    }
}