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