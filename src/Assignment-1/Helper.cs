using Assignment1.Models;

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
        /// Read name and validate
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Enum result</returns>
        public static ContactValidationResult ReadNameAndValidate(out string? name)
        {
            int trys = 3;
            do
            {
                trys--;
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                if (Helper.IsValidName(name) == ContactValidationResult.ValidName)
                {
                    return ContactValidationResult.ValidName;
                }

                Console.WriteLine($"{ContactValidationResult.InvalidName} {trys} Trys Left");
            }
            while (trys > 0);
            return ContactValidationResult.TrysCompleted;
        }

        /// <summary>
        /// Read and Validate Phone number
        /// </summary>
        /// <param name="phone">string phone number</param>
        /// <returns>Enum result</returns>
        public static ContactValidationResult ReadPhoneAndValidate(out string? phone)
        {
            int trys = 3;
            do
            {
                trys--;
                Console.WriteLine("Enter Phone number");
                phone = Console.ReadLine();
                ContactValidationResult result = Helper.IsValidPhone(phone);
                if (result == ContactValidationResult.ValidPhone)
                {
                    return ContactValidationResult.ValidPhone;
                }

                Console.WriteLine($"{result} {trys} Trys Left");
            }
            while (trys > 0);
            return ContactValidationResult.TrysCompleted;
        }

        /// <summary>
        /// Read and validate email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Enum result</returns>
        public static ContactValidationResult ReadEmailAndValidate(out string? email)
        {
            int trys = 3;
            do
            {
                trys--;
                Console.WriteLine("Enter Email ");
                email = Console.ReadLine();
                ContactValidationResult result = Helper.IsValidEmail(email);
                if (result == ContactValidationResult.ValidEmail)
                {
                    return ContactValidationResult.ValidEmail;
                }

                Console.WriteLine($"{result} {trys} Trys Left");
            }
            while (trys > 0);
            return ContactValidationResult.TrysCompleted;
        }

        /// <summary>
        /// Read notes and validate
        /// </summary>
        /// <param name="notes">notes</param>
        /// <returns>Enum result</returns>
        public static ContactValidationResult ReadNotesAndValidate(out string? notes)
        {
            Console.WriteLine("Enter notes");
            notes = Console.ReadLine();
            return ContactValidationResult.ValidNotes;
        }

        /// <summary>
        /// Check name is valid
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Enum result</returns>
        public static ContactValidationResult IsValidName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                // Name Empty
                return ContactValidationResult.InvalidName;
            }

            // Valid Name
            return ContactValidationResult.ValidName;
        }

        /// <summary>
        /// Check phone  is valid
        /// </summary>
        /// <param name="phone">phone</param>
        /// <returns>bool</returns>
        public static ContactValidationResult IsValidPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                // Phone Empty
                return ContactValidationResult.InvalidPhone;
            }

            if (long.TryParse(phone, out _))
            {
                if (phone.Length != 10)
                {
                    // Invalid Phone Number Length
                    return ContactValidationResult.InvalidPhoneLength;
                }

                // Valid Phone
                return ContactValidationResult.ValidPhone;
            }

            // Invalid Phone
            return ContactValidationResult.InvalidPhone;
        }

        /// <summary>
        /// Check email is valid
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>string</returns>
        public static ContactValidationResult IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length == 0)
            {
                // Valid Email
                return ContactValidationResult.ValidEmail;
            }

            if (email.Contains("@") && email.Contains("."))
            {
                return ContactValidationResult.ValidEmail;
            }

            return ContactValidationResult.InvalidEmail;
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

        /// <summary>
        /// Simplification method
        /// </summary>
        /// <param name="res">The result</param>
        public static void ReturnResultSimplification(ContactValidationResult res)
        {
            switch (res)
            {
                case ContactValidationResult.InvalidName:
                    Console.WriteLine("Invalid Name!!");
                    break;

                case ContactValidationResult.PhoneAlreadyExists:
                    Console.WriteLine("The Phone Number Already Exists!!");
                    break;

                case ContactValidationResult.InvalidPhoneLength:
                    Console.WriteLine("Invalid Phone Number Length (Should be 10)");
                    break;

                case ContactValidationResult.InvalidPhone:
                    Console.WriteLine("Invalid Phone Number (Can only be numbers without spaces)");
                    break;

                case ContactValidationResult.GuidNotFound:
                    Console.WriteLine("Guid Not Found!!");
                    break;

                case ContactValidationResult.InvalidGuid:
                    Console.WriteLine("Invalid index!!");
                    break;

                case ContactValidationResult.InvalidEmail:
                    Console.WriteLine("Invalid Email!!");
                    break;
                case ContactValidationResult.ListEmpty:
                    Console.WriteLine("Contacts are empty!!");
                    break;
                default:
                    Console.WriteLine("Unrecognized result: " + res);
                    break;
            }
        }
    }
}
