using AssignmentFour;
using AssignmentFour.Repository;
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
            try
            {
                // IRepository repository = new TransactionRepository();
                IRepository fileRepository = new FileRepository(FilePath);
                TransactionService service = new TransactionService(fileRepository);
                InputReader inputView = new InputReader(service);
                TransactionView transactionView = new TransactionView(service, inputView);

                transactionView.StartApplication();
            }
            catch (UnauthorizedAccessException ex)
            {
                Helper.DisplayErrorMessage($"\nError: The application does not have permission to access the file.\n{ex.Message}");
            }
            catch (System.IO.IOException ex)
            {
                Helper.DisplayErrorMessage($"Error accessing the repository file: {ex.Message}");
            }
            catch (System.Text.Json.JsonException ex)
            {
                Helper.DisplayErrorMessage($"Error: The existing file {FilePath} is corrupted or not properly formatted.\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Helper.DisplayErrorMessage($"Error : Unexpected Error , Please try after some time,\n{ex.Message}");
            }
        }
    }
}
