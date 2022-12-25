using Core.Configs;
using Entitas;
using UnityEngine;

namespace Core.Audio.Music
{
    public sealed class SideTrackClipLengthSystem : IExecuteSystem
    {
        private readonly IGroup<AudioEntity> _sideTrackChannels;
        private readonly AudioEntity _mainTrackEntity;
        private readonly AudioConfig _config;
        
        public SideTrackClipLengthSystem(AudioContext audioContext, AudioConfig audioConfig)
        {
            _sideTrackChannels = audioContext.GetGroup(AudioMatcher.ClipLength);
            _mainTrackEntity = audioContext.GetGroup(AudioMatcher.MainTrackMusic).GetSingleEntity();
            _config = audioConfig;
        }

        public void Execute()
        {
            foreach (var entity in _sideTrackChannels.GetEntities())
            {
                var length = entity.clipLength.value;
                if ((length -= Time.deltaTime) <= 0)
                {
                    // add request to fade main track
                    var fadeTime = _config.FadeOutTime;
                    var targetVolume = _config.FadeOutVolume;
                    _mainTrackEntity.AddRequestFadeVolume(fadeTime, targetVolume);
                    entity.RemoveClipLength();
                    
                    continue;
                }

                entity.ReplaceClipLength(length);
            }
        }
    }
}