using AssignmentThree.Repository;
using AssignmentThree.Service;
using AssignmentThree.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method.
        /// </summary>
        /// <param name="args"> Default arguments</param>
        public static void Main(string[] args)
        {
            InventoryRepository repository = new InventoryRepository();
            InventoryService service = new InventoryService(repository);
            InventoryView inventoryView = new InventoryView(service);

            inventoryView.DisplayMenu();
        }
    }
}