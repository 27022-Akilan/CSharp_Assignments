namespace AssignmentSixteen.Helper
{
    /// <summary>
    /// Represents the Console helper operations.
    /// </summary>
    public class ConsoleHelper
    {
        /// <summary>
        /// Waits till the user to press key and clears the screen.
        /// </summary>
        public static void WaitAndClear()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress Any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
