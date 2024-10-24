using SerializationFramework.Interfaces;

namespace SerializationFramework.Services
{
    /// <summary>
    /// XML serializer implementation for serializing and deserializing objects.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize and deserialize.</typeparam>
    public class XmlSerializer<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// Serializes an object to an XML string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>An XML string representation of the object.</returns>
        public string Serialize(T obj)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes an XML string back to an object.
        /// </summary>
        /// <param name="data">The XML string data to deserialize.</param>
        /// <returns>An instance of type T.</returns>
        public T Deserialize(string data)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }

}
