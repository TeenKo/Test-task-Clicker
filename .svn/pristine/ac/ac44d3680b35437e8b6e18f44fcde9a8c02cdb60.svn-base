namespace Core.Audio.Music
{
    public sealed class MusicGroupSystems : Feature
    {
        public MusicGroupSystems(AudioContext audioContext, StateContext stateContext, AudioConfig audioConfig)
        {
            Add(new PlayMainTrackOnMainMenuListenerSystem(audioContext, stateContext, audioConfig));
            Add(new PlayMusicWinListenerSystem(audioContext, stateContext, audioConfig));
            Add(new PlayMusicFailListenerSystem(audioContext, stateContext, audioConfig));

            Add(new SideTrackClipLengthSystem(audioContext, audioConfig));

            Add(new RequestPlayMainTrackMusicListenerSystem(audioContext));
            Add(new RequestPlaySideTrackMusicListenerSystem(audioContext, audioConfig));
        }
    }
}