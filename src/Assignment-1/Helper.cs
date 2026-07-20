using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// hjjh
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// input
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
                return "IN";
            }

            return "VN";
        }

        /// <summary>
        /// Check phone  is valid
        /// </summary>
        /// <param name="phone">ph</param>
        /// <returns>bool</returns>
        public static string IsValidPhone(string? phone)
        {
            if (long.TryParse(phone, out _))
            {
                if (phone.Length != 10)
                {
                    // Invalid Phone Number Length
                    return "IPL";
                }

                return "VP";
            }

            if (phone == null)
            {
                phone = string.Empty;
            }

            return "IP";
        }

        /// <summary>
        /// check eamil is valid
        /// </summary>
        /// <param name="email">em</param>
        /// <returns>string</returns>
        public static string IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "VE";
            }

            if (email.Length == 0 || email.Contains('@'))
            {
                return "VE";
            }

            return "IE";
        }

        /// <summary>
        /// Validating Gui Id
        /// </summary>
        /// <param name="gId">inpt</param>
        /// <param name="id">out</param>
        /// <returns>bool</returns>
        public static bool IsValidGId(string? gId, out Guid id)
        {
            return Guid.TryParse(gId, out id);
        }

        /// <summary>
        /// Checking isnull
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
