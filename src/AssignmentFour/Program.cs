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
            IRepository repository = new TransactionRepository();
            TransactionService service = new TransactionService(repository);
            InputView inputView = new InputView(service);
            TransactionView view = new TransactionView(service, inputView);

            view.StartApplication();
        }
    }
}