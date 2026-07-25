namespace AssignmentThree.Model
{
    /// <summary>
    /// Model for the Inventory
    /// </summary>
    public class InventoryModel
    {
        /// <summary>
        /// Gets or Sets the Id of the product
        /// </summary>
        /// <value>
        /// A string containing the Id of the Product.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///  Gets or sets the Name of the Product
        /// </summary>
        /// <value>
        /// A string containing the Name of the Product.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Product Price.
        /// </summary>
        /// <value>
        /// Conatins the Price of the product.
        /// </value>
        public long Price { get; set; }

        /// <summary>
        /// Gets or sets the Product Quantity.
        /// </summary>
        /// <value>
        /// Conatins the Quantity of the product.
        /// </value>
        public long Quantity { get; set; }
    }
}
