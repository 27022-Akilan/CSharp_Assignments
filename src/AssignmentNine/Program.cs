using AssignmentNine.InitialData;
using AssignmentNine.Model;

namespace AssignmentNine
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
            try
            {
                InventoryManager inventoryCreation = new InventoryManager();
                List<Product> products = inventoryCreation.CreateProducts();
                List<Supplier> suppliers = inventoryCreation.CreateSupplier();
                MenuHandler menuHandler = new MenuHandler(products, suppliers);
                menuHandler.Run();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MethodAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected exception !!");
            }
        }
    }
}