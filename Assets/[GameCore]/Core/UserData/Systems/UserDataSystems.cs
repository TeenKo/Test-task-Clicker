using Entitas;

namespace Core.UserData
{
    public sealed class UserDataSystems : Systems
    {
        public UserDataSystems(GameContext gameContext, StateContext stateContext)
        {
            Add(new UserDataInitializeSystem(gameContext));
            Add(new UserDataLoadFailedSystem(gameContext));
            Add(new UserDataLoadCompleteSystem(gameContext, stateContext));

            Add(new UserFailedTheGameLevelReactSystem(stateContext, gameContext));
            Add(new UserRestartCurrentGameLevelReactSystem(stateContext, gameContext));
        }
    }
}