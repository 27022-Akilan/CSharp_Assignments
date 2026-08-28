using System.Diagnostics;
using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task four.
    /// </summary>
    public class TaskFour
    {
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFour"/> class.
        /// </summary>
        /// <param name="products">Product list</param>
        public TaskFour(List<Product> products)
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
            IEnumerable<Product> products = this._products.Where(p => p.Category == "Books").OrderBy(p => p.Price).ToList();
            stopwatch.Stop();
            Console.WriteLine("Books in the Sorted Order on price is : ");
            TablePresenter.DisplayProducts(products);
            Console.WriteLine($"The time taken for the first query is :{stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
