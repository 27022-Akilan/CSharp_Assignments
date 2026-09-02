namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Represents a demonstration of handling division by zero exceptions.
    /// </summary>
    public static class DivisionByZero
    {
        /// <summary>
        /// Divides two numbers and handle exception when the division is not valid.
        /// </summary>
        public static void Run()
        {
            ConsoleHelper.DisplayInfoMessage("\n========================================" +
                                             "\n--- Division By Zero Exception --- " +
                                             "\n========================================");
            int dividend = 10;
            int divisor = 0;
            Console.WriteLine($"\nThe dividend is {dividend} and the divisor is {divisor} , " +
                              "so if the Divisor is 0 it cant be divide, so DivideByZeroException exception will be thrown");
            try
            {
                int result = dividend / divisor;
                ConsoleHelper.DisplaySuccessMessage($"Result: {dividend} / {divisor} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                ConsoleHelper.DisplayErrorMessage($"Exception: Cannot divide {dividend} by {divisor}. \nException Message : {ex.Message}");
            }
            finally
            {
                ConsoleHelper.DisplayShadowMessage("\nThe finally block for division has being executed.Bye bye buddy!!!");
            }
        }
    }
}
