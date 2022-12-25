using System.Collections.Generic;
using Core.Configs;
using Entitas;

namespace Core.Audio.Music
{
    public sealed class RequestPlaySideTrackMusicListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly AudioEntity _listenerEntity;
        private readonly AudioEntity _mainTrackEntity;
        private readonly IGroup<AudioEntity> _sideTrackChannels;
        private readonly AudioConfig _config;
        
        public RequestPlaySideTrackMusicListenerSystem(AudioContext audioContext, AudioConfig audioConfig) : base(audioContext)
        {
            _listenerEntity = audioContext.GetGroup(AudioMatcher.AudioListener).GetSingleEntity();
            _mainTrackEntity = audioContext.GetGroup(AudioMatcher.MainTrackMusic).GetSingleEntity();
            _sideTrackChannels = audioContext.GetGroup(AudioMatcher.AllOf(
                AudioMatcher.MusicChannel, 
                AudioMatcher.SideTrackMusic));

            _config = audioConfig;
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestPlaySideTrackMusic);
        }

        protected override bool Filter(AudioEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                var playChannelIndex = _listenerEntity.sideMusicChannelIndex.value;
                var index = 1;

                foreach (var channelEntity in _sideTrackChannels)
                {
                    if (index == playChannelIndex)
                    {
                        var source = channelEntity.musicChannel.value;

                        if (source.isPlaying) source.Stop();

                        if (requestEntity.requestPlaySideTrackMusic.value == null) break;

                        source.clip = requestEntity.requestPlaySideTrackMusic.value;
                        source.loop = false;
                        source.volume = requestEntity.hasVolume ? requestEntity.volume.value : 1;
                        source.Play();
                        channelEntity.ReplaceClipLength(source.clip.length);

                        // requestEntity.Destroy();
                        playChannelIndex = playChannelIndex + 1 >= AudioConfig.MusicChannelsCount ? 1 : playChannelIndex + 1;
                        _listenerEntity.ReplaceSideMusicChannelIndex(playChannelIndex);

                        // add request to fade main track
                        var fadeTime = _config.FadeInTime;
                        var targetVolume =_config.FadeInVolume;
                        _mainTrackEntity.AddRequestFadeVolume(fadeTime, targetVolume);
                        break;
                    }

                    index++;
                }
            }
        }
    }
}