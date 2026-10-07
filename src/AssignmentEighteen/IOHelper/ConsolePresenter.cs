namespace AssignmentEighteen.IOHelper
{
    /// <summary>
    /// Displays the messages to the user on the console.
    /// </summary>
    public static class ConsolePresenter
    {
        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">Message to be displayed to the user.</param>
        /// <param name="attemptsRemaining">No.of remaining attempts to get the input.</param>
        public static void DisplayMessage(string message, int attemptsRemaining)
        {
            Console.WriteLine(message + $"\nAttempts remaining: {attemptsRemaining}");
        }

        /// <summary>
        /// Displays the message on the new line.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
