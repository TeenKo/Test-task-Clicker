using System;
using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class UserRestartCurrentGameLevelReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly GameContext _gameContext;

        public UserRestartCurrentGameLevelReactSystem(IContext<StateEntity> context, GameContext gameContext) :
            base(context)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Restart.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            var userDataEntity = _gameContext.userDataEntity;
            var nextPlayerGameLevel = userDataEntity.userDataGameLevel.value;
            userDataEntity.ReplaceUserDataGameLevel(nextPlayerGameLevel);
            
            userDataEntity.ReplaceUserDataGameLevelPlayTime(DateTime.Now.Subtract(userDataEntity.userDataGameLevelStartPlayTime.value).Seconds);
        }
    }
}