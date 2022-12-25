using System;

namespace Adapters.GoogleAdMob
{
    [Serializable]
    public class IdentifiersSet
    {
        public string banner;
        public string interstitial;
        public string rewarded;

        public IdentifiersSet(string banner, string interstitial, string rewarded)
        {
            this.banner = banner;
            this.interstitial = interstitial;
            this.rewarded = rewarded;
        }

        public bool IsFilled() => !string.IsNullOrEmpty(banner) &&
                                  !string.IsNullOrEmpty(interstitial) &&
                                  !string.IsNullOrEmpty(rewarded);
    }
}