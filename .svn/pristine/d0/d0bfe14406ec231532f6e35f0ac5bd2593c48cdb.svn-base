using System;
using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class UserFailedTheGameLevelReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly GameContext _gameContext;

        public UserFailedTheGameLevelReactSystem(IContext<StateEntity> context, GameContext gameContext) :
            base(context)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Defeat.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            var userDataEntity = _gameContext.userDataEntity;
            // var nextPlayerGameLevel = currentPlayerDataEntity.playerCurrentGameLevel.value;
            // currentPlayerDataEntity.ReplacePlayerCurrentGameLevel(nextPlayerGameLevel);
            
            userDataEntity.ReplaceUserDataGameLevelPlayTime(DateTime.Now.Subtract(userDataEntity.userDataGameLevelStartPlayTime.value).Seconds);
        }
    }
}