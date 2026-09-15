namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    ///  Represents Savings account with additional properties and methods and also derived from the BankAccount
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the Account holder</param>
        /// <param name="accountNumber">Account number</param>
        /// <param name="initialDeposit">Initial deposit that should be deposited to create savings account</param>
        public SavingsAccount(string name, long accountNumber, decimal initialDeposit)
            : base(name, accountNumber, "Savings", initialDeposit)
        {
        }

        /// <summary>
        /// To Withdraw amount and this method is overridden
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>Status of withdrawal</returns>
        public override string WithdrawFromAccount(decimal amount)
        {
            this.Balance -= amount;
            return string.Empty;
        }
    }
}
