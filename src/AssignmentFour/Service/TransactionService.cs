using System.Transactions;
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

        public string AddTransaction(Transaction transaction)
        {
            
        }
    }
}
