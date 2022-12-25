using Entitas;

namespace Core.UserData
{
    public sealed class UserDataInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        
        public UserDataInitializeSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _gameContext.isUserData = true;
        }
        
        public void Initialize()
        {
            var userDataEntity = _gameContext.userDataEntity;
            userDataEntity.AddDataKey(GameConfig.PlayerDataKey);
            // money and score
            userDataEntity.AddUserDataMoney(0); // savable
            // game levels
            userDataEntity.AddUserDataGameLevel(0); // savable
            userDataEntity.AddUserDataGameLevelCount(0); // savable
            userDataEntity.AddUserDataGameLevelLoop(1);
            userDataEntity.AddUserDataGameLevelProgress(0);
            userDataEntity.AddUserDataGameLevelPlayTime(0);
            userDataEntity.systemTriggerLoadData = true;
        }
    }
}