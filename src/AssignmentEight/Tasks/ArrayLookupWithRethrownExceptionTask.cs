namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 2: Catching and throwing different types of exceptions.
    /// Looks up a position in an array of integers. If the position is out of range,
    /// the IndexOutOfRangeException is caught and a new IndexOutOfRangeException — same
    /// type, but with our own custom message — is thrown and caught by an outer try/catch.
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

            // Outer try/catch: handles the new exception thrown from the inner catch block.
            try
            {
                try
                {
                    Helper.DisplaySuccessMessage($"Value at index {index}: {numbers[index]}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    // Task 2, step 3: throw a new exception with a custom message.
                    // We reuse the built-in IndexOutOfRangeException type here, just with
                    // our own message and the original exception attached as InnerException.
                    throw new IndexOutOfRangeException(
                        $"Index {index} is outside the valid range of 0 to {numbers.Length - 1}.",
                        ex);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                // Task 2, step 4: catch the new exception and print its message.
                Helper.DisplayErrorMessage($"Caught IndexOutOfRangeException: {ex.Message}");
            }
        }
    }
}
