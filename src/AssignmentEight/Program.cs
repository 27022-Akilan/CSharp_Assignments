using AssignmentEight;
using AssignmentEight.MathematicalOperations;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Start of the application execution.
        /// </summary>
        public static void Main()
        {
            Helper.DisplayInfoMessage("\t\t\t\t\t\t Make Mistakes and Learn :) ");
            ArithmeticOperations operation = new ArithmeticOperations();
            operation.Divide();
        }
    }
}