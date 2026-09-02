using AssignmentEight.Enum;
using AssignmentEight.Tasks;

namespace AssignmentEight
{
    /// <summary>
    /// Displays the main menu and dispatches the selected option.
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
                Console.Clear();
                ConsoleHelper.DisplayInfoMessage("\t\t\t\tMake Mistakes And Learn!!!\n");
                PrintMenu();

                if (!ConsoleHelper.TryGetEnumInput("\nEnter your choice: ", out TaskOption choice))
                {
                    ConsoleHelper.DisplayWarningMessage("Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case TaskOption.DivisionByZero:
                        DivisionByZero.Run();
                        break;
                    case TaskOption.ArrayIndexOutOfRange:
                        // Its inconsistent because in the requirement they have been asked to throw it and catch here.
                        HandleArrayIndexException();
                        break;
                    case TaskOption.CustomException:
                        Tasks.CustomException.Run();
                        break;
                    case TaskOption.GlobalUnhandledExceptionDemo:
                        GlobalUnhandledException.Run();
                        break;
                    case TaskOption.StackTraceInterpretation:
                        StackTraceInterpretation.Run();
                        break;
                    case TaskOption.Exit:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        ConsoleHelper.DisplayWarningMessage("Invalid choice. Please pick an option from the menu.");
                        break;
                }

                if (keepRunning)
                {
                    ConsoleHelper.PressKeyToContinue();
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(
                "\n==============================================" +
                "\n\tError Handling in C# " +
                "\n==============================================" +
                $"\n1. Division by zero" +
                $"\n2. Array index out of bounds" +
                $"\n3. User input validation with a custom exception" +
                $"\n4. Global unhandled exception " +
                $"\n5. Stack trace interpretation" +
                $"\n6. Exit" +
                "\n==============================================");
        }

        private static void HandleArrayIndexException()
        {
            try
            {
                ArrayIndexOutOfBounds.Run();
            }
            catch (IndexOutOfRangeException ex)
            {
                ConsoleHelper.DisplayErrorMessage($"\n\nCaught an exception: {ex.Message}");
                ConsoleHelper.DisplayShadowMessage("The exception was re-thrown from the ArrayIndexOutOfBounds task and handled in MenuHandler.");
            }
        }
    }
}
