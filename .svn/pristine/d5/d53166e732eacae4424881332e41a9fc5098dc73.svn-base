using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Core.Audio
{
    #region Sounds

    [Audio]
    public sealed class AudioListenerComponent : IComponent
    {
        public GameObject value;
    }

    [Audio]
    public sealed class SoundChannelComponent : IComponent
    {
        public AudioSource value;
    }


    [Audio]//, Cleanup(CleanupMode.DestroyEntity)] manual
    public sealed class RequestPlaySoundComponent : IComponent
    {
        public AudioClip value;
    }


    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestStopPlaySoundComponent : IComponent
    {
        public AudioClip value;
    }

    [Audio]
    public sealed class SoundChannelIndexComponent : IComponent
    {
        public int value;
    }
    
    #endregion

    #region Music

    [Audio]
    public sealed class MusicChannelComponent : IComponent
    {
        public AudioSource value;
    }

    [Audio]
    public sealed class MainTrackMusicComponent : IComponent
    {
    }

    [Audio]
    public sealed class SideTrackMusicComponent : IComponent
    {
    }

    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestPlayMainTrackMusicComponent : IComponent
    {
        public AudioClip value;
    }

    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestPlaySideTrackMusicComponent : IComponent
    {
        public AudioClip value;
    }

    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestStopPlayMainTrackMusicComponent : IComponent
    {
        public AudioClip value;
    }

    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestStopPlaySideTrackMusicComponent : IComponent
    {
        public AudioClip value;
    }
    
    [Audio]
    public sealed class SideMusicChannelIndexComponent : IComponent
    {
        public int value;
    }

    #endregion

    #region Ambient

    [Audio]
    public sealed class AmbientChannelComponent : IComponent
    {
        public AudioSource value;
    }
    
    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestPlayAmbientComponent : IComponent
    {
        public AudioClip value;
    }

    [Audio, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RequestStopPlayAmbientComponent : IComponent
    {
        public AudioClip value;
    }
    #endregion
    
    #region Common

    [Audio]
    public sealed class LoopComponent : IComponent
    {
    }

    [Audio]
    public sealed class VolumeComponent : IComponent
    {
        public float value;
    }
    
    [Audio]
    public sealed class PitchComponent : IComponent
    {
        public float value;
    }

    [Audio]
    public sealed class ClipLengthComponent : IComponent
    {
        public float value;
    }
    
    [Audio]
    public sealed class FadeVolumeComponent : IComponent
    {
        public float step; 
        public float value;
    }
    
    [Audio] // manual cleanup
    public sealed class RequestFadeVolumeComponent : IComponent
    {
        public float fadeTime; 
        public float value;
    }

    [Audio]
    public sealed class DelayPlayComponent : IComponent
    {
        public float value;
    }

    #endregion
}