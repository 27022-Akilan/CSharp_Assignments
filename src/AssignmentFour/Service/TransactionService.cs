using AssignmentFour.Model;
using AssignmentFour.Repository;

namespace AssignmentFour.Service
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
        /// <returns>String - Empty string for success or else a message for the failing</returns>
        public string AddTransaction(Model.Transaction transaction)
        {
            if (transaction == null)
            {
                return Messages.AddFailedDueToNull;
            }

            if (transaction.Amount <= 0)
            {
                return "amount cant be less than zero";
            }

            return this._repository.Add(transaction);
        }

        /// <summary>
        /// Updates the Transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>Bool </returns>
        public bool Update(Model.Transaction transaction)
        {
            if (transaction == null)
            {
                return false; // null
            }

            if (transaction.Amount <= 0)
            {
                return false; // invalid amount
            }

            return this._repository.UpdateTransaction(transaction);
        }

        /// <summary>
        /// Gets the transaction using the ID of the transaction
        /// </summary>
        /// <param name="transactionId">Id of the transaction to get</param>
        /// <returns>Transaction object</returns>
        public Transaction? GetOneTransaction(Guid transactionId)
        {
            return this._repository.GetOne(transactionId);
        }

        /// <summary>
        /// Deletes the transaction by id.
        /// </summary>
        /// <param name="id">Guid of the transaction to be deleted</param>
        /// <returns>bool True - Transaction deleted | False - Transaction cannot delete</returns>
        public bool DeleteTransactionById(Guid id)
        {
            return this._repository.DeleteById(id);
        }

        /// <summary>
        /// Gets the List of transactions which cannot be modified.
        /// </summary>
        /// <returns>IEnumerable list of Transactions which cannot be modified</returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._repository.ShowAll();
        }
    }
}
