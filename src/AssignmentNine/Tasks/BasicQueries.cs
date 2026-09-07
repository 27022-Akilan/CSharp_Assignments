using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task one functions
    /// </summary>
    public class BasicQueries
    {
        private List<Product> _productList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicQueries"/> class.
        /// </summary>
        /// <param name="productCreation">Instance of product creation</param>
        /// <param name="productList">List of products</param>
        public BasicQueries(List<Product> productList)
        {
            this._productList = productList;
        }

        /// <summary>
        ///  Performs the task.
        /// </summary>
        public void PerformTask()
        {
            ConsoleHelper.DisplayInfoMessage("===============================" +
                                            "\n--- Basic Queries ---" +
                                            "\n===============================");
            TablePresenter.DisplayProducts("\nThe Initial products are...\n", this._productList);

            Console.Write("Enter the Category of the product to be searched : ");
            string category = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter the minimum price of the product to get it : ");
            string userInputPrice = Console.ReadLine() ?? string.Empty;
            if (!decimal.TryParse(userInputPrice, out decimal price))
            {
                Console.WriteLine("The entered price is not valid !!!");
                return;
            }

            IEnumerable<(string?, decimal)> filteredList = this.FilterByCategoryAndPrice(category, price);
            if (!filteredList.Any())
            {
                Console.WriteLine($"No products matched to your category : {category} and price > {price}.");
                return;
            }

            decimal average = this.CalculateAverage(filteredList);

            TablePresenter.DisplayFilteredProducts(
                                                    $"\nProducts matched to your category {category} and > {price} are",
                                                    filteredList);

            Console.WriteLine($"\nThe average of these products price is : {average}");

            Console.Write("\nDo you need to sort the products in descending order of price (Y/N) : ");
            string input = Console.ReadLine() ?? string.Empty.Trim();

            if (input == "Y" || input == "y")
            {
                IEnumerable<(string?, decimal)> sortedList = this.SortByDescending(filteredList);
                TablePresenter.DisplayFilteredProducts(
                    $"\nProducts that matched to your category : {category} and price > {price} and sorted by descending order is ",
                    sortedList.OrderByDescending(p => p.Item2));
            }

            ConsoleHelper.Clean();
        }

        /// <summary>
        /// Filters and Display the product by category and price
        /// </summary>
        /// <param name="category">Category of the product</param>
        /// <param name="price">Price of the product</param>
        /// <returns>Filtered List by category and price.</returns>
        public IEnumerable<(string?, decimal)> FilterByCategoryAndPrice(string category, decimal price)
        {
            return this._productList.Where(p => p.Category == category && p.Price > price)
                             .Select(p => (p.ProductName, p.Price));
        }

        /// <summary>
        /// Calculates the average of products price.
        /// </summary>
        /// <param name="list">List of products.</param>
        /// <returns>Average of the products price</returns>
        private decimal CalculateAverage(IEnumerable<(string?, decimal)> list)
        {
            return list.Average(p => p.Item2);
        }

        /// <summary>
        /// Sorts the products in descending order by product price.
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <return>Sorted list in Descending order.</return>
        private IEnumerable<(string?, decimal)> SortByDescending(IEnumerable<(string?, decimal)> list)
        {
            return list.OrderByDescending(p => p.Item2);
        }
    }
}
