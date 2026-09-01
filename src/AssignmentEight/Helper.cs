namespace AssignmentEight
{
    /// <summary>
    /// General-purpose console helper methods shared across all task demos.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Waits until the user presses a key.
        /// </summary>
        public static void PressKeyToContinue()
        {
            DisplayShadowMessage("\nPress any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a success message in green.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplaySuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an error message in red.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a warning message in yellow.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an informational message in cyan.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a message in a dim gray, used for explanatory / "shadow" text.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayShadowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the given prompt, reads a numeric value from the console, and converts into enum.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to convert the user input into.</typeparam>
        /// <param name="prompt">The message to display before reading input.</param>
        /// <param name="result">The resulting enum value if the input was a valid integer; otherwise, the default value.</param>
        /// <returns><see langword="true"/> if the input was a valid integer; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnumInput<TEnum>(string prompt, out TEnum result)
            where TEnum : struct, System.Enum
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            if (int.TryParse(input, out int numericValue))
            {
                result = (TEnum)(object)numericValue;
                return true;
            }

            result = default;
            return false;
        }
    }
}