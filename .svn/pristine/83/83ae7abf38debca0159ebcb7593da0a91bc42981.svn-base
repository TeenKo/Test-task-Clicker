using System.Collections.Generic;
using Entitas;

namespace Core.Advertisement
{
    /// <summary>
    /// Система обработки инициализации сервиса
    /// </summary>
    public sealed class InitializingCompleteSystem : ReactiveSystem<AdvertisementEntity>
    {
        private readonly AdvertisementContext _contexts;

        public InitializingCompleteSystem(IContext<AdvertisementEntity> context) : base(context)
        {
            _contexts = context as AdvertisementContext;
        }

        protected override ICollector<AdvertisementEntity> GetTrigger(IContext<AdvertisementEntity> context)
        {
            return context.CreateCollector(AdvertisementMatcher.AdvertisementServiceInitialized);
        }

        protected override bool Filter(AdvertisementEntity entity)
        {
            return entity.isAdvertisementServiceInitialized;
        }

        protected override void Execute(List<AdvertisementEntity> entities)
        {
            _contexts.bannerAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
            _contexts.interstitialAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);
            _contexts.rewardedAdEntity.ReplaceAdvertisementState(AdvertisementState.NotLoad);

            _contexts.bannerAdEntity.requestLoadAdvertisement = true;
            _contexts.interstitialAdEntity.requestLoadAdvertisement = true;
            _contexts.rewardedAdEntity.requestLoadAdvertisement = true;
        }
    }
}