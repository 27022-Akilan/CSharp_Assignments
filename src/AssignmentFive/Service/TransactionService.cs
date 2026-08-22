using AssignmentFive.Constants;
using AssignmentFive.Model;
using AssignmentFive.Model.DTO;
using AssignmentFive.Model.Enums;
using AssignmentFive.Repository;

namespace AssignmentFive.Service
{
    /// <summary>
    /// Provides services to the Expense tracker application
    /// </summary>
    public class TransactionService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class
        /// </summary>
        /// <param name="repository">Repository object</param>
        public TransactionService(IRepository repository)
        {
            this._repository = repository;
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
                return Messages.AddFailedDueToNull;
            }

            if (!this.IsValidAmount(transaction.Amount))
            {
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
                return this._repository.AddTransaction(transactionWithId);
            }

            if (transaction is ExpenseRequestModel)
            {
                transactionWithId = new Expense(
                    Guid.NewGuid(),
                    transaction.Amount,
                    transaction.Description,
                    transaction.Date,
                    ((ExpenseRequestModel)transaction).Category);
                return this._repository.AddTransaction(transactionWithId);
            }

            return Messages.CantAddDueToInvalidType;
        }

        /// <summary>
        /// Updates the Transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>True - If transaction is Updated | False - If transaction can not be updated </returns>
        public bool Update(Transaction transaction)
        {
            if (transaction == null || !this.IsValidAmount(transaction.Amount))
            {
                return false;
            }

            if (transaction is Income)
            {
                return this._repository.UpdateIncome((Income)transaction);
            }
            else if (transaction is Expense)
            {
                return this._repository.UpdateExpense((Expense)transaction);
            }

            return false;
        }

        /// <summary>
        /// Deletes the transaction by id.
        /// </summary>
        /// <param name="id">Guid of the transaction to be deleted</param>
        /// <returns>bool True - Transaction deleted | False - Transaction cannot delete</returns>
        public bool DeleteTransactionById(Guid id)
        {
            return this._repository.DeleteTransactionById(id);
        }

        /// <summary>
        /// Gets the List of transactions which cannot be modified.
        /// </summary>
        /// <returns>List of all transactions</returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._repository.GetAllTransactions();
        }

        /// <summary>
        /// Gets the List of transactions by type which cannot be modified.
        /// </summary>
        /// <param name="type">Type of transactions to retrieve</param>
        /// <returns>List of transactions of the specified type</returns>
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
        {
            return this._repository.GetTransactionsByType(type);
        }

        /// <summary>
        /// Gets the List of transactions by amount which cannot be modified.
        /// </summary>
        /// <param name="amount">Amount of transactions to retrieve</param>
        /// <returns>List of transactions of the specified amount</returns>
        public IEnumerable<Transaction> GetTransactionsByAmount(decimal amount)
        {
            return this._repository.GetTransactionsByAmount(amount);
        }

        /// <summary>
        /// Gets the List of transactions by description which cannot be modified.
        /// </summary>
        /// <param name="description">Description of transactions to retrieve</param>
        /// <returns>List of Transactions of the specified description</returns>
        public IEnumerable<Transaction> GetTransactionsByDescription(string description)
        {
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
            return this._repository.GetTransactionsByDate(date);
        }

        /// <summary>
        /// Gets the summary of all transactions
        /// </summary>
        /// <returns>Summary object</returns>
        public Summary GetSummary()
        {
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
