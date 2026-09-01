namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 5: Using and interpreting a locally caught exception's stack trace.
    /// Throws an exception a few call frames deep, catches it, and prints its stack trace.
    /// </summary>
    public static class StackTraceInterpretationTask
    {
        /// <summary>
        /// Runs the demo.
        /// </summary>
        public static void Run()
        {
            Helper.DisplayInfoMessage("\n--- Stack trace interpretation ---");

            try
            {
                Outer();
            }
            catch (Exception ex)
            {
                Helper.DisplayErrorMessage($"Caught exception: {ex.Message}");
                Console.WriteLine("\nStack trace:");
                Console.WriteLine(ex.StackTrace);

                Helper.DisplayInfoMessage(
                    "\nInterpretation: each line above is one call frame, listed innermost (where the " +
                    "exception was thrown) first and outermost (closer to Main) last. The 'at' lines show " +
                    "the fully qualified method name, and 'in <file>:line <n>' pins the exact source line, " +
                    "which is why Inner() -> Middle() -> Outer() -> Run() shows up in that order below.");
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
