using AssignmentEight.Enum;
using AssignmentEight.Tasks;

namespace AssignmentEight.Menu
{
    /// <summary>
    /// Displays the main menu and dispatches the selected <see cref="TaskOption"/>
    /// to the matching demo.
    /// </summary>
    public static class MenuHandler
    {
        /// <summary>
        /// Runs the menu loop until the user chooses to exit.
        /// </summary>
        public static void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                PrintMenu();

                if (!Helper.TryGetEnumInput("\nEnter your choice: ", out TaskOption choice))
                {
                    Helper.DisplayWarningMessage("Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case TaskOption.DivisionWithTryCatchFinally:
                        DivisionWithTryCatchFinallyTask.Run();
                        break;
                    case TaskOption.ArrayLookupWithRethrownException:
                        ArrayLookupWithRethrownExceptionTask.Run();
                        break;
                    case TaskOption.UserInputValidationWithCustomException:
                        UserInputValidationWithCustomExceptionTask.Run();
                        break;
                    case TaskOption.GlobalUnhandledExceptionDemo:
                        GlobalUnhandledExceptionTask.Run();
                        break;
                    case TaskOption.StackTraceInterpretation:
                        StackTraceInterpretationTask.Run();
                        break;
                    case TaskOption.Exit:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Helper.DisplayWarningMessage("Invalid choice. Please pick an option from the menu.");
                        break;
                }

                if (keepRunning)
                {
                    Helper.PressKeyToContinue();
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(
                "\n==============================================" +
                "\n Error Handling in C# - Demo Menu" +
                "\n==============================================" +
                $"\n{(int)TaskOption.DivisionWithTryCatchFinally}. Division with try/catch/finally" +
                $"\n{(int)TaskOption.ArrayLookupWithRethrownException}. Array lookup with a re-thrown exception" +
                $"\n{(int)TaskOption.UserInputValidationWithCustomException}. User input validation with a custom exception" +
                $"\n{(int)TaskOption.GlobalUnhandledExceptionDemo}. Global unhandled exception demo" +
                $"\n{(int)TaskOption.StackTraceInterpretation}. Stack trace interpretation" +
                $"\n{(int)TaskOption.Exit}. Exit" +
                "\n==============================================");
        }
    }
}
