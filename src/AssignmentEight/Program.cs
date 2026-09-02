using AssignmentEight;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Starts the application execution.
        /// </summary>
        public static void Main()
        {
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
            ConsoleHelper.DisplayErrorMessage("Error : Unhandled Exception caught globally by AppDomain.UnhandledException." +
                                        $"\nMessage : {exception?.Message}" +
                                        $"\nIf it will terminate the entire process : {e.IsTerminating}");
        }
    }
}
