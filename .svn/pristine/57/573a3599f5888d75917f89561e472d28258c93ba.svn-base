using UnityEditor;
using UnityEngine;

namespace Adapters.AppsFlyerAnalytics
{
    [CustomEditor(typeof(AppsFlyerConfig))]
    public class AppsFlyerConfigEditor : Editor
    {
        private SerializedProperty _devKey;
        private SerializedProperty _appID;
        private SerializedProperty _uwpAppID;
        private SerializedProperty _isDebug;
        private SerializedProperty _getConversionData;

        private void OnEnable()
        {
            _devKey = serializedObject.FindProperty("devKey");
            _appID = serializedObject.FindProperty("appID");
            _uwpAppID = serializedObject.FindProperty("UWPAppID");
            _isDebug = serializedObject.FindProperty("isDebug");
            _getConversionData = serializedObject.FindProperty("getConversionData");
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.HelpBox("devKey - Your application devKey provided by AppsFlyer.", MessageType.Info);
            EditorGUILayout.PropertyField(_devKey);
            if (string.IsNullOrEmpty(_devKey.stringValue)) _devKey.stringValue = "r9vNC83N8nYpCzYGigyjUh";
            EditorGUILayout.Space(20);
            EditorGUILayout.HelpBox("appId - For iOS only. Your iTunes Application ID.", MessageType.Info);
            EditorGUILayout.PropertyField(_appID);
            // EditorGUILayout.HelpBox("UWP app id - For UWP only. Your application app id", MessageType.Info);
            // EditorGUILayout.PropertyField(_uwpAppID);
            // EditorGUILayout.Separator();
            // EditorGUILayout.HelpBox("Enable get conversion data to allow your app to recive deeplinking callbacks", MessageType.None);
            // EditorGUILayout.PropertyField(_getConversionData);
            // EditorGUILayout.Separator();
            EditorGUILayout.HelpBox("Debugging should be restricted to development phase only.\n Do not distribute the app to app stores with debugging enabled", MessageType.Warning);
            EditorGUILayout.PropertyField(_isDebug);
            EditorGUILayout.Separator();

            EditorGUILayout.HelpBox("For more information on setting up AppsFlyer check out our relevant docs.", MessageType.None);


            if (GUILayout.Button("AppsFlyer Unity Docs", new GUILayoutOption[] {GUILayout.Width(200)}))
            {
                Application.OpenURL("https://support.appsflyer.com/hc/en-us/articles/213766183-Unity-SDK-integration-for-developers");
            }

            if (GUILayout.Button("AppsFlyer Android Docs", new GUILayoutOption[] {GUILayout.Width(200)}))
            {
                Application.OpenURL("https://support.appsflyer.com/hc/en-us/articles/207032126-Android-SDK-integration-for-developers");
            }

            if (GUILayout.Button("AppsFlyer iOS Docs", new GUILayoutOption[] {GUILayout.Width(200)}))
            {
                Application.OpenURL("https://support.appsflyer.com/hc/en-us/articles/207032066-AppsFlyer-SDK-Integration-iOS");
            }

            if (GUILayout.Button("AppsFlyer Deeplinking Docs", new GUILayoutOption[] {GUILayout.Width(200)}))
            {
                Application.OpenURL("https://support.appsflyer.com/hc/en-us/articles/208874366-OneLink-deep-linking-guide#Setups");
            }

            if (GUILayout.Button("AppsFlyer Windows Docs", new GUILayoutOption[] {GUILayout.Width(200)}))
            {
                Application.OpenURL("https://support.appsflyer.com/hc/en-us/articles/207032026-Windows-and-Xbox-SDK-integration-for-developers");
            }


            serializedObject.ApplyModifiedProperties();
        }
    }
}