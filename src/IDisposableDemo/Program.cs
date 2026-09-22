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
            string filePath = "Demo.txt";
            using (var fileWriter = new FileWriter(filePath))
            {
                fileWriter.Write("Hii buddy, Happy coding");
            }

            // Test whether the file can be opened again as the previous one releases the handle.
            using (var fileReader = new FileReader(filePath))
            {
                fileReader.Read();
            }
        }
    }
}