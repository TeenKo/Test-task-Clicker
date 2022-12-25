using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система загрузка наградной рекламы
    /// </summary>
    public sealed class RewardedLoadingSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public RewardedLoadingSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AllOf(AdvertisementMatcher.RewardedAd,
                AdvertisementMatcher.AdvertisementState, AdvertisementMatcher.LoadAdvertisement));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.NotLoad && entity.requestLoadAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _context.rewardedAdEntity.requestLoadAdvertisement = false;
            _context.rewardedAdEntity.ReplaceAdvertisementState(AdvertisementState.Loading);
            _context.service.value.CreateRewardedAd(Complete, Failed);
        }

        private void Complete()
        {
            _context.rewardedAdEntity.ReplaceAdvertisementState(AdvertisementState.Ready);
        }

        private void Failed()
        {
            _context.rewardedAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
        }
    }
}