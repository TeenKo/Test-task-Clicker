using System.Collections.Generic;
using Entitas;

namespace Core.ApplicationStates
{
    /// <summary>
    /// Система отработки состояния победа в игре
    /// </summary>
    public sealed class VictoryTransitionListenerSystem : ReactiveSystem<StateEntity>
    {
        private readonly GameContext _gameContext;

        public VictoryTransitionListenerSystem(StateContext stateContext, GameContext gameContext) : base(stateContext)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Victory);
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            _gameContext.currentGameEntity.isGameStarted = false;
        }
    }
}