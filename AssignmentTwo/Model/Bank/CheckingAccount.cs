namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    /// Derived from BankAccount
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="accountNuber">account number</param>
        /// <param name="initialDeposit">initial deposit</param>
        public CheckingAccount(string name, long accountNuber, decimal initialDeposit)
            : base(name, accountNuber, "Checking", initialDeposit)
        {
        }

        /// <summary>
        /// To withdraw and it is overridden
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>Status of withdrawal</returns>
        public override string WithdrawFromAccount(decimal amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
                return "Witdrawed Successfully.";
            }

            return $"Insufficiant Balance !!! Balance is: {this.Balance}";
        }
    }
}
