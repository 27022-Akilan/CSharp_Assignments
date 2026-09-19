using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;
using AssignmentNine.Model.Enum;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task five.
    /// </summary>
    public class CustomQueries
    {
        private List<Product> _products;

        private List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueries"/> class.
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of Suppliers</param>
        public CustomQueries(List<Product> products, List<Supplier> suppliers)
        {
            this._products = products;
            this._suppliers = suppliers;
        }

        /// <summary>
        /// Build Queries.
        /// </summary>
        public void WriteQueries()
        {
            ConsoleHelper.DisplayInfoMessage("==========================================================" +
                                            "\n--- Made queries by passing Lambda expressions ---" +
                                            "\n==========================================================");
            TablePresenter.DisplayProducts("\nThe initial products are...", this._products);

            // Default query given as lambda
            IEnumerable<Product> result = new QueryBuilder<Product>(this._products)
                                          .Filter(p => p.Category == "Books")
                                          .SortBy(p => p.Price)
                                          .Execute();

            TablePresenter.DisplayProducts("\nFiltered the products by books and sorts in ascending order by price", result);
            var joinedResult = new QueryBuilder<Product>(this._products).Join(
                                                        this._suppliers,
                                                        product => product.Id,
                                                        supplier => supplier.ProductId,
                                                        (product, supplier) => (product.ProductName, supplier.SupplierName))
                                                        .Execute();
            TablePresenter.DisplayProductSupplier("\nResult of Joining the product with the Supplier !!", joinedResult);
            this.MakeQuery();
            ConsoleHelper.Clean();
        }

        private void MakeQuery()
        {
            ConsoleHelper.Clean();
            ConsoleHelper.DisplayInfoMessage("========================================" +
                                            "\n--- Make Queries By Yourself :) ---" +
                                            "\n========================================");

            TablePresenter.DisplayProducts("The Initial products are ...", this._products);

            // Building the Query manually.
            Console.WriteLine(
                "\nBuild your query just by giving fields:" +
                "\n1.Id" +
                "\n2.ProductName" +
                "\n3.Price" +
                "\n4.Category");

            ProductProperty propertyOption;

            if (!ConsoleHelper.TryGetEnum("Enter the choice for the property : ", out propertyOption))
            {
                Console.WriteLine("Invalid input aborting !!");
                return;
            }

            Console.WriteLine(
                "\n1. Contains" +
                "\n2. Starts With" +
                "\n3. Ends With" +
                "\n4. Greater than or equal to" +
                "\n5. Less than or equal to");

            if (!ConsoleHelper.TryGetEnum("Enter your choice : ", out FilterOperation operation))
            {
                Console.WriteLine("Invalid filter operation.");
                return;
            }

            Console.Write(this.GetInputPrompt(propertyOption, operation));
            string inputValue = Console.ReadLine() ?? string.Empty;
            object value;
            string propertyName;
            switch (propertyOption)
            {
                case ProductProperty.Id:
                    if (!int.TryParse(inputValue, out int id))
                    {
                        Console.WriteLine("Invalid integer value.");
                        return;
                    }

                    propertyName = nameof(Product.Id);
                    value = id;
                    break;

                case ProductProperty.Price:
                    if (!decimal.TryParse(inputValue, out decimal price))
                    {
                        Console.WriteLine("Invalid decimal value.");
                        return;
                    }

                    propertyName = nameof(Product.Price);
                    value = price;
                    break;

                case ProductProperty.Category:
                    propertyName = nameof(Product.Category);
                    value = inputValue;
                    break;
                case ProductProperty.ProductName:
                    propertyName = nameof(Product.ProductName);
                    value = inputValue;
                    break;

                default:
                    Console.WriteLine("Invalid property name.");
                    return;
            }

            var result = new QueryBuilder<Product>(this._products).Filter(propertyName, operation, value).Execute();
            TablePresenter.DisplayProducts("\nFiltered Result:\n", result);
            ConsoleHelper.Clean();
        }

        private string GetInputPrompt(ProductProperty property, FilterOperation operation)
        {
            string propertyName = property.ToString();
            return operation switch
            {
                FilterOperation.Contains => $"Enter the value that {propertyName} should contain :",

                FilterOperation.StartsWith => $"Enter the value that {propertyName} should start with : ",

                FilterOperation.EndsWith => $"Enter the value that the {propertyName} should end with :",

                FilterOperation.GreaterThanOrEqualTo => $"Enter the minimum value for {propertyName} : ",

                FilterOperation.LessThanEqualTo => $"Enter the maximum value for {propertyName} : ",

                _ => $"Enter the value for {propertyName} : "
            };
        }
    }
}
