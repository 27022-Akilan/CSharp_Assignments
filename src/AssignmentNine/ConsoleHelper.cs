namespace AssignmentNine
{
    /// <summary>
    /// Represents the helper methods for getting input and showing output.
    /// </summary>
    public class ConsoleHelper
    {
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
