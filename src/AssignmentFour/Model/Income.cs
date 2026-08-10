using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model
{
    /// <summary>
    /// Derived class for the Income.
    /// </summary>
    public class Income : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="id">Contains the Id of the Transaction</param>
        /// <param name="amount">Contains the Amount</param>
        /// <param name="description">Contains the Description</param>
        /// <param name="date">Contains the date and Time</param>
        /// <param name="source">Contains the source of the Income</param>
        public Income(Guid id, decimal amount, string description, DateOnly date, Source source)
            : base(id, amount, TransactionType.Income, description, date)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets or sets the Source for the income.
        /// </summary>
        /// <value>Contains the Source for the Income</value>
        public Source Source { get; set; }

        /// <summary>
        ///  To return a cloned copy of the Income.
        /// </summary>
        /// <returns>Cloned copy of Income</returns>
        public override Transaction CloneTransaction()
        {
            return new Income(this.TransactionId, this.Amount, this.Description, this.Date, this.Source);
        }
    }
}
