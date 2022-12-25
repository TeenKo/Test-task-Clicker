using System.Collections.Generic;
using Entitas;

namespace Core.UserData
{
    public sealed class UserDataLoadFailedSystem : ReactiveSystem<GameEntity>
    {
        public UserDataLoadFailedSystem(GameContext gameContext) : base(gameContext)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LoadingDataFailed);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isUserData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var userDataEntity in entities)
            {
                userDataEntity.systemTriggerSaveData = true;
                userDataEntity.systemTriggerLoadingDataSuccessful = true;
            }
        }
    }
}