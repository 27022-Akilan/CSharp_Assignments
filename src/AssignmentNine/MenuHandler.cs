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
            BasicQueries basicQueries = new BasicQueries(this._products);
            ComplexQueries complexQueries = new ComplexQueries(this._products, this._suppliers);
            ObjectQueries objectQueries = new ObjectQueries();
            QueryOptimization queryOptimization = new QueryOptimization(this._products);
            CustomQueries customQueries = new CustomQueries(this._products, this._suppliers);
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                ConsoleHelper.DisplayInfoMessage("\t\t\tLanguage Integrated Query");
                this.DisplayMenu();

                if (!ConsoleHelper.TryGetEnum("\nEnter your choice : ", out MenuOption option))
                {
                    Console.WriteLine("Invalid option !!!");
                }

                switch (option)
                {
                    case MenuOption.BasicQueries:
                        basicQueries.PerformTask();
                        break;
                    case MenuOption.ComplexQueries:
                        complexQueries.GroupByCategory();
                        complexQueries.RelateProductAndSupplier();
                        break;
                    case MenuOption.ObjectQueries:
                        objectQueries.PerformArrayOperations();
                        break;
                    case MenuOption.QueryOptimization:
                        queryOptimization.SortBooksByPrice();
                        break;
                    case MenuOption.CustomQueries:
                        customQueries.WriteQueries();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting the Application !!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option !!!");
                        break;
                }
            }
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
