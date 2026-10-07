namespace Assignments
{
    /// <summary>
    /// Entry point of the report app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("This is only build after when the Display app gets build as Report app depends on Display app.");
            Console.WriteLine("=== Report App ===");
            Console.WriteLine("\nThis solution contains :" +
                              "\n2.Greetings App" +
                              "\n3.Math App" +
                              "\n4.Display App" +
                              "\n5.Utility App" +
                              "\n6.Report App");
        }
    }
}