using AssignmentEight.Enums;

namespace AssignmentEight
{
    /// <summary>
    /// General-purpose console ConsoleHelper methods shared across all task demos.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Waits until the user presses a key.
        /// </summary>
        public static void PressKeyToContinue()
        {
            DisplayMessage("\nPress any key to continue...", MessageType.Shadow);
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the message in different color for different type of the message.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="type">Type of the message</param>
        public static void DisplayMessage(string message, MessageType type)
        {
            Console.ForegroundColor = type switch
            {
                MessageType.Success => ConsoleColor.Green,
                MessageType.Warning => ConsoleColor.Yellow,
                MessageType.Error => ConsoleColor.Red,
                MessageType.Info => ConsoleColor.Blue,
                MessageType.Shadow => ConsoleColor.DarkGray,
                _ => ConsoleColor.White
            };
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the given prompt, reads a numeric value from the console, and converts into enum.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to convert the user input into.</typeparam>
        /// <param name="prompt">The message to display before reading input.</param>
        /// <param name="result">The resulting enum value if the input was a valid integer; otherwise, the default value.</param>
        /// <returns>True if the input was a valid integer mapped to the enum; otherwise false</returns>
        public static bool TryGetEnumInput<TEnum>(string prompt, out TEnum result)
            where TEnum : struct, System.Enum
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            result = default;
            if (!int.TryParse(input, out int numericValue))
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(TEnum), numericValue))
            {
                return false;
            }

            result = (TEnum)(object)numericValue;
            return true;
        }
    }
}
