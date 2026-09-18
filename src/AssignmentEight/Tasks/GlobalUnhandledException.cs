using System.Text.Json;
using AssignmentEight.Enums;

namespace AssignmentEight.Tasks
{
    /// <summary>
    /// Demonstration of handling global unhandled exceptions.
    /// </summary>
    public static class GlobalUnhandledException
    {
        /// <summary>
        /// Throws an unhandled exception to demonstrate the global exception handling mechanism.
        /// </summary>
        public static void Run()
        {
            ConsoleHelper.DisplayMessage(
                                             "\n==============================================" +
                                             "\n--- Global Unhandled Exception ---" +
                                             "\n==============================================",
                                             MessageType.Info);
            ConsoleHelper.DisplayMessage(
                                         "\nIntentionally a Json Exception was thrown to simulate the Unhandled global exception" +
                                         "\nThis is a scenario where the exception is not handled locally." +
                                         "\nThe AppDomain.UnhandledException " +
                                         "handler registered in Program.cs will catch it globally, print a message, and then the " +
                                         "process will exit (this is normal .NET behavior for unhandled exceptions).",
                                         MessageType.Warning);

            ConsoleHelper.PressKeyToContinue();
            ThrowUnhandledException();
        }

        private static void ThrowUnhandledException()
        {
            throw new JsonException();
        }
    }
}
