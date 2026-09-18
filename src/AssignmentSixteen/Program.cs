using AssignmentSixteen;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += DisplayMessage;
            notifier.SendNotification();

            ArrayOperator arrayOperator = new ArrayOperator();
            arrayOperator.PerformOperations(new int[] { 6, 5, 4, 3, 2, 1 });

            ListOperator listOperator = new ListOperator();
            listOperator.FilterAndSquareEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6 });
        }

        /// <summary>
        /// Displays the message to the user.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}