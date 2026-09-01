namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Task 4: Handling global unhandled exceptions.
    /// Calls a method that throws an exception with no local try/catch, so it becomes
    /// truly unhandled and is instead observed by the AppDomain.UnhandledException
    /// handler that Program.cs registers at startup.
    /// </summary>
    public static class GlobalUnhandledExceptionTask
    {
        /// <summary>
        /// Runs the demo. Note: because the exception thrown here is never caught locally,
        /// the .NET runtime will terminate the process immediately after the global handler
        /// runs. This is expected .NET behavior, not a bug: the global handler exists to let
        /// you log/observe a crash, not to keep the application alive.
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

            // Deliberately unhandled: no try/catch here, so this bubbles all the way up
            // and is only observed by the global AppDomain.UnhandledException handler.
            Console.WriteLine($"Accessing an out-of-range index on purpose: {numbers[10]}");
        }
    }
}
