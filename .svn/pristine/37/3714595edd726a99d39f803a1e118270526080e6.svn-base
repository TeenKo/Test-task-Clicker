using Entitas;

namespace Core.ApplicationStates
{
    public sealed class ApplicationStateTransitionSystems : Systems
    {
        public ApplicationStateTransitionSystems(GameContext gameContext, LevelContext levelContext, StateContext stateContext)
        {
            Add(new ApplicationInitializeSystem(gameContext, stateContext));
            Add(new StartGameTransitionListenerSystem(stateContext, gameContext));
            Add(new VictoryTransitionListenerSystem(stateContext, gameContext));
            Add(new DefeatTransitionListenerSystem(stateContext, gameContext));
            Add(new RestartLevelTransitionListenerSystem(stateContext));
            Add(new CompleteLevelTransitionListenerSystem(stateContext, levelContext));
        }
    }

    public sealed class ApplicationInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly StateContext _stateContext;

        public ApplicationInitializeSystem(GameContext gameContext, StateContext stateContext)
        {
            _gameContext = gameContext;
            _stateContext = stateContext;
        }

        public void Initialize()
        {
            _gameContext.isStaticCurrentGame = true;
            _stateContext.isStaticAppState = true;
        }
    }
}