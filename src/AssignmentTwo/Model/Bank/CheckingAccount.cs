namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    /// Represents Checking account with additional properties and methods and also derived from the BankAccount
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="accountNumber">Account holders account number</param>
        /// <param name="initialDeposit">The initial deposit that should be deposited to create an account</param>
        public CheckingAccount(string name, long accountNumber, decimal initialDeposit)
            : base(name, accountNumber, "Checking", initialDeposit)
        {
        }

        /// <summary>
        /// To withdraw amount from the Checking account and it is overridden.
        /// </summary>
        /// <param name="amount">Amount that should be withdrawn</param>
        /// <returns>String that holds the status of withdrawal</returns>
        public override string WithdrawFromAccount(decimal amount)
        {
            this.Balance -= amount;
            return string.Empty;
        }
    }
}
