using AssignmentFour.Model;

namespace AssignmentFour.Repository
{
    /// <summary>
    ///  Represents a generic repository for performing CRUD Operations
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        ///  Adds a new Transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>bool True - Added successfully | False - Cannot Add</returns>
        public string Add(Transaction transaction);

        /// <summary>
        /// Updates a Transaction
        /// </summary>
        /// <param name="transaction">Transaction object</param>
        /// <returns>bool True - Updated successfully | False - Cannot Update</returns>
        public bool UpdateTransaction(Transaction transaction);

        /// <summary>
        /// Deletes a transaction by the ID
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted</param>
        /// <returns>bool True - Deleted successfully | False - Cannot Delete</returns>
        public bool DeleteById(Guid id);

        /// <summary>
        /// To show the entire transactions (Income , Expense)
        /// </summary>
        /// <returns>Enumerable List of transactions which cant be modified</returns>
        public IEnumerable<Transaction> ShowAll();

        /// <summary>
        /// Gets the transaction object using the Transaction Id
        /// </summary>
        /// <param name="id">Id of the transaction</param>
        /// <returns>Transaction Object</returns>
        public Transaction? GetOne(Guid id);
    }
}
