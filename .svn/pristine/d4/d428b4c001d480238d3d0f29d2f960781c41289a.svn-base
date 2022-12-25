using System.Collections.Generic;
using Entitas;

namespace Core.Audio.Ambient
{
    public sealed class RequestPlayAmbientListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly IGroup<AudioEntity> _ambientChannels;

        public RequestPlayAmbientListenerSystem(AudioContext audioContext) : base(audioContext)
        {
            _ambientChannels = audioContext.GetGroup(AudioMatcher.AmbientChannel);
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestPlayAmbient.Added());
        }

        protected override bool Filter(AudioEntity entity)
        {
            return entity.requestPlayAmbient.value;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                foreach (var audioEntity in _ambientChannels)
                {
                    var source = audioEntity.ambientChannel.value;
                    if (source.isPlaying) source.Stop();
                    source.clip = requestEntity.requestPlayAmbient.value;
                    source.loop = requestEntity.isLoop;
                    source.volume = requestEntity.hasVolume ? requestEntity.volume.value : 1;
                    source.pitch = requestEntity.hasPitch ? requestEntity.pitch.value : 1;
                    source.Play();
                    return;
                }
            }
        }
    }
}