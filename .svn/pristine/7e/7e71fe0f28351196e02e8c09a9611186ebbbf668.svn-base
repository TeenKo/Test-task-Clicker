using System;
using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class StartPlayGameLevelReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public StartPlayGameLevelReactSystem(GameContext context) : base(context)
        {
            _gameContext = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameStarted.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var userDataEntity = _gameContext.userDataEntity;
            var value = userDataEntity.userDataGameLevelCount.value + 1;
            value = value + 1 >= int.MaxValue ? 0 : value;
            userDataEntity.ReplaceUserDataGameLevelCount(value);
            userDataEntity.ReplaceUserDataGameLevelStartPlayTime(DateTime.Now);
            userDataEntity.ReplaceUserDataGameLevelProgress(0);
            userDataEntity.systemTriggerSaveData = true;
        }
    }
}