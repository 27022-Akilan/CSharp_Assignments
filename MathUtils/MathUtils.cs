namespace Utilities
{
    /// <summary>
    /// Represents the 
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="number1">First number to add</param>
        /// <param name="number2">Second number to add</param>
        /// <returns>Addition of two numbers</returns>
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Number to be subtracted from first number</param>
        /// <returns>Subtraction of (number1-number2)</returns>
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="number1">First number to be multiplied</param>
        /// <param name="number2">Second number to be multiplied</param>
        /// <returns>Multiplication of two numbers</returns>
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="dividend">Dividend</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Division of two numbers</returns>
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("The divisor can't be 0");
            }

            return dividend / divisor;
        }
    }
}
