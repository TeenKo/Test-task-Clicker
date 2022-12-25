using System.Collections.Generic;
using Entitas;

namespace Core.Audio.Music
{
    public sealed class RequestPlayMainTrackMusicListenerSystem : ReactiveSystem<AudioEntity>
    {
        private readonly AudioEntity _mainTrackMusicChannelEntity;

        public RequestPlayMainTrackMusicListenerSystem(AudioContext audioContext) : base(audioContext)
        {
            _mainTrackMusicChannelEntity = audioContext
                .GetGroup(AudioMatcher.AllOf(AudioMatcher.MusicChannel, AudioMatcher.MainTrackMusic))
                .GetSingleEntity();
        }

        protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
        {
            return context.CreateCollector(AudioMatcher.RequestPlayMainTrackMusic);
        }

        protected override bool Filter(AudioEntity entity)
        {
            return true;
        }

        protected override void Execute(List<AudioEntity> entities)
        {
            // todo: add smooth transition between two clips (need additional components and systems)
            var requestEntity = entities.SingleEntity();
            var source = _mainTrackMusicChannelEntity.musicChannel.value;

            if (source.isPlaying && source.clip == requestEntity.requestPlayMainTrackMusic.value) return;
            
            if (source.isPlaying) source.Stop();

            source.clip = requestEntity.requestPlayMainTrackMusic.value;
            source.loop = requestEntity.isLoop;
            source.volume = requestEntity.hasVolume ? requestEntity.volume.value : 1;
            source.Play();
        }
    }


    // public sealed class RequestStopPlayMainTrackMusicListenerSystem : ReactiveSystem<AudioEntity>
    // {
    //     private readonly IGroup<AudioEntity> _mainTrackMusicChannelEntities;
    //
    //     public RequestStopPlayMainTrackMusicListenerSystem(IContext<AudioEntity> context) : base(context)
    //     {
    //         _mainTrackMusicChannelEntities = context.GetGroup(
    //             AudioMatcher.AllOf(AudioMatcher.MusicChannel, AudioMatcher.MainTrackMusic));
    //     }
    //
    //     protected override ICollector<AudioEntity> GetTrigger(IContext<AudioEntity> context)
    //     {
    //         return context.CreateCollector(AudioMatcher.RequestStopPlayMainTrackMusic);
    //     }
    //
    //     protected override bool Filter(AudioEntity entity)
    //     {
    //         return true;
    //     }
    //
    //     protected override void Execute(List<AudioEntity> entities)
    //     {
    //         var requestEntity = entities.FirstOrDefault();
    //         var mainTrackMusicEntity = _mainTrackMusicChannelEntities.GetEntities().FirstOrDefault();
    //         var source = mainTrackMusicEntity.musicChannel.value;
    //         if (source.isPlaying) source.Stop();
    //     }
    // }
}