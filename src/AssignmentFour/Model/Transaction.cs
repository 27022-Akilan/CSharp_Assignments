namespace AssignmentFour.Model
{
    /// <summary>
    /// A base class for the Expense and Income
    /// </summary>
    public abstract class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class
        /// </summary>
        /// <param name="id">Contains the Id of the Transaction</param>
        /// <param name="amount">Contains the Amount</param>
        /// <param name="type">Type of the account (Income / Expense)</param>
        /// <param name="description">Contains the Description</param>
        /// <param name="dateTime">Contains the date and Time</param>
        public Transaction(Guid id, decimal amount, Type type, string description, DateTime dateTime)
        {
            this.TransactionId = id;
            this.Amount = amount;
            this.TransactionType = type;
            this.Description = description;
            this.Date = dateTime;
        }

        /// <summary>
        /// Gets TransactionId
        /// </summary>
        /// <value>
        /// It holds the Transaction Id.
        /// </value>
        public Guid TransactionId { get; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        /// <value>
        /// It holds the Amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        /// /// <value>
        /// It holds the Type of the Transaction.
        /// </value>
        public Type TransactionType { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        /// <value>
        /// Hold the description
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        /// <value>
        /// Holds the Date 
        /// </value>
        public DateTime Date { get; set; }
    }
}
