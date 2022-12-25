using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система инициализации сервиса
    /// </summary>
    public sealed class InitializeSystem : IInitializeSystem
    {
        private readonly AdvertisementContext _contexts;

        public InitializeSystem(AdvertisementContext context)
        {
            _contexts = context;
            _contexts.SetService(new Adapters.GoogleAdMob.GoogleAdMobService());

            _contexts.CreateEntity().isBannerAd = true;
            _contexts.bannerAdEntity.isDeactivatingAd = true;

            _contexts.CreateEntity().isInterstitialAd = true;
            _contexts.interstitialAdEntity.isDeactivatingAd = true;

            _contexts.CreateEntity().isRewardedAd = true;
        }

        public void Initialize()
        {
            _contexts.serviceEntity.service.value.Initialize(InitializeComplete);
        }

        private void InitializeComplete()
        {
            _contexts.serviceEntity.isAdvertisementServiceInitialized = true;
        }
    }
}