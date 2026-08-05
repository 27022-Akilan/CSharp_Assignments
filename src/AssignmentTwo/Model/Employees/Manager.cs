namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Represents Manager with additional properties and methods and also derived from the employee
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">Name of the Manager</param>
        /// <param name="salary">Salary of the Manager</param>
        public Manager(string name, decimal salary)
            : base(name, salary, "Manager")
        {
        }

        /// <summary>
        /// To calculate bonus of the Manager
        /// </summary>
        /// <returns>Decimal - Returns the Bonus of the Manager</returns>
        public override decimal CalculateBonus()
        {
            decimal rate = 0.1m;
            return (this.Salary * rate) + this.Salary;
        }
    }
}
