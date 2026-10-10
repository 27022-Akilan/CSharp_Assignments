namespace AssignmentSeventeen.IOHelper
{
    /// <summary>
    /// Generic console-input loop. Takes ONE function per field
    /// (from Validator) that both parses and validates, and retries
    /// up to 3 times before giving up.
    /// </summary>
    internal static class InputReader
    {
        private const int MaxAttempts = 3;

        /// <summary>
        /// Gets the input with 3 tries.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="validator">Validator function.</param>
        /// <param name="result">Validated input.</param>
        /// <returns>True - If valid input otherwise false.</returns>
        public static bool GetInput<T>(
            string message,
            Func<string, (bool IsSuccess, T Value, string Message)> validator,
            out T result)
        {
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.Write(message);
                string userInput = Console.ReadLine() ?? string.Empty;

                var (isSuccess, value, validationMessage) = validator(userInput);
                if (!isSuccess)
                {
                    DisplayMessage(validationMessage, MaxAttempts - attempt);
                    continue;
                }

                result = value;
                return true;
            }

            result = default!;
            DisplayMessage("Your attempts are completed, returning to main menu", 0);
            return false;
        }

        private static void DisplayMessage(string message, int attemptsRemaining)
        {
            Console.WriteLine(message + $"\nAttempts remaining: {attemptsRemaining}");
        }
    }
}
