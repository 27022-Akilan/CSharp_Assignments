using AssignmentEighteen;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        /// <returns>Task</returns>
        public static async Task Main(string[] args)
        {
            TaskNavigator taskNavigator = new TaskNavigator();
            await taskNavigator.NavigateMenu();
        }
    }
}