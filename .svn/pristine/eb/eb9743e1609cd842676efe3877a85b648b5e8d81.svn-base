using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.DataStorage
{
    [Game]
    public sealed class DataKeyComponent : IComponent
    {
        public string value;
    }

    [Game, FlagPrefix("SystemTrigger"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class LoadData : IComponent
    {
    }

    [Game, FlagPrefix("SystemTrigger"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SaveData : IComponent
    {
    }

    [Game, FlagPrefix("SystemTrigger"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class LoadingDataFailed : IComponent
    {
    }

    [Game, FlagPrefix("SystemTrigger"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class LoadingDataSuccessful : IComponent
    {
    }
}