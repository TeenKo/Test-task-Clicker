using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Core.Audio
{
    public sealed class RequestFadeVolumeSystem : ReactiveSystem<AudioEntity>
    {
        public RequestFadeVolumeSystem(IContext<AudioEntity> context) : base(context)
        {
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestFadeVolume);
        }

        protected override bool Filter(AudioEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            foreach (var requestEntity in entities)
            {
                var fadeTime = requestEntity.requestFadeVolume.fadeTime;
                var targetVolume = requestEntity.requestFadeVolume.value;
                
                var range = targetVolume - requestEntity.volume.value;
                var step = fadeTime == 0 ? range : range * Time.deltaTime / fadeTime;
                requestEntity.ReplaceFadeVolume(step, targetVolume);
                requestEntity.RemoveRequestFadeVolume();
            }
        }
    }
}