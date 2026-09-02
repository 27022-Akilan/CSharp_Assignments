using System.Diagnostics;
using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task four.
    /// </summary>
    public class QueryOptimization
    {
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOptimization"/> class.
        /// </summary>
        /// <param name="products">Product list</param>
        public QueryOptimization(List<Product> products)
        {
            this._products = products;
        }

        /// <summary>
        /// Sort the book in increasing order by price.
        /// </summary>
        public void SortBooksByPrice()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            IEnumerable<Product> products = this._products.OrderBy(p => p.Price).ToList().Where(p => p.Category == "Books");
            stopwatch.Stop();
            TablePresenter.DisplayProducts("\nBooks in the Sorted Order on price is : ", products);
            Console.WriteLine($"The time taken for the first query is :{stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            products = this._products.Where(p => p.Category == "Books").OrderBy(p => p.Price).ToList();
            stopwatch.Stop();
            Console.WriteLine($"The time taken for the Second query is :{stopwatch.ElapsedMilliseconds} ms");
            ConsoleCleaner.Clean();
        }
    }
}
