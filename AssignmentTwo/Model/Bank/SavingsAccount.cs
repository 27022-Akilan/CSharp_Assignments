namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    /// Derived from BankAccount
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="accountNumber">account number</param>
        /// <param name="initialDeposit">initial deposit</param>
        public SavingsAccount(string name, long accountNumber, decimal initialDeposit)
            : base(name, accountNumber, "Savings", initialDeposit)
        {
        }

        /// <summary>
        /// To whitdraw and its overrided
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>Status of withdrawal</returns>
        public override string WithdrawFromAccount(decimal amount)
        {
            if (this.Balance - amount >= 2000)
            {
                this.Balance -= amount;
                return "Witdrawed Successfully.";
            }

            return $"Cant Withdraw Minimum Your Account Should Have 2000 \n Your Current Balance Is{this.Balance}";
        }
    }
}
