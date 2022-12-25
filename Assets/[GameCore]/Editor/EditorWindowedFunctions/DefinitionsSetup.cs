using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EditorWindowedFunctions
{
    public sealed class DefinitionsSetup : EditorWindow
    {
        [MenuItem("JB tools/Builds/DefinitionsSetup")]
        private static void ShowWindow()
        {
            var window = GetWindow<DefinitionsSetup>();
            window.titleContent = new GUIContent("Definitions setup");
            window.Show();

            var currentResolution = Screen.currentResolution;
            var size = Vector2.one * 512;
            var position = (new Vector2(currentResolution.width, currentResolution.height) - size) / 2;
            window.position = new Rect(position, size);
        }

        private static readonly string[] AddingDefinitionNames =
            {"AppMetrica", "FacebookSDK", "FirebaseSDK", "GoogleAdMobSDK", "IAPService", "VoodooSDK"};

        private static readonly bool[] AddingDefinitionToggles = {false, false, false, false, false};

        private static BuildTargetGroup BuildTargetGroup =>
            BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);

        private void OnEnable()
        {
            PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup, out string[] storedDefinitionNames);

            foreach (var define in storedDefinitionNames)
            {
                var index = Array.IndexOf(AddingDefinitionNames, define);
                if (index >= 0)
                {
                    AddingDefinitionToggles[index] = true;
                }
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.HelpBox("Attention! Do not change anything here if you don't know what is this!",
                MessageType.Warning);

            var count = AddingDefinitionNames.Length;

            for (var i = 0; i < count; i++)
            {
                using (new GUILayout.HorizontalScope("box"))
                {
                    AddingDefinitionToggles[i] = GUILayout.Toggle(AddingDefinitionToggles[i], AddingDefinitionNames[i]);
                }

                GUILayout.Space(5);
            }

            if (GUILayout.Button("Apply"))
            {
                PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup, out string[] storedDefinitionNames);

                var applyingDefinitionNames = storedDefinitionNames
                    .Where(storedDefinition => !AddingDefinitionNames.Contains(storedDefinition)).ToList();
                applyingDefinitionNames.AddRange(AddingDefinitionNames.Where((t, i) => AddingDefinitionToggles[i]));
                if (applyingDefinitionNames.Count > 0)
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup,
                        applyingDefinitionNames.ToArray());

                Debug.Log("Player settings define symbols for group updated!");

                Close();
            }
        }
    }
}