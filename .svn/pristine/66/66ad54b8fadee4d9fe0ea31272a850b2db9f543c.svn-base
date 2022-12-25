#if !VoodooSDK || UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Adapters.VoodooAnalytics
{
    public sealed class Voodoo : IVoodooService
    {
        public void Initialize(Action complete, Action<string> failed)
        {
            complete?.Invoke();
        }

        public void ApplicationOnFocus(bool focus)
        {
        }

        public void ApplicationOnPause(bool pause)
        {
        }

        public void GameLevelStart(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
            var logMessage = eventGameLevelParameters.Parameters.Aggregate<KeyValuePair<string, object>, string>(null, (current, parameter) =>
                string.IsNullOrEmpty(current)
                    ? $"{parameter.Key}={parameter.Value}"
                    : $"{current}\n{parameter.Key}={parameter.Value}");

            Debug.Log($"{logMessage}");
        }

        public void GameLevelFinish(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
            var logMessage = eventGameLevelParameters.Parameters.Aggregate<KeyValuePair<string, object>, string>(null, (current, parameter) =>
                string.IsNullOrEmpty(current)
                    ? $"{parameter.Key}={parameter.Value}"
                    : $"{current}\n{parameter.Key}={parameter.Value}");

            Debug.Log($"{logMessage}");
        }
    }
}
#endif