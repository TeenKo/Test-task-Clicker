using System.Collections.Generic;
using Core.Configs;
using Entitas;

namespace Core.Audio.Sound
{
    public sealed class PlayButtonSoundReactSystem : ReactiveSystem<InputEntity>
    {
        private readonly AudioConfig _config;
        public PlayButtonSoundReactSystem(InputContext inputContext, AudioConfig audioConfig) : base(inputContext)
        {
            _config = audioConfig;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AnyOf(
                InputMatcher.ButtonStartGame,
                InputMatcher.ButtonCompleteGame,
                InputMatcher.ButtonRestartGame).Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                _config.ButtonSound();
            }
        }
    }
}