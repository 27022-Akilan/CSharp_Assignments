namespace AssignmentFour.Model
{
    /// <summary>
    /// Represents the summary of all transactions.
    /// </summary>
    public class Summary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Summary"/> class.
        /// </summary>
        /// <param name="totalIncome">The total income</param>
        /// <param name="totalExpense">The total expense</param>
        /// <param name="netBalance">The net balance</param>
        /// <param name="totalTransactions">The total number of transactions</param>
        /// <param name="averageTransactionValue">The average transaction value</param>
        public Summary(decimal totalIncome, decimal totalExpense, decimal netBalance, int totalTransactions, decimal averageTransactionValue)
        {
            this.TotalIncome = totalIncome;
            this.TotalExpense = totalExpense;
            this.NetBalance = netBalance;
            this.TotalTransactions = totalTransactions;
            this.AverageTransactionValue = averageTransactionValue;
        }

        /// <summary>
        /// Gets the total income.
        /// </summary>
        /// <value>
        /// It holds the Total Income.
        /// </value>
        public decimal TotalIncome { get; }

        /// <summary>
        /// Gets the total expense.
        /// </summary>
        /// /// <value>
        /// It holds the Total Expense.
        /// </value>
        public decimal TotalExpense { get; }

        /// <summary>
        /// Gets the net balance.
        /// </summary>
        /// <value>
        /// It holds the Net Balance.
        /// </value>
        public decimal NetBalance { get; }

        /// <summary>
        /// Gets the total transactions count.
        /// </summary>
        /// <value>
        /// It holds the Total Transactions Count.
        /// </value>
        public int TotalTransactions { get; }

        /// <summary>
        /// Gets the average transaction value.
        /// </summary>
        /// <value>
        /// It holds the Average Transaction Value.
        /// </value>
        public decimal AverageTransactionValue { get; }
    }
}
