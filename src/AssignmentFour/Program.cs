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
        /// Entry point for the Application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            string filePath = @"Transactions.json";
            IRepository repository = new TransactionRepository();
            IRepository fileRepository = new FileRepository(filePath);
            TransactionService service = new TransactionService(fileRepository);
            InputView inputView = new InputView(service);
            TransactionView transactionView = new TransactionView(service, inputView);

            transactionView.StartApplication();
        }
    }
}
