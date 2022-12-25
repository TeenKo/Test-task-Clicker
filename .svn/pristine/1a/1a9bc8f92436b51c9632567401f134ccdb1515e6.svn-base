namespace Core.Input
{
    public sealed class UIButtonsInputSystems : Entitas.Systems
    {
        public UIButtonsInputSystems(InputContext inputContext, LevelContext levelContext, StateContext stateContext)
        {
            Add(new ButtonOpenMainMenuReactSystem(inputContext, stateContext));
            Add(new ButtonStartGameReactSystem(inputContext, stateContext));
            Add(new ButtonRestartGameReactSystem(inputContext, levelContext, stateContext));
            Add(new ButtonCompleteGameReactSystem(inputContext, stateContext));
        }
    }
}