using AssignmentThree.Model;

namespace AssignmentThree.Repository
{
    /// <summary>
    /// Used to store and retrieve data (In-Memory)
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        /// <summary>
        /// List to store the Inventory
        /// </summary>
        private List<ProductInfo> _product = new List<ProductInfo>();

        /// <summary>
        /// Add the product into the Repository
        /// </summary>
        /// <param name="product">Contains product</param>
        /// <returns>True - If Added || False otherwise </returns>
        public bool AddProduct(ProductInfo product)
        {
            this._product.Add(product);
            return true;
        }

        /// <summary>
        /// Checks whether the product exists or not.
        /// </summary>
        /// <param name="id">Id of the product to be searched</param>
        /// <returns>Product object - If Product exists || Null - Product does not exists</returns>
        public ProductInfo? GetProduct(string id)
        {
            return this._product.FirstOrDefault(p => p.Id.Equals(id));
        }

        /// <summary>
        /// Updates the Product Information
        /// </summary>
        /// <param name="editedProduct">Holds the entire information of the Edited Product </param>
        /// <returns>True - If Product Updated  || False - If Product is not Updated</returns>
        public bool UpdateProduct(ProductInfo editedProduct)
        {
            foreach (var product in this._product)
            {
                if (product.Id.Equals(editedProduct.Id))
                {
                    product.Name = editedProduct.Name;
                    product.Price = editedProduct.Price;
                    product.Quantity = editedProduct.Quantity;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// To show all the products.
        /// </summary>
        /// <returns>IEnumerable List which cannot be modified</returns>
        public IEnumerable<ProductInfo> GetAllProducts()
        {
            return this._product.Select(p => new ProductInfo(p.Id, p.Name, p.Price, p.Quantity));
        }

        /// <summary>
        /// It deletes the particular product.
        /// </summary>
        /// <param name="id">Id of the product to be deleted.</param>
        /// <returns>True - Product Deleted || False - Cant Delete product</returns>
        public bool DeleteProductById(string id)
        {
            ProductInfo? product = this._product.FirstOrDefault(p => p.Id.Equals(id));
            if (product == null)
            {
                return false;
            }

            this._product.Remove(product);
            return true;
        }

        /// <summary>
        /// To search and return products based on the Name and Id
        /// </summary>
        /// <param name="searchName">Product Name to be searched</param>
        /// <param name="searchId">Product Id to be searched</param>
        /// <returns>Enumerable list of searched products</returns>
        public IEnumerable<ProductInfo> SearchProduct(string searchName, string searchId)
        {
            return this._product.Where(p => (
                !string.IsNullOrEmpty(searchName)
                && p.Name!.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(searchId)
                && p.Id.Equals(searchId)))
                .Select(p => new ProductInfo(p.Id, p.Name, p.Price, p.Quantity));
        }

        /// <summary>
        ///  To check whether the Product List is Empty or not
        /// </summary>
        /// <returns>True - If Products are Empty || False - If There products exists</returns>
        public bool IsEmpty()
        {
            return this._product.Any();
        }
    }
}
