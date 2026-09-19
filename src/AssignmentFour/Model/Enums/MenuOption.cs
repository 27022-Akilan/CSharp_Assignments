namespace AssignmentFour.Model.Enums
{
    /// <summary>
    /// Provides enums for the MenuOption.
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Option to add a new Income.
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// Option to add a new Expense.
        /// </summary>
        AddExpense,

        /// <summary>
        /// Option to update a transaction.
        /// </summary>
        UpdateTransaction,

        /// <summary>
        /// Option to delete a transaction.
        /// </summary>
        DeleteTransaction,

        /// <summary>
        /// Option to search a transaction.
        /// </summary>
        SearchTransaction,

        /// <summary>
        /// Option to show all transaction.
        /// </summary>
        ShowTransactions,

        /// <summary>
        /// Option to show summary of all transaction
        /// </summary>
        ShowSummary,

        /// <summary>
        /// Option to exit the menu
        /// </summary>
        Exit,
    }
}
