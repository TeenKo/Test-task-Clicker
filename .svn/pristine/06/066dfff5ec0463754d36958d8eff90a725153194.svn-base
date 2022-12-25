using Core.Configs;
using Entitas;
using Services.GameLevelsLoadRule;

namespace Core.GameLevels
{
    public sealed class InitializeGameLevelsSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;

        public InitializeGameLevelsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _gameContext.isStaticCurrentGameLevel = true;
        }

        public void Initialize()
        {
            var gameLevels = ConfigsCatalogsManager.GetConfig<GameLevelsConfig>().GameLevels;
            var currentGameLevelEntity = _gameContext.currentGameLevelEntity;
            currentGameLevelEntity.AddGameLevelsLoadRule(new RandomLoopedChainGameLevelsLoadRule(gameLevels));
        }
    }
}