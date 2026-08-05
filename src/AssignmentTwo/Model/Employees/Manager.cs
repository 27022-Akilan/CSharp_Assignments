namespace AssignmentTwo.Model.Employees
{
    /// <summary>
    /// Manager Info
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="salary">salary</param>
        public Manager(string name, decimal salary)
            : base(name, salary, "Manager")
        {
        }

        /// <summary>
        /// This is for calculating Bonus
        /// </summary>
        /// <returns>decimal</returns>
        public override decimal CalculateBonus()
        {
            decimal rate = 0.1m;
            return (this.Salary * rate) + this.Salary;
        }
    }
}
