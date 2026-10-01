using AssignmentEighteen.Task4;

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
            //WebsiteScrapper scrapper = new WebsiteScrapper();
            //await scrapper.GetContent();

            //ArrayManager arrayManager = new ArrayManager();
            //arrayManager.SquareArray();

            //ThreadImplementation threadImplementation = new ThreadImplementation();
            //threadImplementation.RunThread();

            DataAnalyser dataAnalyser = new DataAnalyser();
            await dataAnalyser.AnalyseData();
        }
    }
}