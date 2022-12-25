using Entitas;
using UnityEngine;

namespace Core.Audio
{
    public sealed class InitializeSystem : IInitializeSystem
    {
        public InitializeSystem(IContext<AudioEntity> context)
        {
            var audioListenerObject = new GameObject(AudioConfig.AudioListenerObjectName);
            audioListenerObject.AddComponent<AudioListener>();
            var audioListenerEntity = context.CreateEntity();
            audioListenerEntity.AddAudioListener(audioListenerObject);
            audioListenerEntity.AddSoundChannelIndex(0);
            audioListenerEntity.AddSideMusicChannelIndex(1);

            // create sound channels
            var soundChannels = new GameObject(AudioConfig.SoundChannelsObjectName);
            soundChannels.transform.SetParent(audioListenerObject.transform);
            for (var i = 0; i < AudioConfig.SoundChannelsCount; i++)
            {
                var source = soundChannels.AddComponent<AudioSource>();
                source.playOnAwake = false;
                source.loop = false;
                var channelEntity = context.CreateEntity();
                channelEntity.AddSoundChannel(source);
                channelEntity.AddVolume(1);
                channelEntity.AddPitch(1);
            }

            // create music channels
            var musicChannels = new GameObject(AudioConfig.MusicChannelsObjectName);
            musicChannels.transform.SetParent(audioListenerObject.transform);
            for (var i = 0; i < AudioConfig.MusicChannelsCount; i++)
            {
                var source = musicChannels.AddComponent<AudioSource>();
                source.playOnAwake = false;
                source.loop = false;
                var channelEntity = context.CreateEntity();
                channelEntity.AddMusicChannel(source);
                channelEntity.AddVolume(1);
                channelEntity.AddPitch(1);
                if (i == 0) channelEntity.isMainTrackMusic = true;
                else channelEntity.isSideTrackMusic = true;
            }
            
            // create ambient channels
            var ambientChannels = new GameObject(AudioConfig.AmbientChannelObjectName);
            ambientChannels.transform.SetParent(audioListenerObject.transform);
            for (var i = 0; i < AudioConfig.AmbientChannelsCount; i++)
            {
                var source = ambientChannels.AddComponent<AudioSource>();
                source.playOnAwake = false;
                source.loop = true;
                var channelEntity = context.CreateEntity();
                channelEntity.AddAmbientChannel(source);
                channelEntity.AddVolume(1);
                channelEntity.AddPitch(1);
            }
        }

        public void Initialize()
        {
        }
    }
}