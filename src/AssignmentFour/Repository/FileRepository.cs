using System.Text.Json;
using AssignmentFour.Constants;
using AssignmentFour.Model;
using AssignmentFour.Model.Enums;
using AssignmentFour.Repository.RepositoryHelper;

namespace AssignmentFour.Repository
{
    /// <summary>
    /// Represents a file-based repository for data storage and retrieval.
    /// </summary>
    public class FileRepository : IRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();

        private string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository"/> class
        /// </summary>
        /// <param name="filePath">Contains the path the file to store and retrieve</param>
        public FileRepository(string filePath)
        {
            this._filePath = filePath;
            this._transactions = this.LoadTransactionsFromFile();
        }

        /// <summary>
        /// Adds the transaction to the repository.
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>A message that tells about the result of Adding the Transaction</returns>
        public string AddTransaction(Transaction transaction)
        {
            this._transactions.Add(transaction);
            this.SaveTransactionsToFile();
            return ResultMessages.AddSuccess;
        }

        /// <summary>
        /// To update the existing Transaction.
        /// </summary>
        /// <param name="transaction">Edited details of the Income</param>
        /// <returns>True - Updated Successfully | False - Cannot Update</returns>
        public bool UpdateIncome(Income transaction)
        {
            Income? incomeToBeUpdated = (Income?)this._transactions.FirstOrDefault(t => t.TransactionId == transaction.TransactionId && t.TransactionType == transaction.TransactionType);
            if (incomeToBeUpdated == null)
            {
                return false;
            }

            incomeToBeUpdated.Amount = transaction.Amount;
            incomeToBeUpdated.Date = transaction.Date;
            incomeToBeUpdated.Description = transaction.Description;
            incomeToBeUpdated.Source = transaction.Source;
            this.SaveTransactionsToFile();
            return true;
        }

        /// <summary>
        /// To update the existing Transaction.
        /// </summary>
        /// <param name="transaction">Edited details of the Expense</param>
        /// <returns>True - Updated Successfully | False - Cannot Update</returns>
        public bool UpdateExpense(Expense transaction)
        {
            Expense? expenseToBeUpdated = (Expense?)this._transactions.FirstOrDefault(t => t.TransactionId == transaction.TransactionId && t.TransactionType == transaction.TransactionType);
            if (expenseToBeUpdated == null)
            {
                return false;
            }

            expenseToBeUpdated.Amount = transaction.Amount;
            expenseToBeUpdated.Date = transaction.Date;
            expenseToBeUpdated.Description = transaction.Description;
            expenseToBeUpdated.Category = transaction.Category;
            this.SaveTransactionsToFile();
            return true;
        }

        /// <summary>
        /// To delete the Transaction using Id
        /// </summary>
        /// <param name="transactionId">Id of the transaction to be deleted</param>
        /// <returns>True if the transaction is found and deleted | False if the transaction cannot be deleted</returns>
        public bool DeleteTransactionById(Guid transactionId)
        {
            Transaction? transaction = this._transactions.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction == null)
            {
                return false;
            }

            this._transactions.Remove(transaction);
            this.SaveTransactionsToFile();
            return true;
        }

        /// <summary>
        /// Shows the entire transactions
        /// </summary>
        /// <returns>A cloned copy of all all transactions </returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._transactions.Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired type.
        /// </summary>
        /// <param name="type">Type of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified type</returns>
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
        {
            return this._transactions.Where(t => t.TransactionType == type)
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired amount
        /// </summary>
        /// <param name="amount">Amount of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified amount</returns>
        public IEnumerable<Transaction> GetTransactionsByAmount(decimal amount)
        {
            return this._transactions.Where(t => t.Amount == amount)
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired description
        /// </summary>
        /// <param name="description">Description of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified description</returns>
        public IEnumerable<Transaction> GetTransactionsByDescription(string description)
        {
            return this._transactions.Where(t => t.Description.Contains(description))
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired date
        /// </summary>
        /// <param name="date">Date of the transactions to retrieve</param>s
        /// <returns>IEnumerable list of Transactions of the specified date</returns>
        public IEnumerable<Transaction> GetTransactionsByDate(DateOnly date)
        {
            return this._transactions.Where(t => t.Date == date)
                                        .Select(t => t.CloneTransaction());
        }

        private List<Transaction> LoadTransactionsFromFile()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<Transaction>();
            }

            JsonSerializerOptions options = new JsonSerializerOptions();

            options.Converters.Add(new TransactionConverter());

            string json = File.ReadAllText(this._filePath);

            return JsonSerializer.Deserialize<List<Transaction>>(json, options) ?? new List<Transaction>();
        }

        private void SaveTransactionsToFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            options.Converters.Add(new TransactionConverter());

            string json = JsonSerializer.Serialize(this._transactions, options);

            File.WriteAllText(this._filePath, json);
        }
    }
}
