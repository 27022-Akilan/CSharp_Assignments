namespace AssignmentFour.Model.Enums
{
    /// <summary>
    /// Provides enums for the SearchOption.
    /// </summary>
    public enum TransactionSearchOption
    {
        /// <summary>
        /// Option to search transaction by type.
        /// </summary>
        ByType = 1,

        /// <summary>
        /// Option to search transaction by amount.
        /// </summary>
        ByAmount,

        /// <summary>
        /// Option to search transaction by description.
        /// </summary>
        ByDescription,

        /// <summary>
        /// Option to search a transaction by date.
        /// </summary>
        ByDate,

        /// <summary>
        /// Option to exit the search menu.
        /// </summary>
        Exit,
    }
}
