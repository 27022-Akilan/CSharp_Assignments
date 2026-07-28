using AssignmentThree.Model;
using AssignmentThree.Service;

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
        public void Menu()
        {
            Console.WriteLine("Inventoy App");
            bool exitFlag = true;
            do
            {
                Console.WriteLine("======================================================" +
               "\n1.Add Product" +
               "\n2.Edit Product" +
               "\n3.Delete Product" +
               "\n4.Search Product" +
               "\n5.Display Product" +
               "\n6.Exit" +
               "\n======================================================");
                int choice;
                if (Helper.GetNumber(out choice))
                {
                    MenuOption option = (MenuOption)choice;

                    switch (option)
                    {
                        // Add Product
                        case MenuOption.AddProduct:
                            string productName, productId;
                            double productPrice;
                            long productQuantity;
                            if (!Helper.GetName(out productName, "Product Name") || !Helper.GetId(out productId)
                                || !Helper.GetPrice(out productPrice) || !Helper.GetQuantity(out productQuantity))
                            {
                                Helper.WriteFailed("Aborting due to invalid tries!!");
                                break;
                            }

                            OperationMessage message = this._productService.Put(productId, productName, productPrice, productQuantity);
                            Helper.WriteSuccess(this.GetMessage(message));
                            break;

                        // Edit Product
                        case MenuOption.EditProduct:

                            IEnumerable<ProductInfo> list = this._productService.Get();
                            if (list.Count() == 0)
                            {
                                Helper.WriteFailed("Products are Empty , Can't be edited");
                                break;
                            }

                            if (Helper.GetId(out productId))
                            {
                                ProductInfo? product = this._productService.GetProduct(productId);
                                this.EditField(product);
                            }
                            else
                            {
                                Helper.WriteFailed("The Type of Product Id is Invalid!");
                            }

                            break;

                        // Delete Product
                        case MenuOption.DeleteProduct:

                            list = this._productService.Get();
                            if (list.Count() == 0)
                            {
                                Helper.WriteFailed("Products are Empty , Cant be Deleted");
                                break;
                            }

                            Console.WriteLine("Enter the Id to be deleted");
                            Helper.GetId(out string id);
                            if (this._productService.Delete(id))
                            {
                                Helper.WriteSuccess("Deleted the product Successfully.");
                            }
                            else
                            {
                                Helper.WriteFailed("Cant Delete the Product , Id doesnt Exists");
                            }

                            break;

                        // Display Product
                        case MenuOption.DisplayProduct:
                            list = this._productService.Get();
                            if (list.Count() == 0)
                            {
                                Helper.WriteFailed("Products are Empty , Can't Display");
                                break;
                            }

                            Helper.PrintTable(list);
                            break;

                        // Search Product
                        case MenuOption.SearchProduct:
                            if (this._productService.IsEmptyRepository())
                            {
                                Helper.WriteFailed("Products are Empty , Cant Search the Product");
                                break;
                            }

                            Helper.GetName(out string searchName, "Product Name to be searched");
                            Helper.GetId(out string searchId);

                            IEnumerable<ProductInfo> productList = this._productService.GetIfExists(searchName, searchId);
                            if (productList != null && productList.Count() != 0)
                            {
                                Helper.PrintTable(productList);
                                break;
                            }

                            Helper.WriteFailed("No Matching Contact Found!!");
                            break;

                        // Exit
                        case MenuOption.Exit:
                            exitFlag = false;
                            Helper.WriteSuccess("Exiting the Application");
                            break;

                        // Default Method
                        default:
                            Helper.WriteFailed("Enter a valid number between 1-6");
                            break;
                    }
                }
                else
                {
                    Helper.WriteFailed("Invalid Choice so application aborting");
                    break;
                }
            }
            while (exitFlag);
        }

        /// <summary>
        /// To Get The Meaasage for the particular Enum
        /// </summary>
        /// <param name="message">Its the Enum</param>
        /// <returns>Returns the Message for the particular enum</returns>
        public string GetMessage(OperationMessage message)
        {
            return message switch
            {
                OperationMessage.AddedSuccessFull => "Product Added Successfully",
                OperationMessage.ProductIdAlreadyExists => "Product Already Exists \nCant Add!",
                OperationMessage.ProductDoesNotexists => "Product Does Not Found",
                _ => "Unehandeledessacdgfthd",
            };
        }

        /// <summary>
        /// To Edit a the user Required field
        /// </summary>
        /// <param name="product">Product Info of the Prodcut to be edited</param>
        public void EditField(ProductInfo? product)
        {
            if (product != null)
            {
                Console.WriteLine("========================================================" +
                    "\nPress 1 to edit and 0 to skip editing of the filed" +
                    "\n========================================================");
                Console.WriteLine("Product name (1 / 0) :");
                Helper.GetZeroOrOne(out int yesOrNo, "Product Name");
                if (yesOrNo == 1 && Helper.GetName(out string editName, "product name to be edited"))
                {
                    product.Name = editName;
                }

                Console.WriteLine("Product Price (1 / 0) :");
                Helper.GetZeroOrOne(out yesOrNo, "Product Price");
                if (yesOrNo == 1 && Helper.GetPrice(out double editPrice))
                {
                    product.Price = editPrice;
                }

                Console.WriteLine("Product Quantity (1 / 0) :");
                Helper.GetZeroOrOne(out yesOrNo, "Product Quantity");
                if (yesOrNo == 1 && Helper.GetQuantity(out long editQuantity))
                {
                    product.Quantity = editQuantity;
                }

                bool edited = this._productService.Edit(product);
                if (edited)
                {
                    Helper.WriteSuccess("Edited Successfully");
                }
                else
                {
                    Helper.WriteFailed("Edit Failed");
                }
            }
            else
            {
                Helper.WriteFailed("There is no product corresponding to the Product ID");
            }
        }
    }
}
