using AssignmentTwo.View;

namespace Assignments
{
    /// <summary>
    /// THis is the basse prgrm entry point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// THis is the entry point
        /// </summary>
        /// <param name="args">Default args</param>
        public static void Main(string[] args)
        {
            // ViewShape viewShape = new ViewShape();

            // viewShape.Menu();
            ViewEmployee viewEmployee = new ViewEmployee();
            viewEmployee.Menu();
        }
    }
}