namespace Core.Advertisement
{
    /// <summary>
    /// Набор систем взаимодействия с сервисом рекламных объявлений GoogleAdMob
    /// </summary>
    public sealed class AdvertisementsSystems : Entitas.Systems
    {
        /// <summary>
        /// Набор систем для работы рекламного модуля
        /// </summary>        
        public AdvertisementsSystems(AdvertisementContext advertisementContext, GameContext gameContext)
        {
            // initialize
            Add(new InitializeSystem(advertisementContext));
            Add(new InitializingCompleteSystem(advertisementContext));

            // disable banner & interstitial on purchase "no ads" product
            Add(new DisableAdvertisementSystem(advertisementContext));
            
            // show ads
            Add(new BannerShowSystem(advertisementContext));
            Add(new InterstitialShowSystem(advertisementContext));
            Add(new RewardedShowSystem(advertisementContext, gameContext));

            // create and load ads
            Add(new BannerLoadingSystem(advertisementContext));
            Add(new InterstitialLoadingSystem(advertisementContext));
            Add(new RewardedLoadingSystem(advertisementContext));
        }
    }
}