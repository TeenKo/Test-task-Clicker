using System.Collections.Generic;
using Entitas;

namespace UI
{
    public sealed class UIPlayerMoneyShowReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly IGroup<UiEntity> _uiPlayerMoneyGroup;

        public UIPlayerMoneyShowReactSystem(StateContext stateContext, UiContext uiContext) : base(stateContext)
        {
            _uiPlayerMoneyGroup = uiContext.GetGroup(UiMatcher.AllOf(
                UiMatcher.UIPlayerMoney));
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.AnyOf(
                StateMatcher.MainMenu,
                StateMatcher.Game).Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            foreach (var uiPlayerMoneyEntity in _uiPlayerMoneyGroup.GetEntities())
            {
                uiPlayerMoneyEntity.isUIPlayerMoneyShow = true;
            }
        }
    }
}