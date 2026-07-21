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
        /// <param name="initialDeposit">initial deposit</param>
        public static void GetNameAndInitialDeposit(out string name, out decimal initialDeposit)
        {
            do
            {
                Console.WriteLine("Enter Your Name: ");
                name = Console.ReadLine() ?? string.Empty;
                if (name != string.Empty && !string.IsNullOrWhiteSpace(name) && IsValidWord(name))
                {
                    break;
                }

                Console.WriteLine("Invalid name!");
            }
            while (true);
            initialDeposit = GetAmount();
        }

        /// <summary>
        /// to create guid
        /// </summary>
        /// <returns>guid</returns>
        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// To get the amount
        /// </summary>
        /// <returns>decimal</returns>
        public static decimal GetAmount()
        {
            Console.WriteLine("inside get method");
            do
            {
                Console.WriteLine("Enter the Amount: ");
                string initialDepositString = Console.ReadLine() ?? string.Empty;
                if (IsNumber(initialDepositString, out decimal initialDeposit))
                {
                    return initialDeposit;
                }

                Console.WriteLine("Invalid name!");
            }
            while (true);
        }
    }
}
