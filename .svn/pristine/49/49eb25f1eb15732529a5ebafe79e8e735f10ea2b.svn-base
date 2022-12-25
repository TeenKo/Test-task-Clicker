using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система обработки запросов на показ наградной рекламы
    /// </summary>
    public sealed class RewardedShowSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _advertisementContext;
        private readonly IGroup<GameEntity> _advertisementElementsGroup;

        public RewardedShowSystem(AdvertisementContext advertisementContext, GameContext gameContext) : base(advertisementContext)
        {
            _advertisementContext = advertisementContext;
            _advertisementElementsGroup = gameContext.GetGroup(GameMatcher.AdsGameShowRequest);
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AllOf(AdvertisementMatcher.RewardedAd,
                AdvertisementMatcher.AdvertisementState, AdvertisementMatcher.ShowAdvertisement));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.Ready && entity.requestShowAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _advertisementContext.rewardedAdEntity.requestShowAdvertisement = false;
            _advertisementContext.service.value.ShowRewardedAd(Complete);
        }

        private void Complete(bool value)
        {
            foreach (var gameEntity in _advertisementElementsGroup.GetEntities())
            {
                gameEntity.ReplaceAdsRewardResult(value);
                gameEntity.isAdsGameShowRequest = false;
            }

            _advertisementContext.rewardedAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
            _advertisementContext.rewardedAdEntity.requestLoadAdvertisement = true;
        }
    }
}