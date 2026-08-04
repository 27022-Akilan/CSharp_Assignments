using AssignmentThree.Model;
using ConsoleTables;

namespace AssignmentThree
{
    /// <summary>
    ///  A helper class to Get and  validate the input
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// To get the name of the product from the user.
        /// </summary>
        /// <param name="name">Contains the name and returned using out parameter</param>
        /// <param name="field">Contains the field to be displayed to the user.</param>
        /// <returns>True - Successfully got the Name || False - Cant get the name , out of tries </returns>
        public static bool GetName(out string name, string field)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine($"\nEnter the {field}");
                name = Console.ReadLine() ?? string.Empty;
                string result = Validator.ValidateName(name.Trim());
                if (result == string.Empty)
                {
                    return true;
                }

                DisplayWarning(result);
                DisplayWarning($"Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get the product Id from the user.
        /// </summary>
        /// <param name="productId">It stores the Id of the product and returns as out parameter</param>
        /// <param name="prompt">It stores the Prompt to be displayed.</param>
        /// <returns>True - Got the valid product Id || False - Cant get a valid product Id (out of tries)</returns>
        public static bool GetId(out string productId, string prompt)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine($"\nEnter the ID {prompt}");
                productId = Console.ReadLine() ?? string.Empty;
                string result = Validator.ValidateId(productId);
                if (result == string.Empty)
                {
                    return true;
                }

                DisplayWarning(result);
                DisplayWarning($"Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get the Price in the double.
        /// </summary>
        /// <param name="productPrice">Gets and returns a price (out parameter)</param>
        /// <returns>True - Got the valid product price || False - Cant get a valid product price (out of tries)</returns>
        public static bool GetPrice(out double productPrice)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("\nEnter the price:");
                string productPriceAsString = ReadInput();
                string result = Validator.ValidatePrice(productPriceAsString, out productPrice);
                if (result == string.Empty)
                {
                    return true;
                }

                DisplayWarning(result);
                DisplayWarning($"Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get a number.
        /// </summary>
        /// <param name="number">Number (as out) stores the number</param>
        /// <returns>True - Got the valid number || False - Invalid Number and out of tries</returns>
        public static bool GetNumber(out int number)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("\nEnter the Choice Number:");
                string numberASString = ReadInput();
                if (int.TryParse(numberASString, out number))
                {
                    return true;
                }

                Helper.DisplayWarning($"The entered value needs to be a number , Tries left {tries}");
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        /// To get the product Quantity.
        /// </summary>
        /// <param name="productQuantity">Stores Product quantity and returns through as out parameter</param>
        /// <returns>True - Got the valid Quantity || False - Invalid Quantity and out of tries</returns>
        public static bool GetQuantity(out long productQuantity)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("\nEnter the Quantity:");
                string productQuantityAsString = ReadInput();
                string result = Validator.ValidateQuantity(productQuantityAsString, out productQuantity);
                if (result == string.Empty)
                {
                    return true;
                }

                DisplayWarning(result);
                DisplayWarning($"Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        /// Prompt for Yes (Y/y) or No (N/n) response.
        /// </summary>
        /// <param name="shouldProceed">Outputs true if Y/y, false if N/n.</param>
        /// <param name="promptMessage">Message to display to the user.</param>
        /// <returns>True if valid response was given, false if out of tries.</returns>
        public static bool GetYesOrNo(out bool shouldProceed, string promptMessage)
        {
            shouldProceed = false;
            int tries = 3;
            do
            {
                tries--;
                Console.Write($"{promptMessage} (y/n): ");
                string input = ReadInput().ToLower();
                if (input == "y" || input == "yes")
                {
                    shouldProceed = true;
                    return true;
                }

                if (input == "n" || input == "no")
                {
                    shouldProceed = false;
                    return true;
                }

                DisplayWarning($"Invalid input! Enter 'y' or 'n'. Tries left: {tries}");
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        ///  Displays Failure message in Red color
        /// </summary>
        /// <param name="s">Input for failure message</param>
        public static void DisplayError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        ///  Displays Warning message in Yellow color
        /// </summary>
        /// <param name="s">Input for the Warning message</param>
        public static void DisplayWarning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Success message in Green color
        /// </summary>
        /// <param name="s">Input for the success message</param>
        public static void DisplaySuccess(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the text in the gray color
        /// </summary>
        /// <param name="s">Input for the Grey color message</param>
        public static void WriteLight(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// This prints the Product details in a table format.
        /// </summary>
        /// <param name="list">Contains the List of the products, whereas list cant be changed</param>
        public static void DisplayTable(IEnumerable<ProductInfo> list)
        {
            var table = new ConsoleTable("Id", "Name", "Price", "Quantity");
            foreach (var products in list)
            {
                table.AddRow(products.Id, products.Name, products.Price, products.Quantity);
            }

            table.Configure(options =>
            {
                options.EnableCount = false;
            });
            table.Write();
        }

        /// <summary>
        /// Reads a line from the console and strips all control characters like (^A, ^B, ^c...)
        /// </summary>
        /// <returns>Input string without control characters.</returns>
        private static string ReadInput()
        {
            string input = Console.ReadLine() ?? string.Empty;

            // return input.Trim();
            return new string(input.Where(c => !char.IsControl(c)).ToArray()).Trim();
        }
    }
}