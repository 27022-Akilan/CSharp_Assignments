namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 4: Handling global unhandled exceptions.
    /// </summary>
    public static class GlobalUnhandledExceptionTask
    {
        /// <summary>
        /// Runs the demo. Note: because the exception thrown here is never caught locally,
        /// </summary>
        public static void Run()
        {
            Helper.DisplayInfoMessage("\n--- Global unhandled exception demo ---");
            Helper.DisplayWarningMessage(
                "This will throw an exception with no local try/catch. The AppDomain.UnhandledException " +
                "handler registered in Program.cs will catch it globally, print a message, and then the " +
                "process will exit (this is normal .NET behavior for unhandled exceptions).");

            Helper.PressKeyToContinue();

            MethodThatThrowsUnhandled();
        }

        private static void MethodThatThrowsUnhandled()
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine($"Accessing an out-of-range index on purpose: {numbers[10]}");
        }
    }
}
