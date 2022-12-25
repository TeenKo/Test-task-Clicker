using UnityEngine;

namespace Adapters.GoogleAdMob
{
    [CreateAssetMenu(fileName = "GoogleAdMobConfig", menuName = "Configs/Adapters/GoogleAdMobConfig", order = 0)]
    public sealed class GoogleAdMobConfig : AdvertisementConfig
    {
        [SerializeField] private IdentifiersSet androidIdentifiersSet;
        [SerializeField] private IdentifiersSet iOSIdentifiersSet;
        [SerializeField] private bool useTestIdentifiersInstead;

        public IdentifiersSet GetIdentifiersSet()
        {
#if UNITY_ANDROID
            return androidIdentifiersSet.IsFilled() && !useTestIdentifiersInstead
                ? androidIdentifiersSet
                : AndroidIdentifiersSetTest;
#elif UNITY_IOS
            return iOSIdentifiersSet.IsFilled() && !useTestIdentifiersInstead 
                ? iOSIdentifiersSet 
                : IOSIdentifiersSetTest;
#else
            return null;
#endif
        }

        public string[] GetTestDeviceIdentifier()
        {
#if UNITY_ANDROID
            return androidIdentifiersSet.IsFilled() && !useTestIdentifiersInstead
                ? null
                : _testDeviceIdentifiersAndroid;
#elif UNITY_IOS
            return iOSIdentifiersSet.IsFilled() && !useTestIdentifiersInstead ? null : _testDeviceIdentifiersIOS;
#else
            return null;
#endif
        }

        private static IdentifiersSet AndroidIdentifiersSetTest =>
            new IdentifiersSet("ca-app-pub-3940256099942544/6300978111",
                "ca-app-pub-3940256099942544/1033173712",
                "ca-app-pub-3940256099942544/5224354917");

        private static IdentifiersSet IOSIdentifiersSetTest =>
            new IdentifiersSet("ca-app-pub-3940256099942544/2934735716",
                "ca-app-pub-3940256099942544/4411468910",
                "ca-app-pub-3940256099942544/1712485313");

        private readonly string[] _testDeviceIdentifiersAndroid = {"5B6D72601DF3F4D667AF580D4AB5D3C6"};
        private readonly string[] _testDeviceIdentifiersIOS = {"9c4303e46313b4e56979d30db9a4337e"};
    }
}