using System;
using Core.DataStorage;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.UserData
{
    [Game, Unique]
    public sealed class UserDataComponent : IComponent
    {
    }

    #region player game money

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataMoneyComponent : IComponent, ISavableData
    {
        public int value;

        public object GetValue => value;

        public void SetValue(object value)
        {
            this.value = Convert.ToInt32(value);
        }
    }
    
    [Game, Event(EventTarget.Self)]
    public sealed class UserDataScoreComponent : IComponent
    {
        public int value;
    }

    #endregion



    #region player game levels

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelComponent : IComponent, ISavableData
    {
        public int value;

        public object GetValue => value;

        public void SetValue(object value)
        {
            this.value = Convert.ToInt32(value);
        }
    }

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelCountComponent : IComponent, ISavableData
    {
        public int value;

        public object GetValue => value;

        public void SetValue(object value)
        {
            this.value = Convert.ToInt32(value);
        }
    }

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelLoopComponent : IComponent
    {
        public int value;
    }

    [Game]
    public sealed class UserDataGameLevelRandomComponent : IComponent
    {
    }

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelProgressComponent : IComponent
    {
        public float value;
    }

    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelStartPlayTimeComponent : IComponent
    {
        public DateTime value;
    }
    
    [Game, Event(EventTarget.Self)]
    public sealed class UserDataGameLevelPlayTimeComponent : IComponent
    {
        public int value;
    }

    #endregion
}