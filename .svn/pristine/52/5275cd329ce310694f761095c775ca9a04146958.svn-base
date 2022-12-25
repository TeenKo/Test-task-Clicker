using System.Collections.Generic;
using Entitas;

namespace Core.Audio.Sound
{
    public sealed class RequestStopPlaySoundListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly IGroup<AudioEntity> _soundChannels;

        public RequestStopPlaySoundListenerSystem(AudioContext audioContext) : base(audioContext)
        {
            _soundChannels = audioContext.GetGroup(AudioMatcher.SoundChannel);
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestStopPlaySound.Added());
        }

        protected override bool Filter(AudioEntity entity)
        {
            return entity.requestStopPlaySound.value;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                foreach (var soundChannel in _soundChannels.GetEntities())
                {
                    var source = soundChannel.soundChannel.value;
                        
                    if (requestEntity.requestStopPlaySound.value == source.clip)
                    {
                        source.Stop();
                    }
                }
            }
        }
    }
}