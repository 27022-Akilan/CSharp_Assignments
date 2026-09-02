using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;
using AssignmentNine.Model.Enum;
using AssignmentNine.Tasks;

namespace AssignmentNine
{
    /// <summary>
    /// Represents the menu handling.
    /// </summary>
    public class MenuHandler
    {
        private readonly List<Product> _products;
        private readonly List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuHandler"/> class.
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public MenuHandler(List<Product> products, List<Supplier> suppliers)
        {
            this._products = products;
            this._suppliers = suppliers;
        }

        /// <summary>
        /// Handles the menu and dispatches to the required service.
        /// </summary>
        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                this.DisplayMenu();

                if (!ConsoleHelper.TryGetEnumInput("Enter your choice : ", out MenuOption task))
                {

                }

            }



            ConsoleCleaner.Clean();

            ComplexQueries taskTwo = new ComplexQueries(this._products, this._suppliers);
            TablePresenter.DisplayProducts(this._products);
            taskTwo.GroupByCategory();

            ConsoleCleaner.Clean();

            taskTwo.RelateProductAndSupplier();

            ConsoleCleaner.Clean();

            ObjectQueries taskThree = new ObjectQueries();
            taskThree.PerformArrayOperations();

            ConsoleCleaner.Clean();

            QueryOptimization taskFour = new QueryOptimization(this._products);
            taskFour.SortBooksByPrice();

            ConsoleCleaner.Clean();

            CustomQueries taskFive = new CustomQueries(this._products, this._suppliers);
            taskFive.WriteQueries();
        }

        private void DisplayMenu()
        {
            Console.Write("\n1.Basic Queries" +
                          "\n2.Complex Queries" +
                          "\n3.Object Queries" +
                          "\n4.Query Optimization" +
                          "\n5.Custom Queries (Fluent API)" +
                          "\n6.Exit");
        }
    }
}
