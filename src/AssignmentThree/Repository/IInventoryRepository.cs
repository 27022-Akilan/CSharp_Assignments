using AssignmentThree.Model;

namespace AssignmentThree.Repository
{
    /// <summary>
    /// Interface for the Repository
    /// </summary>
    public interface IInventoryRepository
    {
        /// <summary>
        ///  A Add Method which should be implemented in the derived class
        /// </summary>
        /// <param name="id">Contains the Product Id</param>
        /// <param name="name">Contains the Product name</param>
        /// <param name="price">Contains the Product Price</param>
        /// <param name="quantity">Contains the Product Quantity</param>
        /// <returns>An OperationMessage enum</returns>
        OperationMessage Add(string id, string name, double price, long quantity);

        /// <summary>
        /// Must be implemented inside the derived class.
        /// </summary>
        /// <param name="id">Contains the Poduct Id</param>
        /// <returns>Product object containing the Product Info</returns>
        ProductInfo? ShowProduct(string id);

        /// <summary>
        /// Must be implemented inside the Derived class.
        /// </summary>
        /// <param name="editedProduct">Product object containg the information of the product to be edited</param>
        /// <returns>True - If Updated || False - If not Updated</returns>
        bool Update(ProductInfo editedProduct);

        /// <summary>
        /// Must be implemeneted inside the Derived class.
        /// </summary>
        /// <returns>An IEnumerable List of Products which cant be modified</returns>
        IEnumerable<ProductInfo> ShowAll();

        /// <summary>
        /// Must be implemented inside the Derived class
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <returns>True - If Deleted || False - Cant be deleted</returns>
        bool DeleteById(string id);

        /// <summary>
        /// Must be implemented inside the Derived class
        /// </summary>
        /// <param name="searchName">Name of the proiduct to be searched</param>
        /// <param name="searchId">Id of the product to be searched</param>
        /// <returns>IEnumerable List of products which cant be modified</returns>
        IEnumerable<ProductInfo> Search(string searchName, string searchId);
    }
}
