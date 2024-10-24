using SerializationFramework.Interfaces;
using SerializationFramework.Attributes;

namespace SerializationFramework.Services
{
    /// <summary>
    /// A generic serializer that uses an ISerializer implementation to serialize and deserialize objects.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize and deserialize.</typeparam>
    public class GenericSerializer<T> where T : class
    {
        private readonly ISerializer<T> _serializer;

        /// <summary>
        /// Initializes a new instance of the GenericSerializer class with the specified serializer.
        /// </summary>
        /// <param name="serializer">An implementation of ISerializer<T>.</param>
        public GenericSerializer(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A serialized string representation of the object.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the class is not marked as SerializableEntity.</exception>
        public string Serialize(T obj)
        {
            // Check if the class T is marked with SerializableEntity attribute
            if (!Attribute.IsDefined(typeof(T), typeof(SerializableEntity)))
            {
                throw new InvalidOperationException($"The class '{typeof(T).Name}' is not marked as SerializableEntity.");
            }

            return _serializer.Serialize(obj);
        }

        /// <summary>
        /// Deserializes the specified string data back to an object.
        /// </summary>
        /// <param name="data">The string data to deserialize.</param>
        /// <returns>An instance of the object of type T.</returns>
        public T Deserialize(string data)
        {
            return _serializer.Deserialize(data);
        }
    }

}
