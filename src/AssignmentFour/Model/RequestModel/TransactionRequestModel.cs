using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model.RequestModel
{
    /// <summary>
    /// Represents a base request model.
    /// </summary>
    public class TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRequestModel"/> class.
        /// </summary>
        /// <param name="amount">Amount of the transaction.</param>
        /// <param name="type">Type of the account (Income / Expense)</param>
        /// <param name="description">Description of the transaction.</param>
        /// <param name="date">Date of the transaction.</param>
        public TransactionRequestModel(decimal amount, TransactionType type, string description, DateOnly date)
        {
            this.Amount = amount;
            this.TransactionType = type;
            this.Description = description;
            this.Date = date;
        }

        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        /// <value>
        /// It holds the Amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets Type of the Transaction.
        /// </summary>
        /// <value>
        /// Holds the Type of the Transaction.
        /// </value>
        public TransactionType TransactionType { get; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        /// <value>
        /// Hold the description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// Holds the Date.
        /// </value>
        public DateOnly Date { get; set; }
    }
}
