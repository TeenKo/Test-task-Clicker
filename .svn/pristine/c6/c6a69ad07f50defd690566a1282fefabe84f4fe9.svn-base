using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система загрузка межстраничной рекламы
    /// </summary>
    public sealed class InterstitialLoadingSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _context;

        public InterstitialLoadingSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _context = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AllOf(AdvertisementMatcher.InterstitialAd,
                AdvertisementMatcher.AdvertisementState, AdvertisementMatcher.LoadAdvertisement));
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.advertisementState.value == AdvertisementState.NotLoad && entity.requestLoadAdvertisement;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _context.interstitialAdEntity.requestLoadAdvertisement = false;
            _context.interstitialAdEntity.ReplaceAdvertisementState(AdvertisementState.Loading);
            _context.service.value.CreateInterstitialAd(Complete, Failed);
        }

        private void Complete()
        {
            _context.interstitialAdEntity.ReplaceAdvertisementState(AdvertisementState.Ready);
        }

        private void Failed()
        {
            _context.interstitialAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
        }
    }
}