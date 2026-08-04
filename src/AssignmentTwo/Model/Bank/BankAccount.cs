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
        /// <param name="name">The account holders name</param>
        /// <param name="accountNumber">The account holder number</param>
        /// <param name="accountType">Type of the account</param>
        /// <param name="initialDeposit">The initial deposit should be put in to create an account</param>
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
        /// <value><see cref="Name"/>Containing the Name of the Account</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Account Number
        /// </summary>
        /// <value><see cref="AccountNumber"/>Containing the account number of the Account</value>
        public long AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets Account Type
        /// </summary>
        /// <value><see cref="AccountType"/>Containing the account type of the Account</value>
        public string AccountType { get; set; }

        /// <summary>
        /// Gets or sets Balance
        /// </summary>
        /// <value><see cref="Balance"/>Containing the Balance of the Account</value>
        public decimal Balance { get; set; }

        /// <summary>
        /// To deposit
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
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
