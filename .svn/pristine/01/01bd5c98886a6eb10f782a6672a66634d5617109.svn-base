using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Advertisement
{
    public enum AdvertisementState : byte
    {
        NotLoad = 0,
        Loading = 1,
        Ready = 2,
        Disabled = 3
    }

    #region Компоненты инициализации сервиса

    [Advertisement, Unique]
    public sealed class ServiceComponent : IComponent
    {
        public IAdvertisementService value;
    }

    [Advertisement, Event(EventTarget.Self)]
    public sealed class AdvertisementServiceInitializedComponent : IComponent
    {
    }

    #endregion


    #region Компоненты запросов

    /// <summary>
    /// Компонент запроса на загрузку нового рекламного блока
    /// </summary>
    [Advertisement, FlagPrefix("Request")]
    public sealed class LoadAdvertisementComponent : IComponent
    {
    }

    /// <summary>
    /// Компонент запроа на показ загруженного рекламного блока
    /// </summary>
    [Advertisement, FlagPrefix("Request")]
    public sealed class ShowAdvertisementComponent : IComponent
    {
    }

    /// <summary>
    /// Компонент запроса на удаление загруженных рекламных блоков
    /// </summary>
    [Advertisement, FlagPrefix("Request"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class DisableAdvertisementComponent : IComponent
    {
    }

    #endregion


    /// <summary>
    /// Компонент состояний рекламного блока
    /// </summary>
    [Advertisement, Event(EventTarget.Self)]
    public sealed class AdvertisementStateComponent : IComponent
    {
        public AdvertisementState value;
    }

    /// <summary>
    /// Компонент-метка, указываюший на отключаемый рекламный блок
    /// </summary>
    [Advertisement]
    public sealed class DeactivatingAdComponent : IComponent
    {
    }


    #region Уникальные компоненты баннерной рекламы

    /// <summary>
    /// Баннер
    /// </summary>
    [Advertisement, Unique]
    public sealed class BannerAdComponent : IComponent
    {
    }

    /// <summary>
    /// Компонент указатель положения баннера "вверху экрана"
    /// </summary>
    [Advertisement, FlagPrefix("Request"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class BannerPositionOnTopComponent : IComponent
    {
    }

    /// <summary>
    /// Компонент указатель положения баннера "внизу экрана"
    /// </summary>
    [Advertisement, FlagPrefix("Request"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class BannerPositionOnBottomComponent : IComponent
    {
    }

    #endregion


    #region Уникальные компоненты межстраничной рекламы

    [Advertisement, Unique]
    public sealed class InterstitialAdComponent : IComponent
    {
    }

    // [Advertisement]
    // public sealed class CloseInterstitialAdComponent : IComponent
    // {
    // }

    #endregion


    #region Уникальные компоненты наградной рекламы

    [Advertisement, Unique]
    public sealed class RewardedAdComponent : IComponent
    {
    }

    // [Advertisement, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    // public sealed class CloseRewardedAdComponent : IComponent
    // {
    //     public bool value;
    // }

    #endregion
}