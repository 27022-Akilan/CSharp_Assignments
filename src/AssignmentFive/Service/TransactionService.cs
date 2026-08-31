using AssignmentFive.Constants;
using AssignmentFive.Model;
using AssignmentFive.Model.DTO;
using AssignmentFive.Model.Enums;
using AssignmentFive.Repository;
using AssignmentFive.Repository.Log;

namespace AssignmentFive.Service
{
    /// <summary>
    /// Provides services to the Expense tracker application
    /// </summary>
    public class TransactionService
    {
        private readonly IRepository _repository;

        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class
        /// </summary>
        /// <param name="repository">Repository instance</param>
        /// <param name="logger">Logger instance</param>>
        public TransactionService(IRepository repository, ILogger logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        /// <summary>
        ///  Adds the Transaction to the Repository
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>String - Empty string for success otherwise a message for the representing the failure</returns>
        public string AddTransaction(TransactionRequestModel transaction)
        {
            if (transaction == null)
            {
                this._logger.LogWarning("AddTransaction rejected due to null transaction request");
                return Messages.AddFailedDueToNull;
            }

            if (!this.IsValidAmount(transaction.Amount))
            {
                this._logger.LogWarning($"AddTransaction Rejected due to invalid Amount {transaction.Amount}");
                return Messages.AddFailedDueToInvalidAmount;
            }

            Transaction transactionWithId;
            if (transaction is IncomeRequestModel)
            {
                transactionWithId = new Income(
                    Guid.NewGuid(),
                    transaction.Amount,
                    transaction.Description,
                    transaction.Date,
                    ((IncomeRequestModel)transaction).Source);
                this._logger.LogInfo($"Income added with ID{transactionWithId.TransactionId} and Amount {transaction.Amount}");
                return this._repository.AddTransaction(transactionWithId);
            }
            else if (transaction is ExpenseRequestModel)
            {
                transactionWithId = new Expense(
                    Guid.NewGuid(),
                    transaction.Amount,
                    transaction.Description,
                    transaction.Date,
                    ((ExpenseRequestModel)transaction).Category);
                this._logger.LogInfo($"Expense added with ID{transactionWithId.TransactionId} and Amount {transaction.Amount}");
                return this._repository.AddTransaction(transactionWithId);
            }

            this._logger.LogWarning($"AddTransaction rejected due invalid transaction type");
            return Messages.CantAddDueToInvalidType;
        }

        /// <summary>
        /// Updates the Transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>True - If transaction is Updated | False - If transaction can not be updated </returns>
        public bool Update(Transaction transaction)
        {
            if (transaction == null)
            {
                this._logger.LogWarning("UpdateTransaction rejected due to null transaction request");
                return false;
            }

            if (!this.IsValidAmount(transaction.Amount))
            {
                this._logger.LogWarning($"UpdateTransaction Rejected due to invalid Amount {transaction.Amount}");
                return false;
            }

            bool result = false;
            if (transaction is Income)
            {
                result = this._repository.UpdateIncome((Income)transaction);
            }
            else if (transaction is Expense)
            {
                result = this._repository.UpdateExpense((Expense)transaction);
            }

            if (result)
            {
                this._logger.LogInfo($"{transaction.TransactionId} : Updated Successfully");
                return result;
            }

            this._logger.LogError($"{transaction.TransactionId} : Cant Update");
            return result;
        }

        /// <summary>
        /// Deletes the transaction by id.
        /// </summary>
        /// <param name="id">Guid of the transaction to be deleted</param>
        /// <returns>bool True - Transaction deleted | False - Transaction cannot delete</returns>
        public bool DeleteTransactionById(Guid id)
        {
            bool result = this._repository.DeleteTransactionById(id);
            if (result)
            {
                this._logger.LogInfo($"{id} : Deleted successfully");
                return result;
            }

            this._logger.LogError($"{id} : Deleted successfully");
            return result;
        }

        /// <summary>
        /// Gets the List of transactions which cannot be modified.
        /// </summary>
        /// <returns>List of all transactions</returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            this._logger.LogInfo("Fetching all transactions.....");
            return this._repository.GetAllTransactions();
        }

        /// <summary>
        /// Gets the List of transactions by type which cannot be modified.
        /// </summary>
        /// <param name="type">Type of transactions to retrieve</param>
        /// <returns>List of transactions of the specified type</returns>
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
        {
            this._logger.LogInfo($"Fetching transaction by {type}.....");
            return this._repository.GetTransactionsByType(type);
        }

        /// <summary>
        /// Gets the List of transactions by amount which cannot be modified.
        /// </summary>
        /// <param name="amount">Amount of transactions to retrieve</param>
        /// <returns>List of transactions of the specified amount</returns>
        public IEnumerable<Transaction> GetTransactionsByAmount(decimal amount)
        {
            this._logger.LogInfo($"Fetching transactions by {amount}.....");
            return this._repository.GetTransactionsByAmount(amount);
        }

        /// <summary>
        /// Gets the List of transactions by description which cannot be modified.
        /// </summary>
        /// <param name="description">Description of transactions to retrieve</param>
        /// <returns>List of Transactions of the specified description</returns>
        public IEnumerable<Transaction> GetTransactionsByDescription(string description)
        {
            this._logger.LogInfo($"Fetching transactions by {description}.....");
            if (string.IsNullOrWhiteSpace(description))
            {
                return Enumerable.Empty<Transaction>();
            }

            return this._repository.GetTransactionsByDescription(description);
        }

        /// <summary>
        /// Gets the List of transactions by date which cannot be modified.
        /// </summary>
        /// <param name="date">Date of the transactions to retrieve</param>
        /// <returns>List of Transactions of the specified date</returns>
        public IEnumerable<Transaction> GetTransactionByDate(DateOnly date)
        {
            this._logger.LogInfo($"Fetching transactions by {date}.....");
            return this._repository.GetTransactionsByDate(date);
        }

        /// <summary>
        /// Gets the summary of all transactions
        /// </summary>
        /// <returns>Summary object</returns>
        public Summary GetSummary()
        {
            this._logger.LogInfo($"Calculating the summary.....");
            decimal income = this.GetTotalIncome();
            decimal expense = this.GetTotalExpense();
            decimal netBalance = income - expense;
            var transactions = this.GetAllTransactions();
            int totalTransactions = transactions.Count();
            decimal averageTransactionValue = totalTransactions > 0 ? transactions.Average(t => t.Amount) : 0;
            return new Summary(income, expense, netBalance, totalTransactions, averageTransactionValue);
        }

        /// <summary>
        /// Gets the total income.
        /// </summary>
        /// <returns>Decimal value representing total income</returns>
        public decimal GetTotalIncome()
        {
            return this._repository.GetTransactionsByType(TransactionType.Income).Sum(t => t.Amount);
        }

        /// <summary>
        /// Gets the total expense.
        /// </summary>
        /// <returns>Total expense</returns>
        public decimal GetTotalExpense()
        {
            return this._repository.GetTransactionsByType(TransactionType.Expense).Sum(t => t.Amount);
        }

        /// <summary>
        /// Gets the net balance
        /// </summary>
        /// <returns>Net balance</returns>
        public decimal GetNetBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }

        /// <summary>
        /// Checks whether the amount is valid.
        /// </summary>
        /// <param name="amount">Amount to be validated</param>
        /// <returns>True - If validation success | False - Validation Failed</returns>
        public bool IsValidAmount(decimal amount)
        {
            return amount >= Value.MinimumAmount;
        }

        /// <summary>
        /// Validates Date if its less than the current date
        /// </summary>
        /// <param name="date">Date to be validated</param>
        /// <returns>True - If validation success | False - Validation Failed</returns>
        public bool IsValidDate(DateOnly date)
        {
            return date <= DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
