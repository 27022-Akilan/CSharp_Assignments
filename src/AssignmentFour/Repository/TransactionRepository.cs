using AssignmentFour.Constants;
using AssignmentFour.Model;
using AssignmentFour.Model.Enums;

namespace AssignmentFour.Repository
{
    /// <summary>
    /// Repository for storing the Transaction Details.
    /// </summary>
    public class TransactionRepository
    {
        // private Transaction? _transaction;
        private List<Transaction> _transactions = new List<Transaction>();

        /// <summary>
        /// Adds the transaction to the repository
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>A message that tells about the </returns>
        public string Add(Transaction transaction)
        {
            this._transactions.Add(transaction);

            return Messages.AddSuccess;
        }

        /// <summary>
        /// To update the existing Transaction
        /// </summary>
        /// <param name="transaction">Edited details of the Transaction</param>
        public void Update(Transaction transaction)
        {
            foreach (var field in this._transactions)
            {
                if (field.TransactionId == transaction.TransactionId)
                {
                    field.Amount = transaction.Amount;
                    field.Date = transaction.Date;
                    field.Description = transaction.Description;
                    field.Category = transaction.Category;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// To delete the Transaction using Id
        /// </summary>
        /// <param name="transactionId">Id of the transaction to be deleted</param>
        /// <returns>True if the transaction is found and deleted | False if the transaction cannot be deleted</returns>
        public bool DeleteTransactionById(Guid transactionId)
        {
            Transaction? transaction = this._transactionList.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction == null)
            {
                return false;
            }

                    if (transaction.TransactionType == Model.Type.Income)
                    {
                        ((Income)field).Source = ((Income)transaction).Source;
                    }
                    else
                    {
                        ((Expense)field).Category = ((Expense)transaction).Category;
                    }

                    break;
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
