using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система загрузка баннерной рекламы
    /// </summary>
    public sealed class BannerLoadingSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public BannerLoadingSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher
                .AllOf(AdvertisementMatcher.BannerAd, AdvertisementMatcher.AdvertisementState)
                .AnyOf(AdvertisementMatcher.BannerPositionOnBottom, AdvertisementMatcher.BannerPositionOnTop));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.NotLoad && entity.requestLoadAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _context.bannerAdEntity.requestLoadAdvertisement = false;
            _context.bannerAdEntity.ReplaceAdvertisementState(AdvertisementState.Loading);
            if (_context.bannerAdEntity.requestBannerPositionOnBottom)
                _context.serviceEntity.service.value.CreateBannerAdOnBottom(Complete, Failed);
            else if (_context.bannerAdEntity.requestBannerPositionOnTop)
                _context.serviceEntity.service.value.CreateBannerAdOnTop(Complete, Failed);
        }

        private void Complete()
        {
            _context.bannerAdEntity.ReplaceAdvertisementState(AdvertisementState.Ready);
        }

        private void Failed()
        {
            _context.bannerAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
        }
    }
}