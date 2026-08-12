using AssignmentThree.Model;
using AssignmentThree.Model.Enums;

namespace AssignmentThree.Repository
{
    /// <summary>
    /// Interface for the Repository
    /// </summary>
    public interface IInventoryRepository
    {
        /// <summary>
        /// Must be implemented in the derived class.
        /// </summary>
        /// <param name="id">Contains the Product Id</param>
        /// <param name="name">Contains the Product name</param>
        /// <param name="price">Contains the Product Price</param>
        /// <param name="quantity">Contains the Product Quantity</param>
        /// <returns>An OperationMessage enum</returns>
        OperationResult AddProduct(string id, string name, double price, long quantity);

        /// <summary>
        /// Must be implemented inside the derived class.
        /// </summary>
        /// <param name="id">Contains the Product Id</param>
        /// <returns>Product object containing the Product Info</returns>
        ProductInfo? GetProduct(string id);

        /// <summary>
        /// Must be implemented inside the Derived class.
        /// </summary>
        /// <param name="editedProduct">Product object containing the information of the product to be edited</param>
        /// <returns>True - If Updated || False - If not Updated</returns>
        bool UpdateProduct(ProductInfo editedProduct);

        /// <summary>
        /// Must be implemented inside the Derived class.
        /// </summary>
        /// <returns>An IEnumerable List of Products which cant be modified</returns>
        IEnumerable<ProductInfo> GetAllProducts();

        /// <summary>
        /// Must be implemented inside the Derived class
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <returns>True - If Deleted || False - Cant be deleted</returns>
        bool DeleteProductById(string id);

        /// <summary>
        /// Must be implemented inside the Derived class
        /// </summary>
        /// <param name="searchName">Name of the product to be searched</param>
        /// <param name="searchId">Id of the product to be searched</param>
        /// <returns>IEnumerable List of products which cant be modified</returns>
        IEnumerable<ProductInfo> SearchProduct(string searchName, string searchId);

        /// <summary>
        /// Checks whether the Repository is empty or not and must be implemented in derived class.
        /// </summary>
        /// <returns>True - If the repository is empty | False - If repository is not Empty</returns>
        bool IsEmpty();
    }
}
