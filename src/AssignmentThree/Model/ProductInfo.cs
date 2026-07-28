namespace AssignmentThree.Model
{
    /// <summary>
    /// Model for the Inventory
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInfo"/> class
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        public ProductInfo(string id, string? name, double price, long quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets or Sets the Id of the product
        /// </summary>
        /// <value>
        /// A string containing the Id of the Product.
        /// </value>
        public string Id { get; set; }

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
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the Product Quantity.
        /// </summary>
        /// <value>
        /// Conatins the Quantity of the product.
        /// </value>
        public long Quantity { get; set; }
    }
}
