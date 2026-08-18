using AssignmentEight;
using AssignmentEight.MathematicalOperations;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Start of the application execution.
        /// </summary>
        public static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            Helper.DisplayInfoMessage("\t\t\t\t\t\t Make Mistakes And Learn :) ");
            ArithmeticOperations operation = new ArithmeticOperations();
            operation.Divide();

            try
            {
                Console.WriteLine("\n\nEntered into Pick And Add method");
                operation.PickAndAdd();
            }
            catch (Exception ex)
            {
                Helper.DisplayErrorMessage($"\nError : A global exception catch caught this exception\n{ex.Message}" +
                    $"\nThis is for Programmer use only!!!" +
                    $"\n{ex.StackTrace}");
            }

            // Console.WriteLine("\nApplication Continues.........................");
        }

        /// <summary>
        /// Triggered when there is a Unhandled exception.
        /// </summary>
        /// <param name="sender">Who sends this Exception.</param>
        /// <param name="e">Event data - Information about the event occurred.</param>
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Helper.DisplayErrorMessage("Error : Unhandled Exception caught and triggered using AppDomain");
        }
    }
}