using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.ApplicationStates
{
    [State, Unique, FlagPrefix("isStatic")]
    public sealed class AppStateComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class LoadingComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class MainMenuComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class GameComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class VictoryComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class DefeatComponent : IComponent
    {
    }

    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class RestartComponent : IComponent
    {
    }
    
    [State, FlagPrefix("transition"), Event(EventTarget.Any), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class CompleteLevelComponent : IComponent
    {
    }
}