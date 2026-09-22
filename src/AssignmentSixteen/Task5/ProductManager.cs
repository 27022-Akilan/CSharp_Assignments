using AssignmentSixteen.Helper;
using AssignmentSixteen.Models;

namespace AssignmentSixteen.Task5
{
    /// <summary>
    /// Represents the management of products.
    /// </summary>
    public class ProductManager
    {
        /// <summary>
        /// Sorting delegate that takes two products and returns an int representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>-1 if product 1 parameter is smaller than product 2 parameter
        /// 0 If two products parameters are equal
        /// 1 otherwise</returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Performs operations on List of products ad use delegates to sort them.
        /// </summary>
        public void PerformDelegateOperation()
        {
            Console.WriteLine("=== Task 5 ===");
            List<Product> products = this.CreateProducts();
            Console.WriteLine("\n\n====Sorts by Name====\n\n");
            this.SortAndDisplayProducts(products, this.SortByName);
            Console.WriteLine("\n\n====Sorts by Category====\n\n");
            this.SortAndDisplayProducts(products, this.SortByCategory);
            Console.WriteLine("\n\n====Sorts by Price====\n\n");
            this.SortAndDisplayProducts(products, this.SortByPrice);
            ConsoleHelper.WaitAndClear();
        }

        private List<Product> CreateProducts()
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

        private void SortAndDisplayProducts(List<Product> products, SortDelegate sortDelegate)
        {
            products.Sort((product1, product2) => sortDelegate(product1, product2));
            this.DisplayProducts(products);
        }

        private int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        private int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        private int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }

        private void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"Name : {product.Name} \t Category : {product.Category} \t Price : {product.Price}");
            }
        }
    }
}
