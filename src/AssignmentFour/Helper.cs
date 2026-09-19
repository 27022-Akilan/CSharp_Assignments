namespace AssignmentFour
{
    /// <summary>
    /// A helper class that have the general methods
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Waits until user enters a key and then exists
        /// </summary>
        public static void PressKeyToContinue()
        {
            DisplayShadowMessage("Press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a success message in green.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplaySuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an error message in red.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a warning message in yellow.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an informational message in cyan.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Display the Messages like a shadow in light color
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayShadowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a message indicating that the program is aborting due to maximum invalid tries attempted.
        /// </summary>
        public static void DisplayAbortMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aborting due to Maximum Invalid Tries Attempted");
            Console.ResetColor();
        }
    }
}
