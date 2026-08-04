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
        public Developer(string name, decimal salary)
            : base(name, salary, "Developer")
        {
        }

        /// <summary>
        /// This is for calculating Bonus
        /// </summary>
        /// <returns>decimal</returns>
        public override decimal CalculateBonus()
        {
            double rate = 0.2;
            return (this.Salary * (decimal)rate) + this.Salary;
        }
    }
}
