namespace Core.Audio.Ambient
{
    public sealed class AmbientGroupSystems : Feature
    {
        public AmbientGroupSystems(AudioContext audioContext)
        {
            Add(new RequestPlayAmbientListenerSystem(audioContext));
            Add(new RequestStopPlayAmbientListenerSystem(audioContext));
        }
    }
}