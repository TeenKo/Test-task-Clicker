#if !GoogleAdMobSDK || UNITY_EDITOR
using System;
using Core.Advertisement;
using Core.Configs;
using UnityEngine;

namespace Adapters.GoogleAdMob
{
    public sealed class GoogleAdMobService : IAdvertisementService
    {
        public void Initialize(Action complete)
        {
            var config = ConfigsCatalogsManager.GetConfig<GoogleAdMobConfig>();
            if (config == null)
            {
                DebugLog(
                    $"<color=#BF5846>{nameof(GoogleAdMobService)} waring {nameof(GoogleAdMobConfig)} was not found!");
                return;
            }

            var identifiersSet = config.GetIdentifiersSet();

            if (identifiersSet == null)
            {
                Debug.Log($"{nameof(GoogleAdMobService)}() No configure data available on this platform");
                return;
            }

            var testDeviceIdentifier = config.GetTestDeviceIdentifier()?[0];
            var testMode = !string.IsNullOrEmpty(testDeviceIdentifier);

            var configReport = $"Banner=[{identifiersSet.banner}]\n" +
                               $"Interstitial=[{identifiersSet.interstitial}]\n" +
                               $"Rewarded=[{identifiersSet.rewarded}]\n" +
                               $"isTest={testMode} [{testDeviceIdentifier}]";

            DebugLog($"{nameof(GoogleAdMobService)}() Configure with data:\n{configReport}");

            complete?.Invoke();
        }

        #region Banner

        public void CreateBannerAdOnTop(Action complete, Action failed)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(CreateBannerAdOnTop)}()");

            complete?.Invoke();
        }

        public void CreateBannerAdOnBottom(Action complete, Action failed)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(CreateBannerAdOnBottom)}()");

            complete?.Invoke();
        }

        public void DestroyBannerAd()
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(DestroyBannerAd)}()");
        }

        public void BannerShow(bool isShow)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(BannerShow)}()");
        }

        public void SetBannerPositionToTop()
        {
        }

        public void SetBannerPositionToBottom()
        {
        }

        public void GetBannerSize(ref float w, ref float h)
        {
        }

        #endregion

        #region Interstitial

        public void CreateInterstitialAd(Action complete, Action failed)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(CreateInterstitialAd)}()");

            complete?.Invoke();
        }

        public void ShowInterstitial(Action complete)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(ShowInterstitial)}()");

            complete?.Invoke();
        }

        public void DestroyInterstitial()
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(DestroyInterstitial)}()");
        }

        #endregion

        #region Rewarded

        public void CreateRewardedAd(Action complete, Action failed)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(CreateRewardedAd)}()");

            complete?.Invoke();
        }

        public void ShowRewardedAd(Action<bool> complete)
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(ShowRewardedAd)}()");

            complete?.Invoke(true);
        }

        #endregion

        public void DisableBannerAndInterstitialAd()
        {
            DebugLog($"{nameof(GoogleAdMobService)}.{nameof(DisableBannerAndInterstitialAd)}()");

            DestroyBannerAd();
            DestroyInterstitial();
        }

        private void DebugLog(string message)
        {
            // Debug.Log(message);
        }
    }
}
#endif