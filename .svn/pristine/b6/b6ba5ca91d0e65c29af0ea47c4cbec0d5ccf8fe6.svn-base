namespace Core.Input
{
    public sealed class JoystickSystems : Feature
    {
        public JoystickSystems(GameContext gameContext, InputContext inputContext, StateContext stateContext, UiContext uiContext)
        {
            Add(new JoystickInitializeSystem(gameContext));

            Add(new JoystickTouchBeganReactSystem(inputContext, gameContext));
            Add(new JoystickTouchMovedReactSystem(inputContext, gameContext));
            Add(new JoystickTouchEndedReactSystem(inputContext, gameContext));

            Add(new JoystickRefreshAxisSystem(gameContext));

            // example: activate joystick on game start state event
            Add(new JoystickActivateOnGameStartReactSystem(stateContext, gameContext));
        }
    }
}