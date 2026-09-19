namespace AssignmentSixteen
{
    public class ProductManager
    {
        /// <summary>
        /// Sorting delegate that takes two products ans returns an int representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>-1 if product 1 parameter is smaller than product 2 parameter
        /// 0 If two products parameters are equal
        /// 1 otherwise</returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Creates a list of products.
        /// </summary>
        /// <returns>List of products.</returns>
        public List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product("Laptop", "Electronics", 1200.00m),
                new Product("Smartphone", "Electronics", 800.00m),
                new Product("Tablet", "Electronics", 500.00m),
                new Product("Headphones", "Accessories", 150.00m),
                new Product("Keyboard", "Accessories", 100.00m),
            };

            return products;
        }

        /// <summary>
        /// Sorts the products based on the comparator function (sortDelegate) and displays the products in sorted order.
        /// </summary>
        /// <param name="products">List of products to be sorted</param>
        /// <param name="sortDelegate">Delegate representing the particular compare parameter.</param>
        public void SortAndDisplayProducts(List<Product> products, SortDelegate sortDelegate)
        {
            products.Sort((product1, product2) => sortDelegate(product1, product2));
            DisplayProducts(products);
        }

        private void DisplayProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"Name : {product.Name} \t Category : {product.Category} \t Price : {product.Price}");
            }
        }
    }
}
