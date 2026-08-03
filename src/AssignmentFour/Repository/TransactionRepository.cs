using AssignmentFour.Model;

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
            }
        }
    }
}
