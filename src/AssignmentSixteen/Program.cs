using AssignmentSixteen;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += DisplayMessage;
            notifier.SendNotification();

            ArrayOperator arrayOperator = new ArrayOperator();
            arrayOperator.PerformOperations(new int[] { 6, 5, 4, 3, 2, 1 });

            ListOperator listOperator = new ListOperator();
            listOperator.FilterAndSquareEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6 });

            ProductManager productManager = new ProductManager();
            List<Product> products = productManager.CreateProducts();
            productManager.SortAndDisplayProducts(products, SortByName);
            productManager.SortAndDisplayProducts(products, SortByCategory);
            productManager.SortAndDisplayProducts(products, SortByPrice);
        }

        /// <summary>
        /// Displays the message to the user.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Compares product by name and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 name is smaller than product 2 name
        /// 0 If two products names are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        /// <summary>
        /// Compares product by category and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 category is smaller than product 2 category
        /// 0 If two products category are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        /// <summary>
        /// Compares product by price and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 price is smaller than product 2 price
        /// 0 If two products price are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }
    }
}