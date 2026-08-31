using AssignmentNine.ConsolePresenter;
using AssignmentNine.InventoryCreation;
using AssignmentNine.Model;
using AssignmentNine.TaskOne;
using AssignmentNine.Tasks;

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
            Console.WriteLine("\t\t\t\t\t\t Language Integrated Query\n");
            InventoryCreation inventoryCreation = new InventoryCreation();
            List<Product> products = inventoryCreation.CreateProducts();
            List<Supplier> suppliers = inventoryCreation.CreateSupplier();

            BasicQueries taskOne = new BasicQueries(products);
            Console.WriteLine("The initial products are ");
            TablePresenter.DisplayProducts(products);
            taskOne.PerformTask();

            ConsoleCleaner.Clean();

            ComplexQueries taskTwo = new ComplexQueries(products, suppliers);
            TablePresenter.DisplayProducts(products);
            taskTwo.GroupByCategory();

            ConsoleCleaner.Clean();

            taskTwo.RelateProductAndSupplier();

            ConsoleCleaner.Clean();

            TaskThree taskThree = new TaskThree();
            taskThree.PerformArrayOperations();

            ConsoleCleaner.Clean();

            ObjectQueries taskFour = new ObjectQueries(products);
            taskFour.SortBooksByPrice();

            ConsoleCleaner.Clean();

            TaskFive taskFive = new TaskFive(products, suppliers);
            taskFive.WriteQueries();
        }
    }
}
