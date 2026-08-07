using AssignmentFour.Model;
namespace AssignmentFour.Repository
{
    /// <summary>
    /// Repository for storing the Transaction Details.
    /// </summary>
    public class TransactionRepository : IRepository
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
        /// <returns>boo True - Updated Successfully | False - Cannot Update</returns>
        public bool Update(Transaction transaction)
        {
            foreach (var field in this._transactions)
            {
                if (field.TransactionId == transaction.TransactionId)
                {
                    field.Amount = transaction.Amount;
                    field.Date = transaction.Date;
                    field.Description = transaction.Description;

                    if (transaction.TransactionType == Model.Type.Income)
                    {
                        ((Income)field).Source = ((Income)transaction).Source;
                    }
                    else if (transaction.TransactionType == Model.Type.Expense)
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
            foreach (var transaction in this._transactions)
            {
                if (transaction.TransactionId == transactionId)
                {
                    this._transactions.Remove(transaction);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Shows the entire transactions
        /// </summary>
        /// <returns>A clone </returns>
        public IEnumerable<Transaction> ShowAll()
        {
            List<Transaction> transactionList = new List<Transaction>();
            foreach (var transaction in this._transactions)
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
    }
}
