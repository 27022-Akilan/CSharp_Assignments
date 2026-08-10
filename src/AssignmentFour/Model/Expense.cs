using AssignmentFour.Model.Enums;

namespace AssignmentFour.Model
{
    /// <summary>
    /// A derived class for the expense
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class
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
        /// Overrides the base method to create the Expense object with correct ID.
        /// </summary>
        /// <param name="id">Id of the transaction</param>
        /// <returns>A Income object</returns>
        public override Transaction CreateTransactionWithId(Guid id)
        {
            return new Expense(id, this.Amount, this.Description, this.Date, this.Category);
        }
    }
}
