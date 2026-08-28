namespace AssignmentNine.ConsolePresenter
{
    /// <summary>
    /// Manages clearing the screen.
    /// </summary>
    public static class ConsoleCleaner
    {
        /// <summary>
        /// Clears the screen.
        /// </summary>
        public static void Clean()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
