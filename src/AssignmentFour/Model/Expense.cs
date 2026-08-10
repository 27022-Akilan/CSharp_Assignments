using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model
{
    /// <summary>
    /// A derived class for the expense
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="id">Contains the Id of the Transaction</param>
        /// <param name="amount">Contains the Amount</param>
        /// <param name="description">Contains the Description</param>
        /// <param name="date">Contains the date and Time</param>
        /// <param name="category">Contains the category of the expense</param>
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
