using AssignmentFour.Model;
using AssignmentFour.Model.Enums;

namespace AssignmentFour.Repository
{
    /// <summary>
    /// Repository for storing the Transaction Details.
    /// </summary>
    public class TransactionRepository : IRepository
    {
        // private Transaction? _transaction;
        private List<Transaction> _transactionList = new List<Transaction>();

        /// <summary>
        /// Adds the transaction to the repository.
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>A message that tells about the result of Adding the Transaction</returns>
        public string AddTransaction(Transaction transaction)
        {
            this._transactionList.Add(transaction);

            return Messages.AddSuccess;
        }

        /// <summary>
        /// To update the existing Transaction.
        /// </summary>
        /// <param name="transaction">Edited details of the Transaction</param>
        /// <returns>True - Updated Successfully | False - Cannot Update</returns>
        public bool UpdateTransaction(Transaction transaction)
        {
            foreach (Transaction field in this._transactionList)
            {
                if (field.TransactionId == transaction.TransactionId)
                {
                    field.Amount = transaction.Amount;
                    field.Date = transaction.Date;
                    field.Description = transaction.Description;

                    if (transaction.TransactionType == TransactionType.Income)
                    {
                        ((Income)field).Source = ((Income)transaction).Source;
                    }
                    else if (transaction.TransactionType == TransactionType.Expense)
                    {
                        ((Expense)field).Category = ((Expense)transaction).Category;
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// To delete the Transaction using Id
        /// </summary>
        /// <param name="transactionId">Id of the transaction to be deleted</param>
        /// <returns>True if the transaction found and deleted | False if the transaction cant be deleted</returns>
        public bool DeleteTransactionById(Guid transactionId)
        {
            Transaction? transaction = this._transactionList.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction == null)
            {
                return false;
            }

            this._transactionList.Remove(transaction);
            return true;
        }

        /// <summary>
        /// Shows the entire transactions
        /// </summary>
        /// <returns>A cloned copy of all all transactions </returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._transactionList.Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired type.
        /// </summary>
        /// <param name="type">Type of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified type</returns>
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
        {
            return this._transactionList.Where(t => t.TransactionType == type)
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired amount
        /// </summary>
        /// <param name="amount">Amount of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified amount</returns>
        public IEnumerable<Transaction> GetTransactionsByAmount(decimal amount)
        {
            return this._transactionList.Where(t => t.Amount == amount)
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired description
        /// </summary>
        /// <param name="description">Description of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified description</returns>
        public IEnumerable<Transaction> GetTransactionsByDescription(string description)
        {
            return this._transactionList.Where(t => t.Description.Contains(description))
                                        .Select(t => t.CloneTransaction());
        }

        /// <summary>
        /// Shows the transactions of the desired date
        /// </summary>
        /// <param name="date">Date of the transactions to retrieve</param>s
        /// <returns>IEnumerable list of Transactions of the specified date</returns>
        public IEnumerable<Transaction> GetTransactionsByDate(DateOnly date)
        {
            return this._transactionList.Where(t => t.Date == date)
                                        .Select(t => t.CloneTransaction());
        }
    }
}