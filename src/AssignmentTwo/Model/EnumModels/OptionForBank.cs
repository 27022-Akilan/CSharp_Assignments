namespace AssignmentTwo.Model.EnumModels
{
    /// <summary>
    /// Options for the Bank
    /// </summary>
    public enum BankOptions
    {
        /// <summary>
        /// Option to create and view Savings account.
        /// </summary>
        CreateAndViewSavingsAccount = 1,

        /// <summary>
        /// Option to create and view Checking account.
        /// </summary>
        CreateAndViewCheckingAccount = 2,

        /// <summary>
        /// Option to exit from bank menu
        /// </summary>
        Exit = 3,
    }

    /// <summary>
    /// Operation for the bank operation
    /// </summary>
    public enum BankOperation
    {
        /// <summary>
        /// Option for deposit
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Option for withdraw
        /// </summary>
        Withdraw = 2,

        /// <summary>
        /// Option for PrintDetails
        /// </summary>
        PrintDetails = 3,

        /// <summary>
        /// Option for Exit
        /// </summary>
        Exit = 4,
    }
}
