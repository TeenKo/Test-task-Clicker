namespace UI
{
    public sealed class UIPlayerMoneySystems : Entitas.Systems
    {
        public UIPlayerMoneySystems(GameContext gameContext, StateContext stateContext, UiContext uiContext)
        {
            Add(new UIPlayerMoneyShowReactSystem(stateContext, uiContext));
            Add(new UIPlayerMoneyHideReactSystem(stateContext, uiContext));
            Add(new UIPlayerMoneyValueReactSystem(gameContext, uiContext));
        }
    }
}