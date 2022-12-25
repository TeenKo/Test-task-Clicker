using Core.Audio.Ambient;
using Core.Audio.Music;
using Core.Audio.Sound;
using Core.Configs;

namespace Core.Audio
{
    public sealed class AudioSystems : Entitas.Systems
    {
        public AudioSystems(Contexts contexts)
        {
            var audioConfig = ConfigsCatalogsManager.GetConfig<AudioConfig>();

            Add(new InitializeSystem(contexts.audio));

            Add(new FadeVolumeSystem(contexts.audio));
            Add(new RequestFadeVolumeSystem(contexts.audio));

            Add(new DelayCounterRequestPlaySoundSystem(contexts.audio));

            Add(new MusicGroupSystems(contexts.audio, contexts.state, audioConfig));

            Add(new SoundsGroupSystems(contexts.audio, contexts.input, audioConfig));

            Add(new AmbientGroupSystems(contexts.audio));

            Add(new AudioCleanupSystems(contexts));
        }
    }
}