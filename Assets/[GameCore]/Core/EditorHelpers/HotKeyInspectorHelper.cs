namespace Core.EditorHelpers
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(HotKeyInspectorHelper))]
    public sealed class HotKeyInspectorHelperEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("KEY   Alpha 1   transition to Game state", MessageType.Info);
            EditorGUILayout.HelpBox("KEY   Alpha 2   transition to Victory state", MessageType.Info);
            EditorGUILayout.HelpBox("KEY   Alpha 3   transition to Defeat state", MessageType.Info);
        }
    }
#endif

    public sealed class HotKeyInspectorHelper : UnityEngine.MonoBehaviour
    {
    }
}