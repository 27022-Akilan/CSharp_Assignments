using AssignmentEight.CustomException;

namespace AssignmentEight.MathematicalOperations
{
    /// <summary>
    /// To perform arithmetic operations.
    /// </summary>
    public class ArithmeticOperations
    {
        /// <summary>
        /// To divide numbers.
        /// </summary>
        public void Divide()
        {
            Console.WriteLine("You had chosen divide operation!");
            Console.Write("Enter the dividend: ");
            try
            {
                int dividend = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.Write("Enter the divisor: ");
                int divisor = int.Parse(Console.ReadLine() ?? string.Empty);
                Helper.DisplaySuccessMessage($"Division Result : {dividend / divisor}");
            }

            // Task 1
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Divisor cannot be Zero, Sorry Divide Operation Failed :( \n{ex.Message}");
            }
        }

        /// <summary>
        /// To pick two position from the array and perform addition.
        /// </summary>
        public void PickAndAdd()
        {
            Console.WriteLine("Your array is");
            int[] array = { 10, 20, 30, 40, 50, 60, 70 };

            Console.WriteLine("Enter the positions of the number to be added");

            try
            {
                Console.Write("Enter the first position: ");
                int firstPosition;
                if (!int.TryParse(Console.ReadLine() ?? string.Empty, out firstPosition))
                {
                    throw new InvalidUserInputException("You should enter a whole number only!");
                }

                Console.Write("Enter the second position: ");
                int secondPosition;
                if (int.TryParse(Console.ReadLine() ?? string.Empty, out secondPosition))
                {
                    throw new InvalidUserInputException("You should enter a whole number only!");
                }

                int sum = array[firstPosition - 1] + array[secondPosition - 1];
            }

            // Task 2
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Entered position should be in between the range 0 to {array.Length}\n{ex.Message}");
            }

            // Task 3
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
