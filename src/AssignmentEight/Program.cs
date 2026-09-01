using AssignmentEight;
using AssignmentEight.MathematicalOperations;
using AssignmentEight.Menu;

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
            ArithmeticOperations operation = new ArithmeticOperations();
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

            MenuHandler.Run();
        }

        /// <summary>
        /// Triggered when there is a Unhandled exception.
        /// </summary>
        /// <param name="sender">Who sends this Exception.</param>
        /// <param name="e">Event data - Information about the event occurred.</param>
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception? exception = e.ExceptionObject as Exception;
            Helper.DisplayErrorMessage("Error : Unhandled Exception caught globally by AppDomain.UnhandledException." +
                                        $"\nMessage : {exception?.Message}" +
                                        $"If it will terminate the entire process {e.IsTerminating}");
        }
    }
}