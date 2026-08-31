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
        public void GroupByCategory()
        {
            var groups = this._productList.GroupBy(p => p.Category)
                                          .Select(g =>
                                          (g.Key, g.Max(g => g.Price), g.Count()));

            Console.WriteLine("Groups by Category and displays the maximum price, and count in each category.");
            TablePresenter.DisplayProducts(groups);
        }

        /// <summary>
        /// Joins the product and supplier.
        /// </summary>
        public void RelateProductAndSupplier()
        {
            var innerJoin = this._productList.Join(
                            this._supplierList,
                            p => p.Id,
                            s => s.ProductId,
                            (p, s) => (p.ProductName, s.SupplierName));

            Console.WriteLine("Join Query result !!!");
            TablePresenter.DisplayProductSupplier(innerJoin);
        }
    }
}
