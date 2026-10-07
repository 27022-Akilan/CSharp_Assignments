using MathApp;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Math app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the Math app.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Math app depends on the Display app hence Display app is build before this math app");
            Console.WriteLine("=== Math App ===");
            Calculator calculator = new Calculator();
            int result = calculator.Add(10, 8);
            Console.WriteLine($"Addition result is : {result}");
        }
    }
}