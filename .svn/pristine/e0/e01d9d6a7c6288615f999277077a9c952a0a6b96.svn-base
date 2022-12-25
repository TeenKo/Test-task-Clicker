using System.Collections.Generic;
using Core.Configs;
using Entitas;

namespace Core.Audio.Music
{
    public sealed class PlayMainTrackOnMainMenuListenerSystem : ReactiveSystem<StateEntity>
    {
        private readonly AudioContext _audioContext;
        private readonly AudioConfig _audioConfig;

        public PlayMainTrackOnMainMenuListenerSystem(AudioContext audioContext, StateContext stateContext, AudioConfig audioConfig) : base(stateContext)
        {
            _audioContext = audioContext;
            _audioConfig = audioConfig;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.AnyOf(StateMatcher.MainMenu).Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            var requestMainTrackMusicEntity = _audioContext.CreateEntity();
            requestMainTrackMusicEntity.isLoop = true;
            requestMainTrackMusicEntity.AddVolume(1);
            requestMainTrackMusicEntity.AddRequestPlayMainTrackMusic(_audioConfig.MainThemeMusic);
        }
    }
}