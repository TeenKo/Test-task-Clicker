using System.Collections.Generic;
using Entitas;

namespace UI
{
    public sealed class UIPlayerMoneyValueReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<UiEntity> _uiPlayerMoneyGroup;

        public UIPlayerMoneyValueReactSystem(GameContext gameContext, UiContext uiContext) : base(gameContext)
        {
            _uiPlayerMoneyGroup = uiContext.GetGroup(UiMatcher.UIPlayerMoney);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.UserDataMoney);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isUserData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var playerDataEntity in entities)
            {
                var playerMoneyValue = playerDataEntity.userDataMoney.value;

                foreach (var uiPlayerMoneyEntity in _uiPlayerMoneyGroup.GetEntities())
                {
                    uiPlayerMoneyEntity.ReplaceUIPlayerMoneyValue(playerMoneyValue);
                }
            }
        }
    }
}