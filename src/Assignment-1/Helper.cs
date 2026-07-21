namespace Assignment1
{
    /// <summary>
    /// hjjh
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Get Name , Phone, Email, notes from user
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        public static void GetInput(out string? name, out string? phone, out string? email, out string? notes)
        {
            Console.WriteLine("Enter name");
            name = Console.ReadLine();

            Console.WriteLine("Enter Phone number");
            phone = Console.ReadLine();

            Console.WriteLine("Enter email");
            email = Console.ReadLine();

            Console.WriteLine("Enter notes");
            notes = Console.ReadLine();
        }

        /// <summary>
        /// Check name is valid
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>bool</returns>
        public static string IsValidName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                // Invalid Name
                return "INVALID NAME";
            }

            // Valid Name
            return "VALID NAME";
        }

        /// <summary>
        /// Check phone  is valid
        /// </summary>
        /// <param name="phone">phone</param>
        /// <returns>bool</returns>
        public static string IsValidPhone(string? phone)
        {
            if (long.TryParse(phone, out _))
            {
                if (phone.Length != 10)
                {
                    // Invalid Phone Number Length
                    return "INVALID PHONE LENGTH";
                }

                // Valid Phone
                return "VALID PHONE";
            }

            if (phone == null)
            {
                phone = string.Empty;
            }

            // Invalid Phone
            return "INVALID PHONE";
        }

        /// <summary>
        /// Check email is valid
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>string</returns>
        public static string IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length == 0)
            {
                // Valid Email
                return "VALID EMAIL";
            }

            if (email.Contains("@"))
            {
                return "VALID EMAIL";
            }

            return "INVALID EMAIL";
        }

        /// <summary>
        /// Validating Gui Id
        /// </summary>
        /// <param name="guiId">Guid to be validated</param>
        /// <param name="validatedId">Out field to give the validated Guid</param>
        /// <returns>bool</returns>
        public static bool IsValidGId(string? guiId, out Guid validatedId)
        {
            return Guid.TryParse(guiId, out validatedId);
        }

        /// <summary>
        /// Checking name or phone is null
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <returns>bool</returns>
        public static bool IsNotNull(string? name, string? phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// String comparison
        /// </summary>
        /// <param name="a">1st str</param>
        /// <param name="b">2nd str</param>
        /// <returns>bool</returns>
        public static bool Compare(string? a, string? b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}
