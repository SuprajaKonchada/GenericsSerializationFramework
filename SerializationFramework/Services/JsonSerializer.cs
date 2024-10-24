using SerializationFramework.Interfaces;

namespace SerializationFramework.Services
{
    /// <summary>
    /// JSON serializer implementation for serializing and deserializing objects.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize and deserialize.</typeparam>
    public class JsonSerializer<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// Serializes an object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public string Serialize(T obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// Deserializes a JSON string back to an object.
        /// </summary>
        /// <param name="data">The JSON string data to deserialize.</param>
        /// <returns>An instance of type T.</returns>
        public T Deserialize(string data)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(data);
        }
    }

}


