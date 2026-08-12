using AssignmentThree.Model;
using ConsoleTables;

namespace AssignmentThree.Utilities
{
    /// <summary>
    /// It displays the details to the user
    /// </summary>
    public static class ConsolePresenter
    {
        /// <summary>
        ///  Displays Failure message in Red color
        /// </summary>
        /// <param name="s">Input for failure message</param>
        public static void DisplayError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        ///  Displays Warning message in Yellow color
        /// </summary>
        /// <param name="s">Input for the Warning message</param>
        public static void DisplayWarning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Success message in Green color
        /// </summary>
        /// <param name="s">Input for the success message</param>
        public static void DisplaySuccess(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the text in the gray color
        /// </summary>
        /// <param name="s">Input for the Grey color message</param>
        public static void WriteLight(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// This prints the Product details in a table format.
        /// </summary>
        /// <param name="list">Contains the List of the products, whereas list cant be changed</param>
        public static void DisplayTable(IEnumerable<ProductInfo> list)
        {
            var table = new ConsoleTable("Id", "Name", "Price", "Quantity");
            foreach (var products in list)
            {
                table.AddRow(products.Id, products.Name, products.Price, products.Quantity);
            }

            table.Configure(options =>
            {
                options.EnableCount = false;
            });
            table.Write();
        }
    }
}
