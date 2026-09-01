using AssignmentEight.CustomException;

namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 3: Defining and using custom exception classes.
    /// </summary>
    public static class UserInputValidationWithCustomExceptionTask
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;

        /// <summary>
        /// Runs the demo.
        /// </summary>
        public static void Run()
        {
            Helper.DisplayInfoMessage("\n--- User input validation with a custom exception ---");
            Console.Write($"Enter a whole number between {MinValue} and {MaxValue}: ");
            string? input = Console.ReadLine();

            try
            {
                if (!int.TryParse(input, out int value) || value < MinValue || value > MaxValue)
                {
                    throw new InvalidUserInputException(
                        $"'{input}' is not a valid whole number between {MinValue} and {MaxValue}.");
                }

                Helper.DisplaySuccessMessage($"Thanks! You entered a valid number: {value}");
            }
            catch (InvalidUserInputException ex)
            {
                Helper.DisplayErrorMessage($"Caught InvalidUserInputException: {ex.Message}");
            }
        }
    }
}
