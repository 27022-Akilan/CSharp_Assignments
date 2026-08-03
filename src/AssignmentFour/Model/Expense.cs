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
        /// <param name="dateTime">Contains the date and Time</param>
        /// <param name="category">Contains the category of the expense</param>
        public Expense(Guid id, decimal amount, string description, DateTime dateTime, string category)
            : base(id, amount, Type.Expense, description, dateTime)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// Contains the category of the expense(food,travel..)</value>
        public string Category { get; set; }
    }
}
