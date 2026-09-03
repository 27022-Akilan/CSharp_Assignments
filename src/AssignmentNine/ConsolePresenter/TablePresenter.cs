using AssignmentNine.Model;
using ConsoleTables;

namespace AssignmentNine.ConsolePresenter
{
    /// <summary>
    /// To print Tables
    /// </summary>
    public static class TablePresenter
    {
        /// <summary>
        /// Displays the group of product with category
        /// </summary>
        /// <param name="groups">List of tuple containing category,category's Maximum price, category's count</param>
        public static void DisplayProducts(IEnumerable<(string?, decimal, int)> groups)
        {
            Console.WriteLine("\nThe Category grouping with maximum price and count !!!!");
            ConsoleTable table = new ConsoleTable("Category", "Maximum Price", "Total Products");

            table.Configure(options => options.EnableCount = false);

            foreach (var group in groups)
            {
                table.AddRow(group.Item1!, group.Item2, group.Item3);
            }

            table.Write();
        }

        /// <summary>
        /// To Display the Products.
        /// </summary>
        /// <param name="prompt"> Prompt to be displayed</param>
        /// <param name="productList">List of Product</param>
        public static void DisplayProducts(string prompt, IEnumerable<Product> productList)
        {
            Console.WriteLine(prompt);
            ConsoleTable table = new ConsoleTable("Id", "Name", "Price", "Category");
            table.Configure(options => options.EnableCount = false);
            foreach (Product product in productList)
            {
                table.AddRow(product.Id, product.ProductName, product.Price, product.Category);
            }

            table.Write();
        }

        /// <summary>
        /// Displays the name and price of the product.
        /// </summary>
        /// <param name="filteredList">List of product with name and price</param>
        public static void DisplayFilteredProducts(IEnumerable<(string?, decimal)> filteredList)
        {
            ConsoleTable table = new ConsoleTable("Name", "Price");
            table.Configure(options => options.EnableCount = false);

            foreach (var product in filteredList)
            {
                table.AddRow(product.Item1, product.Item2);
            }

            table.Write();
        }

        /// <summary>
        /// Displays the product and their supplier name.
        /// </summary>
        /// <param name="productSupplier">List of (product name, supplier name)</param>
        public static void DisplayProductSupplier(IEnumerable<(string?, string)> productSupplier)
        {
            ConsoleTable table = new ConsoleTable("Product Name", "Supplier Name");
            table.Configure(options => options.EnableCount = false);

            foreach (var element in productSupplier)
            {
                table.AddRow(element.Item1, element.Item2);
            }

            table.Write();
        }

        /// <summary>
        /// Displays the Supplier information.
        /// </summary>
        /// <param name="prompt">Message to be displayed.</param>
        /// <param name="suppliers">List of Supplier information.</param>
        public static void DisplaySupplier(string prompt, IEnumerable<Supplier> suppliers)
        {
            Console.WriteLine(prompt);
            ConsoleTable table = new ConsoleTable("SupplierId", "Name", "ProductId");
            table.Configure(options => options.EnableCount = false);

            foreach (Supplier supplier in suppliers)
            {
                table.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.ProductId);
            }

            table.Write();
        }
    }
}
