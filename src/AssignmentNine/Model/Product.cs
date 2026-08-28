namespace AssignmentNine.Model
{
    /// <summary>
    /// Represent the product information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="productName">Product Name</param>
        /// <param name="price">Product price</param>
        /// <param name="category">Product category</param>
        public Product(int id, string productName, decimal price, string category)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>Id of the product</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Product name.
        /// </summary>
        /// <value>Price of the product</value>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>Price of the product</value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>Category of the product</value>
        public string? Category { get; set; }
    }
}
