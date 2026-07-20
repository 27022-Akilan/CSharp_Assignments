namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Abstract class for Employee
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="salary">salary</param>
        /// <param name="designation">designation</param>
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
        /// Prints the details of the class
        /// </summary>
        /// <returns>string</returns>
        public string PrintDetails()
        {
            return $"Name : {this.Name} , Designation: {this.Designation} , Salary : {this.Salary} and the Bonus : {this.CalculateBonus()}";
        }

        /// <summary>
        /// this is a abstract method for calculate area
        /// </summary>
        /// <returns>long</returns>
        public abstract decimal CalculateBonus();
    }
}
