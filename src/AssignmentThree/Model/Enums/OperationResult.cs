namespace AssignmentThree.Model.Enums
{
    /// <summary>
    /// Contains the Operations return Messages
    /// </summary>
    public enum OperationResult
    {
        /// <summary>
        /// Added successful message
        /// </summary>
        AddedSuccessFull = 1,

        /// <summary>
        /// Product Id already in the Inventory.
        /// </summary>
        ProductIdAlreadyExists,

        /// <summary>
        /// Product is not in the Inventory.
        /// </summary>
        ProductDoesNotExists,
    }
}
