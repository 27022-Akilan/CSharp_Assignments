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
        /// <param name="message">Description of the table.</param>
        /// <param name="groups">List of tuple containing category,category's Maximum price, category's count</param>
        public static void DisplayProducts(string message, IEnumerable<(Product?, int)> groups)
        {
            Console.WriteLine(message);
            ConsoleTable table = new ConsoleTable("Category", "Product Id", "Product Name", "Product Price", "Total Products");

            table.Configure(options => options.EnableCount = false);

            foreach (var group in groups)
            {
                table.AddRow(group.Item1!.Category, group.Item1!.Id, group.Item1!.ProductName, group.Item1!.Price, group.Item2);
            }

            table.Write();
        }

        /// <summary>
        /// To Display the Products.
        /// </summary>
        /// <param name="message"> Description of the table.</param>
        /// <param name="productList">List of Product</param>
        public static void DisplayProducts(string message, IEnumerable<Product> productList)
        {
            Console.WriteLine(message);
            if (!productList.Any())
            {
                Console.WriteLine("Empty");
                return;
            }

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
        /// <param name="message">Description of the table.</param>
        /// <param name="filteredList">List of product with name and price.</param>
        public static void DisplayFilteredProducts(string message, IEnumerable<(string?, decimal)> filteredList)
        {
            Console.WriteLine(message);
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
        /// <param name="message">Description of the table.</param>
        /// <param name="productSupplier">List of (product name, supplier name)</param>
        public static void DisplayProductSupplier(string message, IEnumerable<(string?, string)> productSupplier)
        {
            Console.WriteLine(message);
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
        /// <param name="message">Description of the table.</param>
        /// <param name="suppliers">List of Supplier information.</param>
        public static void DisplaySupplier(string message, IEnumerable<Supplier> suppliers)
        {
            Console.WriteLine(message);
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
