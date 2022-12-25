using System.Collections.Generic;
using Entitas;

namespace Core.Audio.Sound
{
    public sealed class RequestPlaySoundListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly AudioEntity _listenerEntity;
        private readonly IGroup<AudioEntity> _soundChannels;

        public RequestPlaySoundListenerSystem(AudioContext audioContext) : base(audioContext)
        {
            _listenerEntity = audioContext.GetGroup(AudioMatcher.AudioListener).GetSingleEntity();
            _soundChannels = audioContext.GetGroup(AudioMatcher.SoundChannel);
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestPlaySound.Added());
        }

        protected override bool Filter(AudioEntity entity)
        {
            return entity.hasRequestPlaySound && entity.hasDelayPlay == false;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                if (requestEntity.requestPlaySound.value != null)
                {
                    var index = _listenerEntity.soundChannelIndex.value;
                    var i = 0;
                    foreach (var channelEntity in _soundChannels)
                    {
                        if (i == index)
                        {
                            var source = channelEntity.soundChannel.value;
                            if (source.isPlaying) source.Stop();
                            source.clip = requestEntity.requestPlaySound.value;
                            source.loop = requestEntity.isLoop;
                            source.volume = requestEntity.hasVolume ? requestEntity.volume.value : 1;
                            source.pitch = requestEntity.hasPitch ? requestEntity.pitch.value : 1;
                            source.Play();
                            if (++index >= AudioConfig.SoundChannelsCount) index = 0;
                            _listenerEntity.ReplaceSoundChannelIndex(index);
                            break;
                        }

                        i++;
                    }
                }

                requestEntity.Destroy();
            }
        }
    }
}