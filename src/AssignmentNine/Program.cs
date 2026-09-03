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
            InventoryCreation inventoryCreation = new InventoryCreation();
            List<Product> products = inventoryCreation.CreateProducts();
            List<Supplier> suppliers = inventoryCreation.CreateSupplier();
            MenuHandler menuHandler = new MenuHandler(products, suppliers);
            menuHandler.Run();
        }
    }
}
