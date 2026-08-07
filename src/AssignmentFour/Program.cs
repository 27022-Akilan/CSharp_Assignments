using AssignmentFour.Repository;

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

        }
    }
}