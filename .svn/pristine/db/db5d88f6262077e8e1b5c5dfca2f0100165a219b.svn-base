using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система обработки запросов на показ баннера
    /// </summary>
    public sealed class BannerShowSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public BannerShowSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AllOf(
                AdvertisementMatcher.BannerAd,
                AdvertisementMatcher.AdvertisementState,
                AdvertisementMatcher.ShowAdvertisement));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.Ready && entity.requestShowAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _context.bannerAdEntity.requestShowAdvertisement = false;
            _context.service.value.BannerShow(true);
        }
    }
}