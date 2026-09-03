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
        /// <param name="amount">Contains amount</param>
        /// <param name="description">Contains description</param>
        /// <param name="date">Contains date</param>
        /// <param name="category">Contains source</param>
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
