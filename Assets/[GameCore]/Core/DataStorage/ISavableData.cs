namespace Core.DataStorage
{
    public interface ISavableData
    {
        object GetValue { get; }
        void SetValue(object value);
    }
}