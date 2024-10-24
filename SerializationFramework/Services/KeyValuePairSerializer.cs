using SerializationFramework.Interfaces;
using System.Globalization;

namespace SerializationFramework.Services
{
    /// <summary>
    /// Key-Value Pair serializer implementation for serializing and deserializing objects.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize and deserialize.</typeparam>
    public class KeyValuePairSerializer<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// Serializes an object into a key-value pair string format.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object in key-value format.</returns>
        public string Serialize(T obj)
        {
            var properties = typeof(T).GetProperties();
            var keyValuePairs = properties.Select(p =>
            {
                var value = p.GetValue(obj);
                return $"{p.Name}={SerializeValue(value)}";
            });
            return string.Join(";", keyValuePairs);
        }

        /// <summary>
        /// Deserializes a key-value pair string back to an object.
        /// </summary>
        /// <param name="data">The key-value pair string to deserialize.</param>
        /// <returns>An instance of type T.</returns>
        public T Deserialize(string data)
        {
            var obj = Activator.CreateInstance<T>();
            var properties = typeof(T).GetProperties();

            foreach (var pair in data.Split(';'))
            {
                var kvp = pair.Split('=');
                var propName = kvp[0];
                var propValue = kvp[1];

                var prop = properties.FirstOrDefault(p => p.Name == propName);
                if (prop != null)
                {
                    var value = DeserializeValue(propValue, prop.PropertyType);
                    prop.SetValue(obj, value);
                }
            }

            return obj;
        }

        /// <summary>
        /// Serializes a value to a string based on its type.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>A string representation of the value.</returns>
        private string SerializeValue(object value)
        {
            return value switch
            {
                string str => str,
                int i => i.ToString(),
                bool b => b.ToString(),
                float f => f.ToString(CultureInfo.InvariantCulture),
                double d => d.ToString(CultureInfo.InvariantCulture),
                _ => value?.ToString() ?? string.Empty
            };
        }

        /// <summary>
        /// Deserializes a string value to the target type.
        /// </summary>
        /// <param name="value">The string value to deserialize.</param>
        /// <param name="targetType">The target type to deserialize to.</param>
        /// <returns>The deserialized object.</returns>
        private object DeserializeValue(string value, Type targetType)
        {
            if (targetType == typeof(string)) return value;
            if (targetType == typeof(int)) return int.Parse(value);
            if (targetType == typeof(bool)) return bool.Parse(value);
            if (targetType == typeof(float)) return float.Parse(value, CultureInfo.InvariantCulture);
            if (targetType == typeof(double)) return double.Parse(value, CultureInfo.InvariantCulture);

            return value;
        }
    }

}
