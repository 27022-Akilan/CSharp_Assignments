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
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException();
            try
            {
                Helper.DisplayInfoMessage("\t\t\t\t\t\t Make Mistakes And Learn :) ");
                ArithmeticOperations operation = new ArithmeticOperations();
                operation.Divide();
            }
            catch (Exception ex)
            {
                Helper.DisplayErrorMessage($"Error : A global exception catch is invoked!!!!!\n{ex.Message}");
            }
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