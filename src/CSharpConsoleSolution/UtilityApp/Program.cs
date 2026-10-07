using UtilityApp;

namespace Assignments
{
    /// <summary>
    /// Entry point of the utility application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the utility method.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Utility ===");
            string formattedMessage = MessageFormatter.FormatMessage("Hii Akilan");
            Console.WriteLine($"The formatted message is : {formattedMessage}");
        }
    }
}