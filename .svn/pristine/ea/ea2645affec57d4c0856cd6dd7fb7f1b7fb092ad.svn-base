#if FirebaseSDK && !UNITY_EDITOR
using Firebase.Analytics;
#endif

using UnityEngine;

namespace Adapters.FirebaseAnalytics
{
    public sealed class FirebaseAnalyticEvents
    {
        #region Настройки имен событий и параметров

        private const string EventGameStart = "Game_Start";
        private const string EventGameEnd = "Game_End";
        private const string ParameterGameLevel = "Game_Level";

        private const string EventPurchaseStart = "Purchase_Start";
        private const string EventPurchaseComplete = "Purchase_Complete";
        private const string EventPurchaseFail = "Purchase_Fail";
        private const string ParameterPurchaseProductId = "Purchase_ProductId";
        private const string ParameterPurchaseFailReason = "PurchaseFail_Reason";

        #endregion

#if FirebaseSDK && !UNITY_EDITOR
        public FirebaseAnalyticEvents()
        {
        }

        public void GameStart(int level)
        {
            FirebaseAnalytics.LogEvent(EventGameStart, ParameterGameLevel, level);
        }

        public void GameEnd(int level)
        {
            FirebaseAnalytics.LogEvent(EventGameEnd, ParameterGameLevel, level);
        }

        public void PurchaseStart(string storeProductID)
        {
            FirebaseAnalytics.LogEvent(EventPurchaseStart, ParameterPurchaseProductId, storeProductID);
        }

        public void PurchaseComplete(string storeProductID)
        {
            FirebaseAnalytics.LogEvent(EventPurchaseComplete, ParameterPurchaseProductId, storeProductID);
        }

        public void PurchaseFail(string storeProductID, string storeReason)
        {
            var parameter1 = new Parameter(ParameterPurchaseProductId, storeProductID);
            var parameter2 = new Parameter(ParameterPurchaseFailReason, storeReason);
            Parameter[] parameters = {parameter1, parameter2};

            FirebaseAnalytics.LogEvent(EventPurchaseFail, parameters);
        }

#elif !FirebaseSDK || UNITY_EDITOR

        public FirebaseAnalyticEvents()
        {
        }

        public void GameStart(int level)
        {
            DebugOut($"Event [{EventGameStart}] Parameter {ParameterGameLevel}=[{level}]");
        }

        public void GameEnd(int level)
        {
            DebugOut($"Event [{EventGameEnd}] Parameter {ParameterGameLevel}=[{level}]");
        }


        public void PurchaseStart(string storeProductID)
        {
            DebugOut($"Event [{EventPurchaseStart}] Parameter {ParameterPurchaseProductId}=[{storeProductID}]");
        }

        public void PurchaseComplete(string storeProductID)
        {
            DebugOut($"Event [{EventPurchaseComplete}] Parameter {ParameterPurchaseProductId}=[{storeProductID}]");
        }

        public void PurchaseFail(string storeProductID, string storeReason)
        {
            DebugOut(
                $"Event [{EventPurchaseFail}] Parameter {ParameterPurchaseProductId}=[{storeProductID}] Parameter {ParameterPurchaseFailReason}=[{storeReason}]");
        }

        private void DebugOut(string message) =>
            Debug.Log($"<color=orange>{nameof(FirebaseAnalyticEvents)}.{message}</color>");

#endif
    }
}