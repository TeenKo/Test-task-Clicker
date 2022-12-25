using System.Collections.Generic;
using Core.Configs;
using Entitas;

namespace Core.Audio.Music
{
    public sealed class PlayMusicFailListenerSystem : ReactiveSystem<StateEntity>
    {
        private readonly AudioContext _audioContext;
        private readonly AudioConfig _audioConfig;

        public PlayMusicFailListenerSystem(AudioContext audioContext, StateContext stateContext, AudioConfig audioConfig) : base(stateContext)
        {
            _audioContext = audioContext;
            _audioConfig = audioConfig;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Defeat.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            _audioContext.CreateEntity().AddRequestPlaySideTrackMusic(_audioConfig.FailMusic);
        }
    }
}