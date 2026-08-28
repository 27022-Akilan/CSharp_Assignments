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

            TaskOne taskOne = new TaskOne(products);
            TablePresenter.DisplayProducts(products);
            taskOne.PerformTask();

            ConsoleCleaner.Clean();

            TaskTwo taskTwo = new TaskTwo(products, suppliers);
            TablePresenter.DisplayProducts(products);
            taskTwo.GroupByCategory();

            ConsoleCleaner.Clean();

            taskTwo.RelateProductAndSupplier();

            ConsoleCleaner.Clean();

            TaskThree taskThree = new TaskThree();
            taskThree.PerformArrayOperations();

            ConsoleCleaner.Clean();

            TaskFour taskFour = new TaskFour(products);
            taskFour.SortBooksByPrice();

            ConsoleCleaner.Clean();

            TaskFive taskFive = new TaskFive(products, suppliers);
            taskFive.WriteQueries();
        }
    }
}
