using AssignmentFive.Model.Enums;

namespace AssignmentFive.Model.DTO
{
    /// <summary>
    /// Represents a base request model.
    /// </summary>
    public class TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRequestModel"/> class.
        /// </summary>
        /// <param name="amount">Contains the Amount</param>
        /// <param name="type">Type of the account (Income / Expense)</param>
        /// <param name="description">Contains the Description</param>
        /// <param name="date">Contains the date and Time</param>
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
