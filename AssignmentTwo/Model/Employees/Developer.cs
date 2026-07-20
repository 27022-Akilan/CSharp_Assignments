namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Developer inherits Employee
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="salary">salary</param>
        public Developer(string name, double salary)
            : base(name, salary, "Developer")
        {
        }

        /// <summary>
        /// THis is for calculating Bonus
        /// </summary>
        /// <returns>double</returns>
        public override double CalculateBonus()
        {
            return (this.Salary * 0.2) + this.Salary;
        }
    }
}
