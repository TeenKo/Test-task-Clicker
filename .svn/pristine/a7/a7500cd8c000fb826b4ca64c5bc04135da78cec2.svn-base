using UnityEngine;

namespace Adapters.AppMetricaAnalytics
{
    [CreateAssetMenu(fileName = "AppMetricaConfig", menuName = "Configs/Adapters/AppMetricaConfig", order = 0)]
    public class AppMetricaConfig : AnalyticsConfig
    {
        [SerializeField] private string apiKey;
        [SerializeField] private bool exceptionsReporting = true;
        [SerializeField] private uint sessionTimeoutSec = 300;
        [SerializeField] private bool locationTracking = false;
        [SerializeField] private bool logs = true;
        [SerializeField] private bool handleFirstActivationAsUpdate = false;
        [SerializeField] private bool statisticsSending = true;

        public string ApiKey => apiKey;
        public bool ExceptionsReporting => exceptionsReporting;
        public uint SessionTimeoutSec => sessionTimeoutSec;
        public bool LocationTracking => locationTracking;
        public bool Logs => logs;
        public bool HandleFirstActivationAsUpdate => handleFirstActivationAsUpdate;
        public bool StatisticsSending => statisticsSending;
    }
}