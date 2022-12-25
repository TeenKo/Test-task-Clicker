using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.GameLevelsLoadRule;
using UnityEngine;

namespace Core.GameLevels
{
    #region Game context

    [Game, Unique, FlagPrefix("isStatic")]
    public sealed class CurrentGameLevelComponent : IComponent
    {
    }
    
    [Game]
    public sealed class GameLevelsLoadRuleComponent : IComponent
    {
        public IGameLevelsLoadRule value;
    }
    
    [Game]
    public sealed class GameLevelCleanupComponent : IComponent
    {
    }

    [Game]
    public sealed class LevelComponent : IComponent
    {
    }
    
    #endregion


    #region Level context

    [Level, FlagPrefix("event")]
    public class CleanUpGameLevelCompletedComponent : IComponent
    {
    }

    [Level, FlagPrefix("event")]
    public class LoadNextGameLevelComponent : IComponent
    {
    }

    #endregion
    
}