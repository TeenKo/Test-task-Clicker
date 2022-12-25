using Core.Configs;
using UnityEngine;

namespace Core.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Configs/Game/AudioConfig", order = 0)]
    public sealed class AudioConfig : Config
    {
        [System.Serializable]
        public class SoundClip
        {
            public AudioClip clip = null;
            [Range(0, 1)] public float volume = 1f;
            [Range(-3, 3)] public float pitch = 1f;
            public bool loop = false;
        }

        public const string AudioListenerObjectName = "[AudioChannels]";

        public const string SoundChannelsObjectName = "-sounds";
        public const string MusicChannelsObjectName = "-music";
        public const string AmbientChannelObjectName = "-ambient";

        public const int SoundChannelsCount = 16;
        public const int MusicChannelsCount = 4;
        public const int AmbientChannelsCount = 1;

        #region Sound

        [SerializeField] private SoundClip buttonSound;

        public void ButtonSound(float delay = 0) => CreateSound(buttonSound, Mathf.Max(0, delay));
        
        private static void CreateSound(SoundClip soundClip, float delayPlay = 0)
        {
            var audioEntity = Contexts.sharedInstance.audio.CreateEntity();
            audioEntity.AddRequestPlaySound(soundClip.clip);
            audioEntity.AddVolume(soundClip.volume);
            audioEntity.AddPitch(soundClip.pitch);
            audioEntity.isLoop = soundClip.loop;
            if (delayPlay > 0) audioEntity.AddDelayPlay(Time.time + delayPlay);
        }

        #endregion

        #region Music

        [Space(20)] [SerializeField] private AudioClip mainThemeMusic;
        [SerializeField, Min(0)] private float fadeInTime;
        [SerializeField, Range(0, 1)] private float fadeInVolume;
        [SerializeField, Min(0)] private float fadeOutTime;
        [SerializeField, Range(0, 1)] private float fadeOutVolume;

        [Space(10)] [SerializeField] private AudioClip winMusic;
        [SerializeField] private AudioClip failMusic;

        public AudioClip MainThemeMusic => mainThemeMusic;
        public float FadeInTime => fadeInTime;
        public float FadeInVolume => fadeInVolume;
        public float FadeOutTime => fadeOutTime;
        public float FadeOutVolume => fadeOutVolume;
        public AudioClip WinMusic => winMusic;
        public AudioClip FailMusic => failMusic;

        #endregion
    }
}