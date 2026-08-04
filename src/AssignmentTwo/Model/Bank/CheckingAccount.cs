namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    /// Derived from BankAccount
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Stores the minimum balance that should be maintained.
        /// </summary>
        public const decimal MinimumBalance = 0;

        /// <summary>
        /// Stores thr minimum deposit that should be deposited while creating an account.
        /// </summary>
        public const decimal MinimumInitialDeposit = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="accountNumber">account number</param>
        /// <param name="initialDeposit">initial deposit</param>
        public CheckingAccount(string name, long accountNumber, decimal initialDeposit)
            : base(name, accountNumber, "Checking", initialDeposit)
        {
        }

        /// <summary>
        /// To withdraw and it is overridden
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>Status of withdrawal</returns>
        public override string WithdrawFromAccount(decimal amount)
        {
            this.Balance -= amount;
            return "Withdrawn Successfully.";
        }
    }
}
