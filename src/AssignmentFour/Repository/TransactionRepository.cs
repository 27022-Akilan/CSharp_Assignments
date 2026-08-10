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
        /// Adds the transaction to the repository
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>A message that tells about the </returns>
        public string Add(Transaction transaction)
        {
            this._transactionList.Add(transaction);

            return Messages.AddSuccess;
        }

        /// <summary>
        /// To update the existing Transaction
        /// </summary>
        /// <param name="transaction">Edited details of the Transaction</param>
        /// <returns>bool True - Updated Successfully | False - Cannot Update</returns>
        public bool UpdateTransaction(Transaction transaction)
        {
            foreach (var field in this._transactionList)
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
        /// <returns>bool - True if the transaction found and deleted | False if the transaction cant be deleted</returns>
        public bool DeleteById(Guid transactionId)
        {
            foreach (var transaction in this._transactionList)
            {
                if (transaction.TransactionId == transactionId)
                {
                    this._transactionList.Remove(transaction);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///  Shows the Transaction of the desired transaction Id
        /// </summary>
        /// <param name="transactionId">Id of the Transaction to be shown</param>
        /// <returns>A Transaction if the Id exists or else null</returns>
        public Transaction? GetOne(Guid transactionId)
        {
            Transaction? match = this._transactionList.Where(t => t.TransactionId == transactionId).FirstOrDefault();

            if (match == null)
            {
                return null;
            }

            if (match is Income)
            {
                return new Income(match.TransactionId, match.Amount, match.Description, match.Date, ((Income)match).Source);
            }

            if (match is Expense)
            {
                return new Expense(match.TransactionId, match.Amount, match.Description, match.Date, ((Expense)match).Category);
            }

            return null;
        }

        /// <summary>
        /// Shows the entire transactions
        /// </summary>
        /// <returns>A clone </returns>
        public IEnumerable<Transaction> ShowAll()
        {
            List<Transaction> transactionList = new List<Transaction>();
            foreach (var transaction in this._transactionList)
            {
                if (transaction is Income)
                {
                    transactionList.Add(new Income(
                                                transaction.TransactionId,
                                                transaction.Amount,
                                                transaction.Description,
                                                transaction.Date,
                                                ((Income)transaction).Source));
                }
                else
                {
                    transactionList.Add(new Expense(
                                                transaction.TransactionId,
                                                transaction.Amount,
                                                transaction.Description,
                                                transaction.Date,
                                                ((Expense)transaction).Category));
                }
            }

            return transactionList;
        }

        /// <summary>
        /// Shows the transactions of the desired type
        /// </summary>
        /// <param name="type">Type of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified type</returns>
        public IEnumerable<Transaction> ShowTransactionsByType(TransactionType type)
        {
            return this._transactionList.Where((Func<Transaction, bool>)(t => t.TransactionType == type));
        }

        /// <summary>
        /// Shows the transactions of the desired amount
        /// </summary>
        /// <param name="amount">Amount of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified amount</returns>
        public IEnumerable<Transaction> ShowTransactionByAmount(decimal amount)
        {
            return this._transactionList.Where(t => t.Amount == amount);
        }

        /// <summary>
        /// Shows the transactions of the desired description
        /// </summary>
        /// <param name="description">Description of transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified description</returns>
        public IEnumerable<Transaction> ShowTransactionsByDescription(string description)
        {
            return this._transactionList.Where(t => t.Description.Contains(description));
        }

        /// <summary>
        /// Shows the transactions of the desired date
        /// </summary>
        /// <param name="date">Date of the transactions to retrieve</param>
        /// <returns>IEnumerable list of Transactions of the specified date</returns>
        public IEnumerable<Transaction> ShowTransactionsByDate(DateOnly date)
        {
            return this._transactionList.Where(t => t.Date == date);
        }

        /// <summary>
        /// Returns the Guid of the transaction by the index
        /// </summary>
        /// <param name="index">Holds the index where the Transaction resides in List</param>
        /// <returns>Guid of that serial number</returns>
        public Guid GetGuid(int index)
        {
            return this._transactionList[index].TransactionId;
        }
    }
}