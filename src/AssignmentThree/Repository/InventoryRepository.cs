using AssignmentThree.Model;

namespace AssignmentThree.Repository
{
    /// <summary>
    /// Its used to store and retrive data (In-Memory)
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
        /// <param name="id">Id of the product</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Success or Error Specific Meaasage</returns>
        public OperationMessage Add(string id, string name, double price, long quantity)
        {
            foreach (ProductInfo product in this._product)
            {
                if (product.Id.Equals(id))
                {
                    return OperationMessage.ProductIdAlreadyExists;
                }
            }

            ProductInfo productInfo = new ProductInfo(id, name, price, quantity);
            this._product.Add(productInfo);
            return OperationMessage.AddedSuccessFull;
        }

        /// <summary>
        /// Checks whether the product exists or not.
        /// </summary>
        /// <param name="id">Id of the product to be searched</param>
        /// <returns>Product object - If Product exists || Null - Product does not exists</returns>
        public ProductInfo? ShowProduct(string id)
        {
            foreach (ProductInfo product in this._product)
            {
                if (product.Id.Equals(id))
                {
                    return new ProductInfo(product.Id, product.Name, product.Price, product.Quantity);
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the Product Information
        /// </summary>
        /// <param name="editedProduct">Holds the entire information of the Edited Product </param>
        /// <returns>True - If Product Upadated  || False - If Product is not Updated</returns>
        public bool Update(ProductInfo editedProduct)
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
        ///  To show all the products
        /// </summary>
        /// <returns>IEnumerable List which cannot be modified</returns>
        public IEnumerable<ProductInfo> ShowAll()
        {
            return this._product.Select(p => new ProductInfo(p.Id, p.Name, p.Price, p.Quantity));
        }

        /// <summary>
        /// It Deletes the particular product.
        /// </summary>
        /// <param name="id">Id of the product to be deleted.</param>
        /// <returns>True - Deleted Product || False - Cant Delete product</returns>
        public bool DeleteById(string id)
        {
            foreach (var product in this._product)
            {
                if (product.Id.Equals(id))
                {
                    this._product.Remove(product);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// To Search and return products based on the Name and Id
        /// </summary>
        /// <param name="searchName">Product Name to be searched</param>
        /// <param name="searchId">Product Id to be searched</param>
        /// <returns>Enumerable list of serched products</returns>
        public IEnumerable<ProductInfo> Search(string searchName, string searchId)
        {
            return this._product.Where(p => (p.Name != string.Empty && p.Name!.Contains(searchName, StringComparison.OrdinalIgnoreCase)) || p.Id.Equals(searchId))
        .Select(p => new ProductInfo(p.Id, p.Name, p.Price, p.Quantity));
        }

        /// <summary>
        ///  To chcek whether the Product List is Empty or not
        /// </summary>
        /// <returns>True - If Products are Empty || False - If There products exists</returns>
        public bool IsEmpty()
        {
            return this._product.Count() == 0 ? true : false;
        }
    }
}
