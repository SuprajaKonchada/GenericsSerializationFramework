using SerializationFramework.Attributes;

namespace SerializationFramework.Models
{
    /// <summary>
    /// Represents an employee entity with relevant details.
    /// </summary>
    [SerializableEntity]
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the department where the employee works.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is a permanent employee.
        /// </summary>
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        public float Salary { get; set; }
    }
}
