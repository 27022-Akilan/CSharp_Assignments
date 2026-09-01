namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 2: Catching and throwing different types of exceptions.
    /// </summary>
    public static class ArrayLookupWithRethrownExceptionTask
    {
        /// <summary>
        /// Runs the demo.
        /// </summary>
        public static void Run()
        {
            Helper.DisplayInfoMessage("\n--- Array lookup with a re-thrown exception ---");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");
            Console.Write($"Enter an index to read (valid range 0-{numbers.Length - 1}): ");

            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Helper.DisplayWarningMessage("Please enter a whole number. Returning to the menu.");
                return;
            }

            try
            {
                try
                {
                    Helper.DisplaySuccessMessage($"Value at index {index}: {numbers[index]}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    // Task 2
                    throw new IndexOutOfRangeException(
                        $"Index {index} is outside the valid range of 0 to {numbers.Length - 1}.",
                        ex);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                // Task 2
                Helper.DisplayErrorMessage($"Caught IndexOutOfRangeException: {ex.Message}");
            }
        }
    }
}
