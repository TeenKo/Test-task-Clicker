//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Entitas;

public sealed class RemoveUILoadingDataSuccessfulUiSystem : ICleanupSystem {

    readonly IGroup<UiEntity> _group;
    readonly List<UiEntity> _buffer = new List<UiEntity>();

    public RemoveUILoadingDataSuccessfulUiSystem(Contexts contexts) {
        _group = contexts.ui.GetGroup(UiMatcher.UILoadingDataSuccessful);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.systemTriggerUILoadingDataSuccessful = false;
        }
    }
}
