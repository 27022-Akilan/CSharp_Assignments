using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;

namespace AssignmentNine.TaskOne
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
            Console.Write("Enter the Category of the product to be searched : ");
            string category = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter the minimum price of the product to get it : ");
            string userInputPrice = Console.ReadLine() ?? string.Empty;
            if (!decimal.TryParse(userInputPrice, out decimal price))
            {
                Console.WriteLine("The entered price is not valid !!!");
                return;
            }

            this.FilterByCategoryAndPrice(category, price);
        }

        /// <summary>
        /// Filters and Display the product by category and price
        /// </summary>
        /// <param name="category">Category of the product</param>
        /// <param name="price">Price of the product</param>
        public void FilterByCategoryAndPrice(string category, decimal price)
        {
            IEnumerable<(string?, decimal)> filteredList = this._productList.Where(p => p.Category == category && p.Price > price)
                                                                            .Select(p => (p.ProductName, p.Price));
            if (!filteredList.Any())
            {
                Console.WriteLine($"No products matched to your category : {category} and price > {price}.");
                return;
            }

            decimal average = this._productList.Average(p => p.Price);

            Console.WriteLine($"Products matched to your {category} and > {price} are");
            TablePresenter.DisplayFilteredProducts(filteredList);
            Console.WriteLine($"The average of these products price is : {average}");

            Console.Write("\nDo you need to sort the products in descending order of price (Y/N) : ");
            string input = Console.ReadLine() ?? string.Empty.Trim();

            if (input == "Y" || input == "y")
            {
                Console.WriteLine($"Products that matched to your {category} and > {price} and sorted by descending order is ");
                this.SortByDescending(filteredList);
                Console.WriteLine($"The average of these products price is : {average}");
            }
        }

        /// <summary>
        /// Sorts the products in descending order by product price.
        /// </summary>
        /// <param name="list">List to be sorted</param>
        public void SortByDescending(IEnumerable<(string?, decimal)> list)
        {
            TablePresenter.DisplayFilteredProducts(list.OrderByDescending(p => p.Item2));
        }
    }
}
