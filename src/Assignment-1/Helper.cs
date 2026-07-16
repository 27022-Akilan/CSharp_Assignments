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
        /// Check option
        /// </summary>
        /// <param name="userChoice">user ch</param>
        /// <param name="number">number convversion</param>
        /// <returns>bool</returns>
        public static bool IsValidChoice(string userChoice, out int number)
        {
            if (int.TryParse(userChoice, out number))
            {
                return true;
            }
            else
            {
                // Console.WriteLine("Invalid Number");
                return false;
            }
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
        /// Check Phone num is valid
        /// </summary>
        /// <param name="phone">Phone</param>
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
        /// Check if eamil is valid
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
        /// hcgxh
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
        /// <param name="email">eamil</param>
        /// <param name="notes">notes</param>
        /// <returns>bool</returns>
        public static bool IsNotNull(string? name, string? phone, string? email, string? notes)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(notes))
            {
                return false;
            }

            return true;
        }
    }
}
