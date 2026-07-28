using AssignmentThree.Model;
using AssignmentThree.Repository;

namespace AssignmentThree.Service
{
    /// <summary>
    /// Provides the Inventory Services
    /// </summary>
    public class InventoryService
    {
        private InventoryRepository _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class
        /// </summary>
        /// <param name="productRepo">Object of the repository (for DI)</param>
        public InventoryService(InventoryRepository productRepo)
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
        /// <returns>True - Successfull Add | False - Cant Add</returns>
        public OperationMessage Put(string id, string name, double price, long quantity)
        {
            return this._productRepo.Add(id, name, price, quantity);
        }

        /// <summary>
        /// Checks whether the product exists or not.
        /// </summary>
        /// <param name="id">Id of the product to be searched</param>
        /// <returns>Product object - If Product Exists || Null - Product deosn't exists</returns>
        public ProductInfo? GetProduct(string id)
        {
            return this._productRepo.ShowProduct(id);
        }

        /// <summary>
        /// To edit the product information.
        /// </summary>
        /// <param name="editedProduct">Has the entire Product information as an object</param>
        /// <returns>True - If Updated || False - If Not Updated</returns>
        public bool Edit(ProductInfo editedProduct)
        {
            return this._productRepo.Update(editedProduct);
        }

        /// <summary>
        /// This service gets and returns the duplicated Product List
        /// </summary>
        /// <returns>A List of Products</returns>
        public IEnumerable<ProductInfo> Get()
        {
            return this._productRepo.Show();
        }

        /// <summary>
        /// This service deletes the product.
        /// </summary>
        /// <param name="id">Id of the propduct to be deleted</param>
        /// <returns>True - Deleted Product || False - Cant Delete product</returns>
        public bool Delete(string id)
        {
            return this._productRepo.DeleteProduct(id);
        }

        /// <summary>
        /// Chcks whether there are products or not
        /// </summary>
        /// <returns>True - If its Empty || False - If Products are not empty</returns>
        public bool IsEmptyRepository()
        {
            IEnumerable<ProductInfo> list = this._productRepo.Show();
            if (list == null)
            {
                return true;
            }

            return list.Count() > 0 ? false : true;
        }

        /// <summary>
        /// Service to search the products and return to the view
        /// </summary>
        /// <param name="searchName">Product Name to be searched</param>
        /// <param name="searchId">Product Id to be searched</param>
        /// <returns>Enumerable list of serched products</returns>
        public IEnumerable<ProductInfo> GetIfExists(string searchName, string searchId)
        {
            return this._productRepo.Search(searchName, searchId);
        }
    }
}