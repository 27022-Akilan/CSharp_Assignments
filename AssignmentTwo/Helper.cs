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
        /// <returns> bool </returns>
        public static bool IsValidWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return word.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        /// <summary>
        /// getting name and initial deposit
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>bool which tells true for succes and false for attained max no.of trys</returns>
        public static bool GetName(out string name)
        {
            int trys = 3;
            do
            {
                trys--;
                Console.WriteLine("Enter Your Name: ");
                name = Console.ReadLine() ?? string.Empty;
                if (name != string.Empty && !string.IsNullOrWhiteSpace(name) && IsValidWord(name))
                {
                    return false;
                }

                Helper.WriteFailed($"Invalid name! Number of Trys Left is:{trys}\n");
            }
            while (trys > 0);
            return true;
        }

        /// <summary>
        /// To get the amount
        /// </summary>
        /// <param name="amount">name</param>
        /// <param name="accountType">Account Type</param>
        /// <returns>If correct ammount is entered returns true else after 3 trys returns false</returns>
        public static bool GetAmount(out decimal amount, int accountType)
        {
            int trys = 3;
            do
            {
                trys--;
                string res = string.Empty;
                Console.WriteLine("Enter the Amount: ");
                string stringAmount = Console.ReadLine() ?? string.Empty;
                if (IsNumber(stringAmount, out amount))
                {
                    if (IsAmountIsGreaterThanInitalDeposit(amount, accountType))
                    {
                        // as it gets the input and valid so the outOfTrys == false
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

                Helper.WriteFailed($"Invalid amount!\n{res} \nNumber of Trys Left is:{trys}\n ");
            }
            while (trys > 0);
            return true;
        }

        /// <summary>
        /// To Check is its a valid minimum Deposit
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="accountType">Account TYpe</param>
        /// <returns>bool</returns>
        public static bool IsAmountIsGreaterThanInitalDeposit(decimal amount, int accountType)
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
        /// Failiure message
        /// </summary>
        /// <param name="s">Input for failure message</param>
        public static void WriteFailed(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
