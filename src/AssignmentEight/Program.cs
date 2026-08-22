using AssignmentEight;
using AssignmentEight.Enum;
using AssignmentEight.MathematicalOperations;

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

            Helper.DisplayInfoMessage("\t\t\t\t\t\t Make Mistakes And Learn :) ");
            Console.WriteLine("Heh Dude lets start learning" +
                              "\n==============================================" +
                              "\n1.Divide operation" +
                              "\n2.Add from the given numbers" +
                              "\n3.Exit" +
                              "\n==============================================" +
                              "\nEnter your choice : ");

            string userChoice = (Console.ReadLine() ?? string.Empty).Trim();

            if (int.TryParse(userChoice, out int choice))
            {
                MenuOption option = (MenuOption)choice;

                switch (option)
                {
                    case MenuOption.Divide:
                        operation.Divide();
                        break;
                    case MenuOption.PickAndAdd:
                        try
                        {
                            Console.WriteLine("\n\nEntered into Pick And Add method");
                            operation.PickAndAdd();
                        }
                        catch (Exception ex)
                        {
                            Helper.DisplayErrorMessage($"\nError : A global exception catch caught this exception\n{ex.Message}" +
                                $"\nThis is for Programmer use only!!!" +
                                $"\n{ex.StackTrace}");
                        }

                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting the Application!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Exiting!!!!");
                        break;
                }
            }
        }

        /// <summary>
        /// Triggered when there is a Unhandled exception.
        /// </summary>
        /// <param name="sender">Who sends this Exception.</param>
        /// <param name="e">Event data - Information about the event occurred.</param>
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Helper.DisplayErrorMessage("Error : Unhandled Exception caught and triggered using AppDomain");
        }
    }
}