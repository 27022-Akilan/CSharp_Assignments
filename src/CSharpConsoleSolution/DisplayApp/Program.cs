namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Display App depends on the utility app hence utility app is loaded first before the Display app");
            Console.WriteLine("=== Display App ===");
            Console.WriteLine("This is just for displaying messages..");
        }
    }
}