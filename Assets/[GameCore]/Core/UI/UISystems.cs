using Entitas;

namespace UI
{
    public sealed class UISystems : Systems
    {
        public UISystems(GameContext gameContext, StateContext stateContext, UiContext uiContext)
        {
            Add(new UIRootSchemaInitializeSystem(uiContext));
        }
    }
}