using AssignmentEighteen.IOHelper;

namespace AssignmentEighteen.InputHelper
{
    /// <summary>
    /// Generic console-input loop. Takes ONE function per field
    /// (from Validator) that both parses and validates, and retries
    /// up to 3 times before giving up.
    /// </summary>
    public static class InputReader
    {
        private const int MaxAttempts = 3;

        /// <summary>
        /// Gets the input from the user and allows 3 tries.
        /// </summary>
        /// <typeparam name="T">Generic input type</typeparam>
        /// <param name="message">Message to be displayed to the user</param>
        /// <param name="validate">Validator function</param>
        /// <param name="result">validated result.</param>
        /// <returns>True - Valid | False - Input invalid</returns>
        public static bool GetInput<T>(
            string message,
            Func<string, (bool IsSuccess, T Value, string Message)> validate,
            out T result)
        {
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                ConsolePresenter.DisplayMessage(message);
                string userInput = Console.ReadLine() ?? string.Empty;

                var (isSuccess, value, resultMessage) = validate(userInput);
                if (!isSuccess)
                {
                    ConsolePresenter.DisplayMessage(resultMessage, MaxAttempts - attempt);
                    continue;
                }

                result = value;
                return true;
            }

            result = default!;
            ConsolePresenter.DisplayMessage("Your attempts are completed, returning to main menu", 0);
            return false;
        }
    }
}
