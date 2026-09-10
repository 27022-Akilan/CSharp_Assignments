using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model.RequestModel
{
    /// <summary>
    /// Represents a request model for the Expense.
    /// </summary>
    public class ExpenseRequestModel : TransactionRequestModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseRequestModel"/> class.
        /// </summary>
        /// <param name="amount">Amount of the expense.</param>
        /// <param name="description">Description of the expense.</param>
        /// <param name="date">Date of the expense.</param>
        /// <param name="category">Category of the expense.</param>
        public ExpenseRequestModel(decimal amount, string description, DateOnly date, Category category)
            : base(amount, TransactionType.Expense, description, date)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets the Source
        /// </summary>
        /// <value>Contains the category of the expense</value>
        public Category Category { get; }
    }
}
