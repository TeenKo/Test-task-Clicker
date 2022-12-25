using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система обработки запросов на показ межстраничной рекламы
    /// </summary>
    public sealed class InterstitialShowSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public InterstitialShowSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AllOf(AdvertisementMatcher.InterstitialAd,
                AdvertisementMatcher.AdvertisementState, AdvertisementMatcher.ShowAdvertisement));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.Ready && entity.requestShowAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _context.interstitialAdEntity.requestShowAdvertisement = false;
            _context.service.value.ShowInterstitial(Complete);
        }

        private void Complete()
        {
            _context.interstitialAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
            _context.interstitialAdEntity.requestLoadAdvertisement = true;
        }
    }
}