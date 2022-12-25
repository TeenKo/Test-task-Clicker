using Entitas;

namespace Core.DataStorage
{    
    public sealed class DataStorageGroupSystems : Systems
    {
        public DataStorageGroupSystems(GameContext gameContext, DebugLogConfig debugLogConfig)
        {         
            Add(new LoadDataSystem(gameContext, debugLogConfig));
            Add(new SaveDataSystem(gameContext, debugLogConfig));
        }
    }   
}
