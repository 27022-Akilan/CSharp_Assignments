using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model
{
    /// <summary>
    /// Represents a  class for the expense.
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="id">Id of the Expense</param>
        /// <param name="amount">Amount of the expense.</param>
        /// <param name="description">Description of the expense.</param>
        /// <param name="date">Date of the expense.</param>
        /// <param name="category">Category of the expense</param>
        public Expense(Guid id, decimal amount, string description, DateOnly date, Category category)
            : base(id, amount, TransactionType.Expense, description, date)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// Contains the category of the expense(food,travel..)</value>
        public Category Category { get; set; }

        /// <summary>
        ///  To return a cloned copy of the Expense.
        /// </summary>
        /// <returns>Cloned copy of Expense</returns>
        public override Transaction CloneTransaction()
        {
            return new Expense(this.TransactionId, this.Amount, this.Description, this.Date, this.Category);
        }
    }
}
