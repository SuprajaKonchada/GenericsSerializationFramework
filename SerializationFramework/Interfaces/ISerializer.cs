namespace SerializationFramework.Interfaces
{
    /// <summary>
    /// Interface for defining serialization and deserialization methods.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize and deserialize.</typeparam>
    public interface ISerializer<T>
    {
        string Serialize(T obj);
        T Deserialize(string data);
    }
}
