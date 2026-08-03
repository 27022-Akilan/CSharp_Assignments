namespace AssignmentTwo.Model.Bank
{
    /// <summary>
    /// Base Account
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="accountNumber">account number</param>
        /// <param name="accountType">account type</param>
        /// <param name="initialDeposit">initial deposit</param>
        public BankAccount(string name, long accountNumber, string accountType, decimal initialDeposit)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.Balance = initialDeposit;
        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value><see cref="Name"/>containing the Name of the Account</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Account Number
        /// </summary>
        /// <value><see cref="AccountNumber"/>containing the AccountNumber of the Account</value>
        public long AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets Account Type
        /// </summary>
        /// <value><see cref="AccountType"/>containing the AccountType of the Account</value>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets Balance
        /// </summary>
        /// <value><see cref="Balance"/>containing the Balance of the Account</value>
        public decimal Balance { get; set; }

        /// <summary>
        /// To deposit
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <returns> string </returns>
        public virtual string DepositIntoAccount(decimal amount)
        {
            this.Balance += amount;
            return "Deposited SuccessFully";
        }

        /// <summary>
        /// To print details of the account.
        /// </summary>
        /// <returns>string</returns>
        public string PrintDetails()
        {
            return $"Name : {this.Name} , Account Number: {this.AccountNumber} , AccountType : {this.AccountType} , Balance : {this.Balance}";
        }

        /// <summary>
        /// To be implemented in child class
        /// </summary>
        /// <param name="amount">amount</param>
        /// <returns>status of withdrawal</returns>
        public abstract string WithdrawFromAccount(decimal amount);
    }
}
