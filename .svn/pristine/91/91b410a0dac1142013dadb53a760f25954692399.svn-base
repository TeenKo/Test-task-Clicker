using Entitas;
using UnityEngine;

namespace Core.Audio
{
    public sealed class DelayCounterRequestPlaySoundSystem : IExecuteSystem
    {
        private readonly IGroup<AudioEntity> _delayPlayGroup;
        public DelayCounterRequestPlaySoundSystem(AudioContext audioContext)
        {
            _delayPlayGroup = audioContext.GetGroup(AudioMatcher.AllOf(AudioMatcher.RequestPlaySound, AudioMatcher.DelayPlay));
        }
    
        public void Execute()
        {
            foreach (var audioEntity in _delayPlayGroup.GetEntities())
            {
                if (Time.time < audioEntity.delayPlay.value) continue;
                
                audioEntity.RemoveDelayPlay();
                audioEntity.ReplaceRequestPlaySound(audioEntity.requestPlaySound.value);
            }
        }
    }
}