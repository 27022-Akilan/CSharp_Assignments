namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Demonstration of throwing and catching Array index out of bounds exceptions.
    /// </summary>
    public static class ArrayIndexOutOfBounds
    {
        /// <summary>
        /// Runs the demo.
        /// </summary>
        public static void Run()
        {
            ConsoleHelper.DisplayInfoMessage(
                                      "\n===============================================" +
                                      "\n--- Array Index Out Of Bounds Exception --- " +
                                      "\n===============================================");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine($"\nArray: [{string.Join(", ", numbers)}]");
            int index = -1;
            Console.WriteLine($"\nThe index {index} is chose for simulating the IndexOutOfBounds exception because " +
                              $"the array's starting index is 0.");
            try
            {
                ConsoleHelper.DisplaySuccessMessage($"\nValue at index {index}: {numbers[index]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                // Task 2 - Throwing a new exception with a custom message and the original exception as the inner exception.
                throw new IndexOutOfRangeException(
                    $" Index {index} is outside the valid range of 0 to {numbers.Length - 1}.", ex);
            }
        }
    }
}
