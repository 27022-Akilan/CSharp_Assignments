namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Represents a generic Employee with basic properties and methods.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        /// <param name="name">Name of the Employee</param>
        /// <param name="salary">Salary of the Employee</param>
        /// <param name="designation">Designation of the Employee</param>
        public Employee(string name, decimal salary, string designation)
        {
            this.Name = name;
            this.Salary = salary;
            this.Designation = designation;
        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the Name of the Employee.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Salary
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the Salary of the Employee.
        /// </value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets Designation
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the Designation of the Employee.
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        ///  To print the details of the Employee
        /// </summary>
        /// <returns>string</returns>
        public string PrintDetails()
        {
            return $"Name : {this.Name} , Designation: {this.Designation} , Salary : {this.Salary} , Salary(+Bonus) : {this.CalculateBonus()}";
        }

        /// <summary>
        ///  An abstract method for calculating bonus
        /// </summary>
        /// <returns>Decimal - Returns the Bonus of the Employee</returns>
        public abstract decimal CalculateBonus();
    }
}
