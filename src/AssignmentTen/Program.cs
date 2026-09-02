using AssignmentTen;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts up the application.
        /// </summary>
        /// <param name="args">Default argument</param>
        public static void Main(string[] args)
        {
            MathUtils operation = new MathUtils();

            Console.WriteLine("Performs operation on two numbers");

            int number1, number2;
            if (!TryGetNumber("Enter the first number : ", out number1)
                || !TryGetNumber("Enter the Second number : ", out number2))
            {
                return;
            }

            try
            {
                Console.WriteLine($"\nAddition : {operation.Add(number1, number2)}" +
                             $"\nSubtraction : {operation.Subtract(number1, number2)}" +
                             $"\nMultiplication : {operation.Multiply(number1, number2)}" +
                             $"\nDivision : {operation.Divide(number1, number2)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"An Exception Caught : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Exiting the Application!!!");
            }
        }

        /// <summary>
        /// Gets a valid integer.
        /// </summary>
        /// <param name="prompt">Message to be displayed</param>
        /// <param name="result">Valid integer</param>
        /// <returns>True - Got valid input otherwise false</returns>
        public static bool TryGetNumber(string prompt, out int result)
        {
            Console.Write($"\n{prompt}");
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid Input");
                return false;
            }

            return true;
        }
    }
}
