namespace AssignmentSixteen
{
    /// <summary>
    /// Represents the product information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="category">Category of the product.</param>
        /// <param name="price">Price of the product.</param>
        public Product(string name, string category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets the Name of the product.
        /// </summary>
        /// <value>Name of the product.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the Category of the product.
        /// </summary>
        /// <value>Category of the product.</value>
        public string Category { get; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        /// <value>Price of the product.</value>
        public decimal Price { get; }
    }
}
