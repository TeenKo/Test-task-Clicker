using System;
using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class UserWonTheGameReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly GameContext _gameContext;

        public UserWonTheGameReactSystem(IContext<StateEntity> context, GameContext gameContext) : base(context)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Victory.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            var userDataEntity = _gameContext.userDataEntity;
            var nextPlayerGameLevel = userDataEntity.userDataGameLevel.value + 1;
            userDataEntity.ReplaceUserDataGameLevel(nextPlayerGameLevel);
            
            userDataEntity.ReplaceUserDataGameLevelPlayTime(DateTime.Now.Subtract(userDataEntity.userDataGameLevelStartPlayTime.value).Seconds);
            userDataEntity.systemTriggerSaveData = true;
        }
    }
}