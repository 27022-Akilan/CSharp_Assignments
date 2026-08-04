namespace AssignmentThree.Model
{
    /// <summary>
    /// Contains the Operations return Messages
    /// </summary>
    public enum OperationMessage
    {
        /// <summary>
        ///  Added Success full message
        /// </summary>
        AddedSuccessFull = 1,

        /// <summary>
        ///  Product Id already in the Inventory.
        /// </summary>
        ProductIdAlreadyExists,

        /// <summary>
        ///  Product is not in the Inventory.
        /// </summary>
        ProductDoesNotExists,

        /// <summary>
        /// To Exit te menu.
        /// </summary>
        Exit,
    }
}
