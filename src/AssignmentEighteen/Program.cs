using AssignmentEighteen.ArrayManager;
using AssignmentEighteen.Task1;
using AssignmentEighteen.Task3;
using AssignmentEighteen.Task4;
using AssignmentEighteen.Task5;
using AssignmentEighteen.Task6;
using AssignmentEighteen.Task7;

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
            WebsiteScrapper scrapper = new WebsiteScrapper();
            await scrapper.GetContentAsync();

            ArrayManager arrayManager = new ArrayManager();
            arrayManager.SquareArray();

            ThreadImplementation threadImplementation = new ThreadImplementation();
            threadImplementation.RunThread();

            DataAnalyser dataAnalyser = new DataAnalyser();
            await dataAnalyser.AnalyseDataAsync();

            DeadlockRecoverer deadlockRecoverer = new DeadlockRecoverer();
            await deadlockRecoverer.DeadlockMethodAsync();

            ConfigureAwaitManager configureAwaitManager = new ConfigureAwaitManager();
            await configureAwaitManager.MethodBAsync();

            ExceptionHandler exceptionHandler = new ExceptionHandler();
            await exceptionHandler.HandleExceptionAsync();
        }
    }
}