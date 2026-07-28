using AssignmentThree.Model;
using ConsoleTables;

namespace AssignmentThree
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// To check if its a number
        /// </summary>
        /// <param name="number">string num</param>
        /// <param name="res">res to be outed</param>
        /// <returns>bool</returns>
        public static bool IsNumber(string number, out decimal res)
        {
            res = 0;
            if (number != string.Empty && !string.IsNullOrWhiteSpace(number) && decimal.TryParse(number, out res))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check Valid color or not
        /// </summary>
        /// <param name="word">color</param>
        /// <returns>True - Valid ; False - Invalid word</returns>
        public static bool IsValidWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return !word.All(char.IsDigit);
        }

        /// <summary>
        /// To get the name of the product from the user.
        /// </summary>
        /// <param name="name">contains the name and returned</param>
        /// <param name="field">Contains the field name</param>
        /// <returns>True - Successfully got the Name, False - Cant get the name , out of tries </returns>
        public static bool GetName(out string name, string field)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine($"\nEnter the {field}");
                name = Console.ReadLine() ?? string.Empty;
                if (name != string.Empty && !string.IsNullOrWhiteSpace(name) && IsValidWord(name))
                {
                    return true;
                }

                Helper.WriteWarning($"Invalid name! Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get the product Id from the user.
        /// </summary>
        /// <param name="productId">It stores the Id of the product and returns as out parameter</param>
        /// <returns>True - Got the valid product Id , False - Cant get a valid product Id (out of tries)</returns>
        public static bool GetId(out string productId)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("\nEnter the ID:");
                productId = Console.ReadLine() ?? string.Empty;
                if (productId != string.Empty && !string.IsNullOrWhiteSpace(productId))
                {
                    return true;
                }

                Helper.WriteWarning($"Invalid Id! Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get the Price in the double.
        /// </summary>
        /// <param name="productPrice">Gets and returns a price (out paarmeter)</param>
        /// <returns>True - Got the valid product price , False - Cant get a valid product price (out of tries)</returns>
        public static bool GetPrice(out double productPrice)
        {
            int tries = 3;
            do
            {
                bool validPrice = true;
                tries--;
                Console.WriteLine("\nEnter the price:");
                string productPriceAsString = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(productPriceAsString, out productPrice))
                {
                    validPrice = productPrice > 0;
                    if (validPrice)
                    {
                        return true;
                    }
                }

                if (!validPrice)
                {
                    Helper.WriteWarning($"Invalid Price cant be less than 0! Number of Tries Left is:{tries}\n");
                }
                else
                {
                    Helper.WriteWarning($"Invalid Price! Number of Tries Left is:{tries}\n");
                }
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get a number.
        /// </summary>
        /// <param name="number">Number (as out) stores the numbert</param>
        /// <returns>True - Got the valid number , False - Invalid Number and out of tries</returns>
        public static bool GetNumber(out int number)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("\nEnter the Choice Number:");
                string? numberASString = Console.ReadLine();
                if (int.TryParse(numberASString, out number))
                {
                    return true;
                }

                Helper.WriteWarning($"The entered value needs to be a number , Tries left {tries}");
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        /// To get the product Quantity.
        /// </summary>
        /// <param name="productQuantity">Stores Product quantity and returns through as out parmeter</param>
        /// <returns>True - Got the valid Quantity , False - Invalid Quantity and out of tries</returns>
        public static bool GetQuantity(out long productQuantity)
        {
            int tries = 3;
            do
            {
                bool validQuantity = true;
                tries--;
                Console.WriteLine("\nEnter the Quantity:");
                string? productQuantityAsString = Console.ReadLine();
                if (long.TryParse(productQuantityAsString, out productQuantity))
                {
                    validQuantity = productQuantity >= 0;
                    if (validQuantity)
                    {
                        return true;
                    }
                }

                if (!validQuantity)
                {
                    Helper.WriteWarning($"Quantity cant be less than 0 , Tries left {tries}");
                }
                else
                {
                    Helper.WriteWarning($"Invalid Quantity , Tries left {tries}");
                }
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        /// Method to get the 0 or 1 for editing
        /// </summary>
        /// <param name="number">Holds 0(Dont edit) or 1(Edit) </param>
        /// <param name="field">Field Which is to be edited</param>
        /// <returns>True - Got the valid input , False - Invalid input and out of tries</returns>
        public static bool GetZeroOrOne(out int number, string field)
        {
            int tries = 3;
            do
            {
                bool validNumber = false;
                tries--;
                Console.WriteLine($"\nEnter 0 or 1 to {field}");
                string? numberASString = Console.ReadLine();
                if (int.TryParse(numberASString, out number))
                {
                    validNumber = number == 1 || number == 0;
                    if (validNumber)
                    {
                        return true;
                    }

                    Helper.WriteWarning($"The entered value needs to be 1 or 0 , Tries left {tries}");
                }
                else
                {
                    Helper.WriteWarning($"The entered value needs to be a number , Tries left {tries}");
                }
            }
            while (tries > 0);

            return false;
        }

        /// <summary>
        ///  Displays Failiure message in Red color
        /// </summary>
        /// <param name="s">Input for failure message</param>
        public static void WriteFailed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        ///  Displays Warning message in Yellow color
        /// </summary>
        /// <param name="s">Input for the Warning message</param>
        public static void WriteWarning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Success meaasage in Green color
        /// </summary>
        /// <param name="s">Input for the success message</param>
        public static void WriteSuccess(string s)
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
        public static void PrintTable(IEnumerable<ProductInfo> list)
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
    }
}
