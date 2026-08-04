namespace AssignmentTwo
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

            return word.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        /// <summary>
        /// Getting name and initial deposit
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>True - Success, False - Out Of tries </returns>
        public static bool GetName(out string name)
        {
            int tries = 3;
            do
            {
                tries--;
                Console.WriteLine("Enter Your Name: ");
                name = Console.ReadLine() ?? string.Empty;
                if (name != string.Empty && !string.IsNullOrWhiteSpace(name) && IsValidWord(name))
                {
                    return false;
                }

                Helper.DisplayWarningMessage($"Invalid name! Number of Tries Left is:{tries}\n");
            }
            while (tries > 0);
            return true;
        }

        /// <summary>
        /// To get the amount
        /// </summary>
        /// <param name="amount">name</param>
        /// <param name="accountType">Account Type</param>
        /// <returns>True - Valid Amount False - Invalid Amount</returns>
        public static bool GetAmount(out decimal amount, int accountType)
        {
            int tries = 3;
            do
            {
                tries--;
                string res = string.Empty;
                Console.WriteLine("Enter the Amount :");
                string stringAmount = Console.ReadLine() ?? string.Empty;
                if (IsNumber(stringAmount, out amount))
                {
                    if (IsAmountIsGreaterThanInitialDeposit(amount, accountType))
                    {
                        // as it gets the input and valid so the out Of Tries == false
                        return false;
                    }

                    if (accountType == 1)
                    {
                        res = "Your Deposit is Lesser Than 2000";
                    }
                    else
                    {
                        res = "Your Deposit is Lesser Than 1000";
                    }
                }
                else
                {
                    res = "Your Deposit Should be Number";
                }

                Helper.DisplayWarningMessage($"Invalid amount!\n{res} \nNumber of Tries Left is:{tries}\n ");
            }
            while (tries > 0);
            return true;
        }

        /// <summary>
        /// To Check is its a valid minimum Deposit
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="accountType">Account TYpe</param>
        /// <returns>True - Valid Initial Deposit ; False - Invalid Initial Deposit</returns>
        public static bool IsAmountIsGreaterThanInitialDeposit(decimal amount, int accountType)
        {
            if (accountType == 1)
            {
                if (amount >= 2000)
                {
                    return true;
                }

                return false;
            }

            if (amount >= 1000)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets and validates quantity parameters such as length, breadth, and radius.
        /// </summary>
        /// <param name="s">Parameter to identify whether it is to get length, breadth, etc.</param>
        /// <param name="symbol">Has the unit label like m (meters), rs (rupees).</param>
        /// <returns>Decimal number representing valid quantity; -1 if invalid (out of tries).</returns>
        public static decimal GetValidQuantity(string s, string symbol)
        {
            int tries = 3;
            decimal number;
            do
            {
                tries--;
                Console.WriteLine($"Enter the {s}");
                string? num = Console.ReadLine() ?? string.Empty;
                if (Helper.IsNumber(num, out number))
                {
                    if (number > 0)
                    {
                        return number;
                    }
                    else
                    {
                        Helper.DisplayWarningMessage($"Enter the valid {s} greater than 0. No of Tries left {tries}");
                    }
                }
                else
                {
                    Helper.DisplayWarningMessage($"Invalid number , Your input should only be a number. No of Tries left {tries}");
                }
            }
            while (tries > 0);

            return -1;
        }

        /// <summary>
        /// Displays Failure message in Red color.
        /// </summary>
        /// <param name="s">Input for failure message</param>
        public static void DisplayFailedMessage(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Warning message in Yellow color.
        /// </summary>
        /// <param name="s">Input for the Warning message</param>
        public static void DisplayWarningMessage(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Success message in Green color.
        /// </summary>
        /// <param name="s">Input for the success message</param>
        public static void DisplaySuccessMessage(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
