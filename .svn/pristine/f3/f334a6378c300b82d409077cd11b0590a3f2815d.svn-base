using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система обработки запроса на отключене баннерной и межстраничной реклам 
    /// </summary>
    public sealed class DisableAdvertisementSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public DisableAdvertisementSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
           return context.CreateCollector(AdvertisementMatcher
                .AllOf(AdvertisementMatcher.Service,
                    AdvertisementMatcher.DisableAdvertisement).Added());
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
           return entity.requestDisableAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            var group = _context.GetGroup(AdvertisementMatcher.DeactivatingAd);

            foreach (var entity in group.GetEntities())
                entity.ReplaceAdvertisementState(AdvertisementState.Disabled);

            _context.serviceEntity.service.value.DisableBannerAndInterstitialAd();
        }
    }
}