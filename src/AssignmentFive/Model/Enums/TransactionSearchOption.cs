namespace AssignmentFive.Model.Enums
{
    /// <summary>
    /// Provides enums for the SearchOption.
    /// </summary>
    public enum TransactionSearchOption
    {
        /// <summary>
        /// Option for searching a transaction by type.
        /// </summary>
        ByType = 1,

        /// <summary>
        /// Option for searching a transaction by amount.
        /// </summary>
        ByAmount,

        /// <summary>
        /// Option for searching a transaction by description.
        /// </summary>
        ByDescription,

        /// <summary>
        /// Option for searching a transaction by date.
        /// </summary>
        ByDate,

        /// <summary>
        /// Option for exiting the search menu.
        /// </summary>
        Exit,
    }
}
