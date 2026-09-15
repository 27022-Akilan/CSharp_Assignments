using AssignmentNine.ConsolePresenter;
using AssignmentNine.Model;

namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task two.
    /// </summary>
    public class ComplexQueries
    {
        private List<Product> _productList;
        private List<Supplier> _supplierList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexQueries"/> class.
        /// </summary>
        /// <param name="productList">List of products</param>
        /// <param name="supplierList">List of suppliers</param>
        public ComplexQueries(List<Product> productList, List<Supplier> supplierList)
        {
            this._productList = productList;
            this._supplierList = supplierList;
        }

        /// <summary>
        /// Groups the products by Category.
        /// </summary>
        public void PerformQuery()
        {
            ConsoleHelper.DisplayInfoMessage("\n===============================" +
                                             "\n   --- Complex Queries ---" +
                                             "\n===============================");
            TablePresenter.DisplayProducts("\nThe initial products are...\n", this._productList);

            IEnumerable<(Product?, int)> groups = this.GroupByCategory();
            TablePresenter.DisplayProducts("Groups by Category and displays the maximum price, and count in each category.", groups);
            ConsoleHelper.Clean();

            TablePresenter.DisplayProducts("\nThe initial products are...\n", this._productList);
            TablePresenter.DisplaySupplier("\nThe initial suppliers are...\n", this._supplierList);
            IEnumerable<(string?, string)> innerJoin = this.RelateProductAndSupplier();
            TablePresenter.DisplayProductSupplier("\nRelating the products with the supplier.", innerJoin);
            ConsoleHelper.Clean();
        }

        /// <summary>
        /// Groups by category and gives the product count in each category and product with maximum price.
        /// </summary>
        /// <returns>List of Product with product count in each category</returns>
        public IEnumerable<(Product?, int)> GroupByCategory()
        {
            return this._productList.GroupBy(p => p.Category)
                                    .Select(g => (g.MaxBy(p => p.Price), g.Count()));
        }

        /// <summary>
        /// Joins the supplier and product.
        /// </summary>
        /// <returns>List of joined product with supplier.</returns>
        public IEnumerable<(string?, string)> RelateProductAndSupplier()
        {
            return this._productList.Join(
                            this._supplierList,
                            p => p.Id,
                            s => s.ProductId,
                            (p, s) => (p.ProductName, s.SupplierName));
        }
    }
}
