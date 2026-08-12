using AssignmentThree.Model;
using AssignmentThree.Model.Enums;
using AssignmentThree.Repository;

namespace AssignmentThree.Service
{
    /// <summary>
    /// Provides the Inventory Services
    /// </summary>
    public class InventoryService
    {
        private IInventoryRepository _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class
        /// </summary>
        /// <param name="productRepo">Object of the repository (for DI)</param>
        public InventoryService(IInventoryRepository productRepo)
        {
            this._productRepo = productRepo;
        }

        /// <summary>
        /// To Add the product.
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>True - Success full Add | False - Cant Add</returns>
        public OperationResult AddProduct(string id, string name, double price, long quantity)
        {
            return this._productRepo.AddProduct(id, name, price, quantity);
        }

        /// <summary>
        /// Checks whether the product exists or not.
        /// </summary>
        /// <param name="id">Id of the product to be searched</param>
        /// <returns>Product object - If Product Exists || Null - Product does not exists</returns>
        public ProductInfo? GetProduct(string id)
        {
            return this._productRepo.GetProduct(id);
        }

        /// <summary>
        /// To edit the product information.
        /// </summary>
        /// <param name="editedProduct">Has the entire Product information as an object</param>
        /// <returns>True - If Updated || False - If Not Updated</returns>
        public bool EditProduct(ProductInfo editedProduct)
        {
            return this._productRepo.UpdateProduct(editedProduct);
        }

        /// <summary>
        /// This service gets and returns the duplicated Product List
        /// </summary>
        /// <returns>A List of Products</returns>
        public IEnumerable<ProductInfo> GetAllProducts()
        {
            return this._productRepo.GetAllProducts();
        }

        /// <summary>
        /// This service deletes the product.
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <returns>True - Product Deleted || False - Cant Delete product</returns>
        public bool Delete(string id)
        {
            return this._productRepo.DeleteProductById(id);
        }

        /// <summary>
        /// Checks whether there are products or not
        /// </summary>
        /// <returns>True - If Products are Empty || False - If Products are not empty</returns>
        public bool IsEmptyRepository()
        {
            return this._productRepo.IsEmpty();
        }

        /// <summary>
        /// Service to search the products and return to the view
        /// </summary>
        /// <param name="searchName">Product Name to be searched</param>
        /// <param name="searchId">Product Id to be searched</param>
        /// <returns>Enumerable list of searched products</returns>
        public IEnumerable<ProductInfo> GetIfExists(string searchName, string searchId)
        {
            return this._productRepo.SearchProduct(searchName, searchId);
        }
    }
}