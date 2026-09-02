using AssignmentNine;
using AssignmentNine.InventoryCreation;
using AssignmentNine.Model;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts up the Application.
        /// </summary>
        /// <param name="args">Default parameter</param>
        public static void Main(string[] args)
        {
            //Console.WriteLine("\t\t\t\t\t\t Language Integrated Query\n");
            InventoryCreation inventoryCreation = new InventoryCreation();
            List<Product> products = inventoryCreation.CreateProducts();
            List<Supplier> suppliers = inventoryCreation.CreateSupplier();
            MenuHandler menuHandler = new MenuHandler(products, suppliers);
            menuHandler.Run();
            //BasicQueries taskOne = new BasicQueries(products);
            //Console.WriteLine("The initial products are ");
            //TablePresenter.DisplayProducts(products);
            //taskOne.PerformTask();

            //ConsoleCleaner.Clean();

            //ComplexQueries taskTwo = new ComplexQueries(products, suppliers);
            //TablePresenter.DisplayProducts(products);
            //taskTwo.GroupByCategory();

            //ConsoleCleaner.Clean();

            //taskTwo.RelateProductAndSupplier();

            //ConsoleCleaner.Clean();

            //ObjectQueries taskThree = new ObjectQueries();
            //taskThree.PerformArrayOperations();

            //ConsoleCleaner.Clean();

            //QueryOptimization taskFour = new QueryOptimization(products);
            //taskFour.SortBooksByPrice();

            //ConsoleCleaner.Clean();

            //CustomQueries taskFive = new CustomQueries(products, suppliers);
            //taskFive.WriteQueries();
        }
    }
}
