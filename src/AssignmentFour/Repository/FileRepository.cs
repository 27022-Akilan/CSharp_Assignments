using AssignmentFour.Model;
using AssignmentFour.Model.Enums;

namespace AssignmentFour.Repository
{
    /// <summary>
    /// Represents a file-based repository for data storage and retrieval.
    /// </summary>
    public class FileRepository : IRepository
    {
        private List<Transaction> _transactionList = new List<Transaction>();

        /// <summary>
        ///  Adds a new Transaction.
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>bool True - Added successfully | False - Cannot Add</returns>
        public string AddTransaction(Transaction transaction)
        {
            return "Transaction added successfully.";
        }

        /// <summary>
        /// Updates a Transaction.
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>True - Updated successfully | False - Cannot Update</returns>
        public bool UpdateTransaction(Transaction transaction)
        {
            return false;
        }

        /// <summary>
        /// Deletes a transaction by the ID.
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted</param>
        /// <returns>True - Deleted successfully | False - Cannot Delete</returns>
        public bool DeleteTransactionById(Guid id)
        {
            return true;
        }

        /// <summary>
        /// To show the entire transactions (Income , Expense).
        /// </summary>
        /// <returns>Enumerable List of transactions which cant be modified</returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._transactionList;
        }

        /// <summary>
        /// To show the transactions by type (Income , Expense).
        /// </summary>
        /// <param name="type">Type of the transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified type</returns>
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
        {
            return this._transactionList;
        }

        /// <summary>
        /// Gets the list of transactions based on the amount.
        /// </summary>
        /// <param name="amount">Amount of the transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified amount</returns>
        public IEnumerable<Transaction> GetTransactionsByAmount(decimal amount)
        {
            return this._transactionList;
        }

        /// <summary>
        /// Gets the list of transactions based on the description.
        /// </summary>
        /// <param name="description">Description of the transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified description</returns>
        public IEnumerable<Transaction> GetTransactionsByDescription(string description)
        {
            return this._transactionList;
        }

        /// <summary>
        /// Gets the list of transactions based on the date.
        /// </summary>
        /// <param name="date">Date of the transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified date</returns>
        public IEnumerable<Transaction> GetTransactionsByDate(DateOnly date)
        {
            return this._transactionList;
        }
    }
}
