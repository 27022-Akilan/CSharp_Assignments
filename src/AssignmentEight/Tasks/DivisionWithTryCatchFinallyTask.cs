namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 1: Understanding and using try/catch/finally blocks.
    /// Divides two user-supplied numbers and handles a DivideByZeroException if one occurs.
    /// </summary>
    public static class DivisionWithTryCatchFinallyTask
    {
        /// <summary>
        /// Runs the demo.
        /// </summary>
        public static void Run()
        {
            Helper.DisplayInfoMessage("\n--- Division with try/catch/finally ---");

            if (!TryReadInt("Enter the dividend: ", out int dividend) ||
                !TryReadInt("Enter the divisor: ", out int divisor))
            {
                Helper.DisplayWarningMessage("Please enter whole numbers only. Returning to the menu.");
                return;
            }

            try
            {
                int result = dividend / divisor;
                Helper.DisplaySuccessMessage($"Result: {dividend} / {divisor} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                // Task 1, step 3: meaningful error message in the catch block.
                Helper.DisplayErrorMessage($"Error: Cannot divide {dividend} by zero. ({ex.Message})");
            }
            finally
            {
                // Task 1, step 4: statement indicating the block has executed.
                Helper.DisplayShadowMessage("The try/catch/finally block for division has finished executing.");
            }
        }

        private static bool TryReadInt(string prompt, out int value)
        {
            Console.Write(prompt);
            return int.TryParse(Console.ReadLine(), out value);
        }
    }
}
