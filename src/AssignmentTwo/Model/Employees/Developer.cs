namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Represents Developer with additional properties and methods and also derived from the employee
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">Name of the Developer</param>
        /// <param name="salary">Salary of the Developer</param>
        public Developer(string name, decimal salary)
            : base(name, salary, "Developer")
        {
        }

        /// <summary>
        /// To calculate bonus of the developer
        /// </summary>
        /// <returns>Decimal - Returns the bonus</returns>
        public override decimal CalculateBonus()
        {
            decimal rate = 0.2m;
            return (this.Salary * rate) + this.Salary;
        }
    }
}
