namespace AssignmentNine.Model
{
    /// <summary>
    /// Represent the supplier information.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierId">Supplier Id</param>
        /// <param name="supplierName">Supplier Name</param>
        /// <param name="productId">Product Id</param>
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets the product Id
        /// </summary>
        /// <value>Supplier Id</value>
        public int SupplierId { get; }

        /// <summary>
        /// Gets the Supplier Id
        /// </summary>
        /// <value>Supplier name</value>
        public string SupplierName { get; }

        /// <summary>
        /// Gets the ProductId
        /// </summary>
        /// <value>Product Id</value>
        public int ProductId { get; }
    }
}
