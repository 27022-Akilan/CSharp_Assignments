using AssignmentNine.Model;

namespace AssignmentNine.InventoryCreation
{
    /// <summary>
    /// Responsible for creating Products
    /// </summary>
    public class InventoryCreation
    {
        /// <summary>
        /// Creates the products
        /// </summary>
        /// <returns>List of Created products</returns>
        public List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product(1, "Laptop", 75000, "Electronics"));
            products.Add(new Product(2, "Smartphone", 45000, "Electronics"));
            products.Add(new Product(3, "Headphones", 2500, "Electronics"));
            products.Add(new Product(4, "Book1", 500, "Books"));
            products.Add(new Product(5, "Book2", 700, "Books"));
            products.Add(new Product(6, "Book3", 400, "Books"));
            products.Add(new Product(7, "Keyboard", 1800, "Electronics"));
            products.Add(new Product(8, "Mouse", 900, "Electronics"));
            products.Add(new Product(9, "Notebook", 250, "Stationery"));
            products.Add(new Product(10, "Pen", 50, "Stationery"));
            return products;
        }

        /// <summary>
        /// Creates the Supplier List
        /// </summary>
        /// <returns>List of Suppliers</returns>
        public List<Supplier> CreateSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();

            suppliers.Add(new Supplier(101, "TechWorld", 1));
            suppliers.Add(new Supplier(102, "MobileMart", 2));
            suppliers.Add(new Supplier(103, "AudioPlus", 3));
            suppliers.Add(new Supplier(104, "BookHouse", 5));
            suppliers.Add(new Supplier(105, "ReadersPoint", 5));
            suppliers.Add(new Supplier(106, "BookHouse", 6));
            suppliers.Add(new Supplier(107, "TechWorld", 7));
            suppliers.Add(new Supplier(108, "TechWorld", 8));
            suppliers.Add(new Supplier(109, "OfficeSupplies", 9));
            suppliers.Add(new Supplier(110, "OfficeSupplies", 10));
            return suppliers;
        }
    }
}
