#if AppMetrica && !UNITY_EDITOR

using System;
using Core.Configs;
using UnityEngine;

namespace Adapters.AppMetricaAnalytics
{
    public sealed class AppMetrica : IAppMetricaService
    {
        private bool _actualPauseStatus = false;

        private readonly IYandexAppMetrica _metrica = null;

        private readonly object _syncRoot = new object();

        public AppMetrica()
        {
            var config = ConfigsCatalogsManager.GetConfig<AppMetricaConfig>();

            if (config.ExceptionsReporting)
            {
                Application.logMessageReceived += HandleLog;
            }

            lock (_syncRoot)
            {
                _metrica ??= new YandexAppMetricaDummy();
            }

            var configuration = new YandexAppMetricaConfig(config.ApiKey)
            {
                SessionTimeout = (int) config.SessionTimeoutSec,
                Logs = config.Logs,
                HandleFirstActivationAsUpdate = config.HandleFirstActivationAsUpdate,
                StatisticsSending = config.StatisticsSending,
                LocationTracking = false
            };

            _metrica.ActivateWithConfiguration(configuration);
        }

        public void Initialize(Action complete, Action<string> failed)
        {
            _metrica.ResumeSession();
            complete?.Invoke();
        }

        public void ApplicationOnFocus(bool focus)
        {
        }

        public void ApplicationOnPause(bool pause)
        {
            if (_actualPauseStatus == pause) return;

            _actualPauseStatus = pause;
            if (pause)
            {
                _metrica.PauseSession();
            }
            else
            {
                _metrica.ResumeSession();
            }
        }

        public void GameLevelStart(AnalyticsConfig.EventGameLevelParameters start)
        {
            _metrica.ReportEvent("level_start", start.Parameters);
            SendEventsBuffer();
        }

        public void GameLevelFinish(AnalyticsConfig.EventGameLevelParameters finish)
        {
            _metrica.ReportEvent("level_finish", finish.Parameters);
            SendEventsBuffer();
        }

        private void SendEventsBuffer()
        {
            _metrica.SendEventsBuffer();
        }

        private void HandleLog(string condition, string stackTrace, LogType type)
        {
            if (type == LogType.Exception)
            {
                _metrica.ReportErrorFromLogCallback(condition, stackTrace);
            }
        }
    }
}

#endif