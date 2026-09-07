using AssignmentFour;
using AssignmentFour.Repository;
using AssignmentFour.Repository.Log;
using AssignmentFour.Service;
using AssignmentFour.View;

namespace Assignments
{
    /// <summary>
    /// To start the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Path of the file to store the transactions.
        /// </summary>
        public const string FilePath = @"Transactions.json";

        /// <summary>
        /// Entry point for the Application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            ILogger logger = FileLogger.GetInstance();
            try
            {
                IRepository inMemoryRepository = new TransactionRepository();
                IRepository fileRepository = new FileRepository(FilePath);
                TransactionService service = new TransactionService(fileRepository, logger);
                InputView inputView = new InputView(service);
                TransactionView transactionView = new TransactionView(service, inputView);

                transactionView.StartApplication();
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError($"{ex.Message}");
                Helper.DisplayErrorMessage($"\nError: The application does not have permission to access the file.\n{ex.Message}");
            }
            catch (System.IO.IOException ex)
            {
                logger.LogError($"{ex.Message}");
                Helper.DisplayErrorMessage($"Error accessing the repository file: {ex.Message}");
            }
            catch (System.Text.Json.JsonException ex)
            {
                logger.LogError($"{ex.Message}");
                Helper.DisplayErrorMessage($"Error: The existing file {FilePath} is corrupted or not properly formatted.\n{ex.Message}");
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message}");
                Helper.DisplayErrorMessage($"Error : Unexpected Error , Please try after some time,\n{ex.Message}");
            }
        }
    }
}
