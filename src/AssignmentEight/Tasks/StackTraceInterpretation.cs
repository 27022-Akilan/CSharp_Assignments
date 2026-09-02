namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Interpreting a locally caught exception's stack trace.
    /// </summary>
    public static class StackTraceInterpretation
    {
        /// <summary>
        ///  Creates a Exception in a called method and catches it in the caller method and interpret the stack trace.
        /// </summary>
        public static void Run()
        {
            ConsoleHelper.DisplayInfoMessage("\n==============================================" +
                                             "\n--- Stack trace interpretation ---" +
                                             "\n==============================================");

            try
            {
                ConsoleHelper.DisplayWarningMessage("\nWe have methods Run(), Outer() Middle() and Inner() defined and the exception is handled in the Run() method." +
                                            "\nWhen we call these methods in sequence, the exception will be thrown from Inner() and" +
                                             "propagated up through Middle() and Outer() to the catch block in Run()." +
                                             "\nLets now see how the stack trace looks like: ");
                Outer();
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayErrorMessage($"Caught exception: {ex.Message}");
                Console.WriteLine("\nStack trace:");
                Console.WriteLine(ex.StackTrace);
                ConsoleHelper.DisplayInfoMessage(
                   "\nInterpretation: Each line above is one call frame, listed innermost (where the " +
                   "exception was thrown) first and outermost (closer to Main) last." +
                   "\nThis is why Inner() -> Middle() -> Outer() -> Run() shows up in that order below.");
            }
        }

        private static void Outer() => Middle();

        private static void Middle() => Inner();

        private static void Inner()
        {
            throw new InvalidOperationException("Something went wrong three call frames deep.");
        }
    }
}
