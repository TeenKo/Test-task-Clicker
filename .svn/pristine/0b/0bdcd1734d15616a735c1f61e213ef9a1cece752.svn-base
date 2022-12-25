using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class UserDataLoadCompleteSystem : ReactiveSystem<GameEntity>
    {
        private readonly StateContext _stateContext;

        public UserDataLoadCompleteSystem(GameContext gameContext, StateContext stateContext) : base(gameContext)
        {
            _stateContext = stateContext;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LoadingDataSuccessful);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isUserData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _stateContext.appStateEntity.transitionMainMenu = true;          
        }
    }
}