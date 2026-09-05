using IDisposableDemo;

namespace Assignments
{
    /// <summary>
    /// Starting point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            using (var fileWriter = new FileOperator("Demo.txt"))
            {
                fileWriter.Write("Hii buddy, Happy coding");
            }
        }
    }
}