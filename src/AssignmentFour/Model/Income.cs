namespace AssignmentFour.Model
{
    /// <summary>
    /// Derived class for the Income
    /// </summary>
    public class Income : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class
        /// </summary>
        /// <param name="id">Contains the Id of the Transaction</param>
        /// <param name="amount">Contains the Amount</param>
        /// <param name="description">Contains the Description</param>
        /// <param name="dateTime">Contains the date and Time</param>
        /// <param name="source">Contains the source of the Income</param>
        public Income(Guid id, decimal amount, string description, DateTime dateTime, string source)
            : base(id, amount, Type.Income, description, dateTime)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets or sets the Source for the income
        /// </summary>
        /// <value>
        /// Contains the Source for the Income</value>
        public string Source { get; set; }
    }
}
