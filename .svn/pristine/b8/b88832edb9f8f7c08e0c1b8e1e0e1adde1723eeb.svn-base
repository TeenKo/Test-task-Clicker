#if GoogleAdMobSDK && !UNITY_EDITOR
using GoogleMobileAds.Api;
using System;
using Main.Configs;
using UnityEngine;

namespace Adapters.GoogleAdMob
{
    internal enum AdvertisementState : byte
    {
        NotCreated = 0,
        Loading = 1,
        Ready = 2,
        FailToLoad = 3,
        Opened = 4,
        FailedToShow = 5,
        Closed = 6,
        LeftApplication = 7
    }

    public sealed class GoogleAdMobService : IGoogleAdMobService
    {
        private readonly string _bannerId;
        private AdvertisementState _bannerAdState = AdvertisementState.NotCreated;
        private BannerView _bannerView = null;

        private readonly string _interstitialId;
        private AdvertisementState _interstitialAdState = AdvertisementState.NotCreated;
        private InterstitialAd _interstitialAD = null;

        private readonly string _rewardedId;
        private AdvertisementState _rewardedAdState = AdvertisementState.NotCreated;
        private bool _isRewardEarned = false;
        private RewardedAd _rewardedAd = null;

        private readonly string _testDeviceIdentifier;
        private readonly bool _testMode;

        public void Initialize(Action complete)
        {
            if (!(AdaptersConfigs.AdvertisementConfig is GoogleAdMobConfig config))
            {
                DebugLog(
                    $"{nameof(GoogleAdMobService)} Wrong config type ({AdaptersConfigs.AdvertisementConfig.GetType()}). Should be {nameof(GoogleAdMobConfig)}.");
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
            
            MobileAds.SetiOSAppPauseOnBackground(true);

            MobileAds.Initialize(initCompleteAction => { complete?.Invoke(); });
        }

        private AdRequest Request
        {
            get
            {
                if (_testMode)
                    return new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator)
                        .AddTestDevice(_testDeviceIdentifier).Build();

                return new AdRequest.Builder().Build();
            }
        }

        public void DisableBannerAndInterstitialAd()
        {
            DestroyInterstitial();
            DestroyBannerAd();
        }
        
        #region 1. Standart Banner advertisement

        public void CreateBannerAdOnTop(Action complete, Action failed)
        {
            CreateBannerAd(AdSize.Banner, AdPosition.Top, complete, failed);
        }

        public void CreateBannerAdOnBottom(Action complete, Action failed)
        {
            CreateBannerAd(AdSize.Banner, AdPosition.Bottom, complete, failed);
        }

        private void CreateBannerAd(AdSize bannerSize, AdPosition bannerPosition, Action complete, Action failed)
        {
            if (_bannerAdState == AdvertisementState.Loading ||
                _bannerAdState == AdvertisementState.Ready ||
                _bannerAdState == AdvertisementState.Opened) return;

            DestroyBannerAd();

            _bannerView = new BannerView(_bannerId, bannerSize, bannerPosition);
            _bannerView.OnAdLoaded += (sender, args) =>
            {
                _bannerAdState = AdvertisementState.Ready;
                complete?.Invoke();
            };
            _bannerView.OnAdFailedToLoad += (sender, args) =>
            {
                _bannerAdState = AdvertisementState.FailToLoad;
                failed?.Invoke();
            };
            _bannerView.OnAdOpening += (sender, args) => { _bannerAdState = AdvertisementState.Opened; };
            _bannerView.OnAdClosed += (sender, args) => { _bannerAdState = AdvertisementState.Closed; };
            _bannerView.OnAdLeavingApplication += (sender, args) =>
            {
                _bannerAdState = AdvertisementState.LeftApplication;
            };

            _bannerView.LoadAd(Request);

            _bannerAdState = AdvertisementState.Loading;
        }

        public void DestroyBannerAd()
        {
            if (_bannerView == null) return;

            _bannerView.Destroy();

            _bannerAdState = AdvertisementState.NotCreated;
        }

        public void BannerShow(bool isShow)
        {
            if (_bannerView == null) return;

            if (isShow) _bannerView.Show();
            else _bannerView.Hide();
        }

        public void SetBannerPositionToTop() => SetBannerPosition(AdPosition.Top);

        public void SetBannerPositionToBottom() => SetBannerPosition(AdPosition.Bottom);

        private void SetBannerPosition(AdPosition adPosition) => _bannerView?.SetPosition(adPosition);

        public void GetBannerSize(ref float w, ref float h)
        {
            if (_bannerView == null) return;

            w = _bannerView.GetWidthInPixels();
            h = _bannerView.GetHeightInPixels();
        }

        #endregion


        #region 2. Interstitial advertisement

        public void CreateInterstitialAd(Action complete, Action failed)
        {
            if (_interstitialAdState == AdvertisementState.Loading ||
                _interstitialAdState == AdvertisementState.Ready ||
                _interstitialAdState == AdvertisementState.Opened) return;

            _interstitialAD?.Destroy();

            _interstitialAD = new InterstitialAd(_interstitialId);

            _interstitialAD.OnAdLoaded += (sender, args) =>
            {
                _interstitialAdState = AdvertisementState.Ready;
                complete?.Invoke();
            };
            _interstitialAD.OnAdFailedToLoad += (sender, args) =>
            {
                _interstitialAdState = AdvertisementState.FailToLoad;
                failed?.Invoke();
            };

            _interstitialAdState = AdvertisementState.Loading;

            _interstitialAD.LoadAd(Request);
        }

        public void ShowInterstitial(Action complete)
        {
            if (_interstitialAD.IsLoaded() == false)
            {
                _interstitialAdState = AdvertisementState.FailedToShow;

                complete?.Invoke();

                return;
            }
            
            _interstitialAD.OnAdOpening += (sender, args) => { _interstitialAdState = AdvertisementState.Opened; };
            _interstitialAD.OnAdLeavingApplication += (sender, args) =>
            {
                _interstitialAdState = AdvertisementState.LeftApplication;
                // here we can call analytics event
            };
            _interstitialAD.OnAdClosed += (sender, args) =>
            {
                _interstitialAdState = AdvertisementState.Closed;

                complete?.Invoke();
            };

            _interstitialAD.Show();
        }

        public void DestroyInterstitial()
        {
            _interstitialAD?.Destroy();

            _interstitialAdState = AdvertisementState.NotCreated;
        }

        #endregion


        #region 3. Rewarded advertisement

        public void CreateRewardedAd(Action complete, Action failed)
        {
            if (_rewardedAdState == AdvertisementState.Loading ||
                _rewardedAdState == AdvertisementState.Ready ||
                _rewardedAdState == AdvertisementState.Opened) return;

            _isRewardEarned = false;
            _rewardedAd = new RewardedAd(_rewardedId);
            _rewardedAd.OnAdLoaded += (sender, args) =>
            {
                _rewardedAdState = AdvertisementState.Ready;
                complete?.Invoke();
            };
            _rewardedAd.OnAdFailedToLoad += (sender, args) =>
            {
                _rewardedAdState = AdvertisementState.FailToLoad;
                failed?.Invoke();
            };
            
            _rewardedAdState = AdvertisementState.Loading;

            _rewardedAd.LoadAd(Request);
        }

        public void ShowRewardedAd(Action<bool> complete)
        {
            _isRewardEarned = false;

            if (_rewardedAd.IsLoaded() == false)
            {
                _rewardedAdState = AdvertisementState.FailedToShow;

                complete?.Invoke(false);
                return;
            }

            _rewardedAd.OnAdOpening += (sender, args) => { _rewardedAdState = AdvertisementState.Opened; };
            _rewardedAd.OnAdFailedToShow += (sender, args) => { _rewardedAdState = AdvertisementState.FailedToShow; };
            _rewardedAd.OnUserEarnedReward += (sender, reward) => { _isRewardEarned = true; };
            _rewardedAd.OnAdClosed += (sender, args) =>
            {
                _rewardedAdState = AdvertisementState.Closed;

                complete?.Invoke(_isRewardEarned);
            };

            _rewardedAd.Show();
        }

        #endregion
    }
}
#endif