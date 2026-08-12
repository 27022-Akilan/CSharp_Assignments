using AssignmentThree.Model;
using AssignmentThree.Service;
using AssignmentThree.Utilities;

namespace AssignmentThree.View
{
    /// <summary>
    /// Menu Page
    /// </summary>
    public class InventoryView
    {
        private InventoryService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryView"/> class
        /// </summary>
        /// <param name="service">This gets the InventoryService object. (DI)</param>
        public InventoryView(InventoryService service)
        {
            this._productService = service;
        }

        /// <summary>
        /// Displays the menu and allows the user to navigate
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("Inventory App");
            bool exitFlag = true;
            do
            {
                Console.Clear();
                Console.WriteLine("======================================================" +
               "\n1.Add Product" +
               "\n2.Edit Product" +
               "\n3.Delete Product" +
               "\n4.Search Product" +
               "\n5.Display Product" +
               "\n6.Exit" +
               "\n======================================================");
                int choice;
                if (!ConsoleReader.GetNumber(out choice))
                {
                    ConsolePresenter.DisplayError("Invalid Choice so application aborting");
                    break;
                }

                MenuOption option = (MenuOption)choice;

                switch (option)
                {
                    // Add Product
                    case MenuOption.AddProduct:
                        string productName, productId;
                        double productPrice;
                        long productQuantity;
                        if (!ConsoleReader.GetId(out productId, "of the product") || !ConsoleReader.GetName(out productName, "Product Name")
                            || !ConsoleReader.GetPrice(out productPrice) || !ConsoleReader.GetQuantity(out productQuantity))
                        {
                            ConsolePresenter.DisplayError("Aborting due to invalid tries!!");
                            break;
                        }

                        OperationMessage message = this._productService.Add(productId, productName, productPrice, productQuantity);
                        this.DisplayMessage(message);
                        break;

                    // Edit Product
                    case MenuOption.EditProduct:

                        IEnumerable<ProductInfo> list = this._productService.GetAll();
                        if (list.Count() == 0)
                        {
                            ConsolePresenter.DisplayError("No products found");
                            break;
                        }

                        ConsolePresenter.DisplayTable(list);
                        if (ConsoleReader.GetId(out productId, "of the product to be Edited"))
                        {
                            ProductInfo? product = this._productService.GetProduct(productId);
                            this.EditField(product);
                            break;
                        }

                        ConsolePresenter.DisplayError("The Type of Product Id is Invalid!");
                        break;

                    // Delete Product
                    case MenuOption.DeleteProduct:

                        list = this._productService.GetAll();
                        if (list.Count() == 0)
                        {
                            ConsolePresenter.DisplayError("No Products found");
                            break;
                        }

                        ConsolePresenter.DisplayTable(list);
                        Console.WriteLine("Enter the Id to be deleted");
                        ConsoleReader.GetId(out string id, "of the product to be deleted");
                        if (this._productService.Delete(id))
                        {
                            ConsolePresenter.DisplaySuccess("Deleted the product Successfully.");
                        }
                        else
                        {
                            ConsolePresenter.DisplayError("Cant Delete the Product , Id doesn't Exists");
                        }

                        break;

                    // Display Product
                    case MenuOption.DisplayProduct:
                        list = this._productService.GetAll();
                        if (list.Count() == 0)
                        {
                            ConsolePresenter.DisplayError("No products found");
                            break;
                        }

                        ConsolePresenter.DisplayTable(list);
                        break;

                    // Search Product
                    case MenuOption.SearchProduct:
                        if (this._productService.IsEmptyRepository())
                        {
                            ConsolePresenter.DisplayError("No products found");
                            break;
                        }

                        this.SearchProduct();
                        break;

                    // Exit
                    case MenuOption.Exit:
                        exitFlag = false;
                        ConsolePresenter.DisplaySuccess("Exiting the Application");
                        break;

                    // Default Method
                    default:
                        ConsolePresenter.DisplayError("Enter a valid number between 1-6");
                        break;
                }

                ConsolePresenter.WriteLight("Press Any key To Continue");
                Console.ReadKey();
            }
            while (exitFlag);
        }

        /// <summary>
        /// To Edit the user required field
        /// </summary>
        /// <param name="product">Product Info of the Product to be edited</param>
        public void EditField(ProductInfo? product)
        {
            if (product == null)
            {
                ConsolePresenter.DisplayError("No products found");
                return;
            }

            Console.WriteLine($"\n--- Editing Product: {product.Name} (ID: {product.Id}) ---");

            if (ConsoleReader.GetYesOrNo(out bool editName, "Edit Name?") && editName)
            {
                if (ConsoleReader.GetName(out string newName, "New Name"))
                {
                    product.Name = newName;
                }
            }

            if (ConsoleReader.GetYesOrNo(out bool editPrice, "Edit Price?") && editPrice)
            {
                if (ConsoleReader.GetPrice(out double newPrice))
                {
                    product.Price = newPrice;
                }
            }

            if (ConsoleReader.GetYesOrNo(out bool editQuantity, "Edit Quantity?") && editQuantity)
            {
                if (ConsoleReader.GetQuantity(out long newQuantity))
                {
                    product.Quantity = newQuantity;
                }
            }

            if (this._productService.Edit(product))
            {
                ConsolePresenter.DisplaySuccess("Product updated successfully!");
            }
            else
            {
                ConsolePresenter.DisplayError("Failed to update product.");
            }
        }

        /// <summary>
        /// To search the product based on name or id or both.
        /// </summary>
        public void SearchProduct()
        {
            string searchName = string.Empty, searchId = string.Empty;

            if (ConsoleReader.GetYesOrNo(out bool byName, "Search by Name?") && byName)
            {
                ConsoleReader.GetName(out searchName, "Product Name");
            }

            if (ConsoleReader.GetYesOrNo(out bool byId, "Search by ID?") && byId)
            {
                ConsoleReader.GetId(out searchId, "of the Product to be Searched");
            }

            if (!byName && !byId)
            {
                ConsolePresenter.DisplayError("Search cancelled (no search criteria selected).");
                return;
            }

            IEnumerable<ProductInfo> productList = Enumerable.Empty<ProductInfo>();
            try
            {
                productList = this._productService.GetIfExists(searchName, searchId);
            }
            catch (Exception ex)
            {
                ConsolePresenter.DisplayError($"Unexpected Error : {ex}");
            }

            if (productList != null && productList.Any())
            {
                ConsolePresenter.DisplayTable(productList);
                return;
            }

            ConsolePresenter.DisplayError("No matching products found!");
        }

        /// <summary>
        /// To Get The Message for the particular Enum
        /// </summary>
        /// <param name="message">Its the Enum</param>
        public void DisplayMessage(OperationMessage message)
        {
            switch (message)
            {
                case OperationMessage.AddedSuccessFull:
                    ConsolePresenter.DisplaySuccess("Product Added Successfully");
                    break;

                case OperationMessage.ProductIdAlreadyExists:
                    ConsolePresenter.DisplayError("Product ID Already Exists \nCant Add!");
                    break;
            }
        }
    }
}
