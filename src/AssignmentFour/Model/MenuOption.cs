namespace AssignmentFour.Model
{
    /// <summary>
    /// Provides enums for the MenuOption
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Option for Adding a new Income
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// Option for Adding a new Expense
        /// </summary>
        AddExpense = 1,

        /// <summary>
        /// Option for Updating a transaction
        /// </summary>
        UpdateTransaction,

        /// <summary>
        /// Option for deleting a transaction
        /// </summary>
        DeleteTransaction,

        /// <summary>
        /// Option for Show all transaction
        /// </summary>
        ShowTransaction,

        /// <summary>
        /// Option for exiting the menu
        /// </summary>
        Exit,
    }
}
