using System;

namespace Core.Advertisement
{
    public interface IAdvertisementService
    {
        void Initialize(Action complete);

        void CreateBannerAdOnTop(Action complete, Action failed);
        void CreateBannerAdOnBottom(Action complete, Action failed);
        void DestroyBannerAd();
        void BannerShow(bool isShow);
        void SetBannerPositionToTop();
        void SetBannerPositionToBottom();
        void GetBannerSize(ref float w, ref float h);

        void CreateInterstitialAd(Action complete, Action failed);
        void ShowInterstitial(Action complete);
        void DestroyInterstitial();

        void CreateRewardedAd(Action complete, Action failed);
        void ShowRewardedAd(Action<bool> complete);

        void DisableBannerAndInterstitialAd();
    }
}