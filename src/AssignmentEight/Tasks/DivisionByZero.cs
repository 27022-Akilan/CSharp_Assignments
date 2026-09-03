using AssignmentEight.Enums;

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
            ConsoleHelper.DisplayMessage(
                                        "\n========================================" +
                                        "\n--- Division By Zero Exception --- " +
                                        "\n========================================",
                                        MessageType.Info);
            int dividend = 10;
            int divisor = 0;
            Console.WriteLine($"\nThe dividend is {dividend} and the divisor is {divisor} , " +
                              "so if the Divisor is 0 it cant be divide, so DivideByZeroException exception will be thrown");
            try
            {
                int result = dividend / divisor;
                ConsoleHelper.DisplayMessage($"Result: {dividend} / {divisor} = {result}", MessageType.Success);
            }
            catch (DivideByZeroException ex)
            {
                ConsoleHelper.DisplayMessage($"Exception: Cannot divide {dividend} by {divisor}. \nException Message : {ex.Message}", MessageType.Error);
            }
            finally
            {
                ConsoleHelper.DisplayMessage("\nThe finally block for division has being executed.Bye bye buddy!!!", MessageType.Shadow);
            }
        }
    }
}
