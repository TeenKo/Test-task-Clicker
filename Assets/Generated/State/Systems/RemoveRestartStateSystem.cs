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

public sealed class RemoveRestartStateSystem : ICleanupSystem {

    readonly IGroup<StateEntity> _group;
    readonly List<StateEntity> _buffer = new List<StateEntity>();

    public RemoveRestartStateSystem(Contexts contexts) {
        _group = contexts.state.GetGroup(StateMatcher.Restart);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.transitionRestart = false;
        }
    }
}
