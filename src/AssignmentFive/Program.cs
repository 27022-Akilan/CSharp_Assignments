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
        /// Entry point for the Application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            IRepository inMemoryRepository = new TransactionRepository();
            IRepository fileRepository = new FileRepository("Desktop\file1.txt");
            TransactionService service = new TransactionService(fileRepository);
            InputView inputView = new InputView(service);
            TransactionView view = new TransactionView(service, inputView);

            view.StartApplication();
        }
    }
}