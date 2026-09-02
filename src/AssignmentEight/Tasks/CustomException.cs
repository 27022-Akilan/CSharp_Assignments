using AssignmentEight.CustomException;

namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 3: Defining and using custom exception classes.
    /// </summary>
    public static class CustomException
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;

        /// <summary>
        ///  Creates a custom exception called InvalidUserInputException and catches it.
        /// </summary>
        public static void Run()
        {
            ConsoleHelper.DisplayInfoMessage("\n===========================================================" +
                                      "\n--- User input validation with a custom exception ---" +
                                      "\n===========================================================");
            Console.Write($"\n\nEnter a whole number between {MinValue} and {MaxValue}: ");
            string? input = Console.ReadLine();

            try
            {
                if (!int.TryParse(input, out int value) || value < MinValue || value > MaxValue)
                {
                    throw new InvalidUserInputException(
                        $"'{input}' is not a valid whole number between {MinValue} and {MaxValue}.");
                }

                ConsoleHelper.DisplaySuccessMessage($"Thanks! You entered a valid number: {value}");
            }
            catch (InvalidUserInputException ex)
            {
                ConsoleHelper.DisplayErrorMessage($"Caught InvalidUserInputException: {ex.Message}");
            }
        }
    }
}
