using AssignmentTwelve;

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
            MemoryEater memoryEater = new MemoryEater();
            memoryEater.OptimizeMemoryMethod1();
            memoryEater.OptimizeMemoryMethod2();
        }
    }
}