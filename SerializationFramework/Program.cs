using SerializationFramework.Interfaces;
using SerializationFramework.Models;
using SerializationFramework.Services;

namespace SerializationFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student entity is not marked as Serializable, hence the serialization process would throw an exception
            /*var student = new Student
            {
                Id = 1,
                FirstName = "Supraja",
                LastName = "Konchada"
            };

            // JSON Serialization
            // Attempting to serialize the Student object to JSON format will throw an error because Student is not marked as Serializable
            var jsonStudentSerializer = new GenericSerializer<Student>(new JsonSerializer<Student>());
            string jsonStudent = jsonStudentSerializer.Serialize(student);
            Console.WriteLine(value: "JSON: " + jsonStudent);*/

            // Create an instance of Employee and initialize its properties
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Supraja",
                LastName = "Konchada",
                Department = "Delivery",
                IsPermanent = true,
                Salary = 4500000
            };

            // Loop to allow user to serialize/deserialize repeatedly
            while (true)
            {
                // Ask the user to select a format for serialization by number
                Console.WriteLine("Select a number for serialization format (or 0 to exit):");
                Console.WriteLine("1 - JSON");
                Console.WriteLine("2 - XML");
                Console.WriteLine("3 - Key-Value Pairs");
                Console.WriteLine("0 - Exit");

                int formatChoice;
                bool isValidInput = int.TryParse(Console.ReadLine(), out formatChoice);

                // Handle exit condition
                if (formatChoice == 0)
                {
                    break;
                }

                // Ensure valid input and choose the serializer based on user input
                if (!isValidInput || formatChoice < 1 || formatChoice > 3)
                {
                    Console.WriteLine("Invalid selection! Please enter 1, 2, 3, or 0 to exit.");
                    continue;  // Ask for input again
                }

                // Select the serializer based on the number
                ISerializer<Employee> selectedSerializer = formatChoice switch
                {
                    1 => new JsonSerializer<Employee>(),
                    2 => new XmlSerializer<Employee>(),
                    3 => new KeyValuePairSerializer<Employee>(),
                    _ => throw new InvalidOperationException("Invalid format selection!")
                };

                // Generic serializer for Employee using the selected format
                var genericSerializer = new GenericSerializer<Employee>(selectedSerializer);

                // Serialize the Employee object
                string serializedData = genericSerializer.Serialize(employee);
                Console.WriteLine($"Serialized Data (Format {formatChoice}): {serializedData}");

                // Deserialize the data back into an Employee object
                var deserializedEmployee = genericSerializer.Deserialize(serializedData);
                Console.WriteLine($"Deserialized Data: {deserializedEmployee.FirstName}");
                Console.WriteLine();  // For better readability between iterations
            }
        }
    }
}