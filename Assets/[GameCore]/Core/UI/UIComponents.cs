﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.UI
{
    [Ui, Unique]
    public sealed class UIRootSchemaComponent : IComponent
    {
        public UIRootSchema value;
    }

    //Screens
    [Ui]
    public sealed class LoadScreenComponent : IComponent
    {
        
    }

    [Ui]
    public sealed class MainManuScreenComponent : IComponent
    {

    }

    [Ui]
    public sealed class GameScreenComponent : IComponent
    {

    }

    [Ui]
    public sealed class DefeatScreenComponent : IComponent
    {

    }

    [Ui]
    public sealed class VictoryScreenComponent : IComponent
    {

    }
}