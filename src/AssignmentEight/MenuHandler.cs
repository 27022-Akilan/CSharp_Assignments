using AssignmentEight.Enums;
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
                ConsoleHelper.DisplayMessage("\t\t\t\tMake Mistakes And Learn :)\n", MessageType.Info);
                PrintMenu();

                if (!ConsoleHelper.TryGetEnumInput("\nEnter your choice: ", out TaskOption choice))
                {
                    ConsoleHelper.DisplayMessage("Please enter a number.", MessageType.Warning);
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
                    case TaskOption.GlobalUnhandledException:
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
                        ConsoleHelper.DisplayMessage("Invalid choice. Please pick an option from the menu.", MessageType.Warning);
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
                ConsoleHelper.DisplayMessage($"\n\nCaught an exception: {ex.Message}", MessageType.Error);
                ConsoleHelper.DisplayMessage(
                                              "The exception was re-thrown from the ArrayIndexOutOfBounds task and handled in MenuHandler.",
                                              MessageType.Shadow);
            }
        }
    }
}
