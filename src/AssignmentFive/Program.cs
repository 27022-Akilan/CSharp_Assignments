using AssignmentFive.Repository;
using AssignmentFive.Service;
using AssignmentFive.View;

namespace AssignmentFive
{
    /// <summary>
    /// To start the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Contains the file path
        /// </summary>
        public const string FilePath = @"C:\C#\Assignment5.json";

        /// <summary>
        /// Entry point for the Application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                IRepository inMemoryRepository = new TransactionRepository();
                IRepository fileRepository = new FileRepository(FilePath);
                TransactionService service = new TransactionService(fileRepository);
                InputView inputView = new InputView(service);
                TransactionView view = new TransactionView(service, inputView);

                view.StartApplication();
            }
            catch (UnauthorizedAccessException)
            {
                Helper.DisplayErrorMessage("Error: The application does not have permission to access the file.");
            }
            catch (System.IO.IOException ex)
            {
                Helper.DisplayErrorMessage($"Error accessing the repository file: {ex.Message}");
            }
            catch (System.Text.Json.JsonException ex)
            {
                Helper.DisplayErrorMessage($"Error: The existing file {FilePath} is corrupted or not properly formatted.\n{ex.Message}");
            }
            catch (Exception)
            {
                Helper.DisplayErrorMessage("Error : Unexpected Error , Please try after some time");
            }
        }
    }
}
