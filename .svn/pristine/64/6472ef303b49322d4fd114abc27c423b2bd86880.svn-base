using Entitas;
using UnityEngine;

namespace Core.Audio
{
    public sealed class FadeVolumeSystem : IExecuteSystem
    {
        private readonly IGroup<AudioEntity> _entities;
        
        public FadeVolumeSystem(IContext<AudioEntity> context)
        {
            _entities = context.GetGroup(AudioMatcher.FadeVolume);
        }
        
        public void Execute()
        {
            foreach (var audioEntity in _entities.GetEntities())
            {
                var currentVolume = audioEntity.volume.value;
                var step = audioEntity.fadeVolume.step;
                var targetVolume = audioEntity.fadeVolume.value;
                
                currentVolume += step;
                if ((currentVolume - targetVolume) * Mathf.Sign(step) >= 0)
                {
                    currentVolume = targetVolume;
                    audioEntity.RemoveFadeVolume();
                }

                audioEntity.musicChannel.value.volume = currentVolume;
                audioEntity.ReplaceVolume(currentVolume);
            }
        }
    }
}