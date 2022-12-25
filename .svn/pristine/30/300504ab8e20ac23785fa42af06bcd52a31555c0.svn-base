namespace Core.Audio.Sound
{
    public sealed class SoundsGroupSystems : Feature
    {
        public SoundsGroupSystems(AudioContext audioContext, InputContext inputContext, AudioConfig audioConfig)
        {
            Add(new RequestPlaySoundListenerSystem(audioContext));
            Add(new RequestStopPlaySoundListenerSystem(audioContext));

            Add(new PlayButtonSoundReactSystem(inputContext, audioConfig));
        }
    }
}