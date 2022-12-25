using System.Collections.Generic;
using Entitas;

namespace Core.Audio.Ambient
{
    public sealed class RequestStopPlayAmbientListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly IGroup<AudioEntity> _ambientChannels;

        public RequestStopPlayAmbientListenerSystem(AudioContext audioContext) : base(audioContext)
        {
            _ambientChannels = audioContext.GetGroup(AudioMatcher.AmbientChannel);
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestStopPlayAmbient.Added());
        }

        protected override bool Filter(AudioEntity entity)
        {
            return entity.requestStopPlayAmbient.value;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                foreach (var audioEntity in _ambientChannels.GetEntities())
                {
                    var source = audioEntity.ambientChannel.value;
                        
                    if (requestEntity.requestStopPlayAmbient.value == source.clip)
                    {
                        source.Stop();
                    }
                }
            }
        }
    }
}