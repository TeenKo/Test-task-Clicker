using UnityEditor;
using UnityEngine;

namespace Core.Audio
{
    [CustomEditor(typeof(AudioConfig))]
    public sealed class AudioSettingsEditor : Editor
    {
        private AudioConfig _audioConfig;

        private void OnEnable()
        {
            if (!_audioConfig) _audioConfig = (AudioConfig) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20);

            EditorGUILayout.HelpBox($"Sound channels = {AudioConfig.SoundChannelsCount}", MessageType.Info);
            EditorGUILayout.HelpBox($"Music channels = {AudioConfig.MusicChannelsCount}", MessageType.Info);
            EditorGUILayout.HelpBox($"Ambient channels = {AudioConfig.AmbientChannelsCount}", MessageType.Info);
        }
    }
}