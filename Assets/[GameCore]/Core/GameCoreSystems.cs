using Core.UserData;
using Entitas;
using UI;

namespace Core
{
    public sealed class GameCoreSystems : Systems
    {
        public GameCoreSystems(Contexts contexts)
        {
            var gameConfig = Configs.ConfigsCatalogsManager.GetConfig<GameConfig>();
            var debugLogConfig = Configs.ConfigsCatalogsManager.GetConfig<DebugLogConfig>();
            
            Add(new DeveloperMode.EditorInputSystem(contexts));

            #region Core systems

            Add(new UISystems(contexts.game, contexts.state, contexts.ui));
            
            Add(new DataStorage.DataStorageGroupSystems(contexts.game, debugLogConfig));

            Add(new UserDataSystems(contexts.game, contexts.state));

            Add(new ApplicationStates.ApplicationStateTransitionSystems(contexts.game, contexts.level, contexts.state));

            #endregion
            
            Add(new GameSystems(contexts, gameConfig)); // <<< add all you game system inside this systems

            #region Event and cleanup systems (comment/uncomment to on/off each system)

            Add(new GameEventSystems(contexts));
            Add(new GameCleanupSystems(contexts));

            Add(new StateEventSystems(contexts));
            Add(new StateCleanupSystems(contexts));

            Add(new UiEventSystems(contexts));
            Add(new UiCleanupSystems(contexts));

            #endregion
        }
    }
}