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
        public Manager(string name, double salary)
            : base(name, salary, "Manager")
        {
        }

        /// <summary>
        /// THis is for calculating Bonus
        /// </summary>
        /// <returns>double</returns>
        public override double CalculateBonus()
        {
            return (this.Salary * 0.1) + this.Salary;
        }
    }
}
