using AssignmentSixteen.Task1;
using AssignmentSixteen.Task3;
using AssignmentSixteen.Task4;
using AssignmentSixteen.Task5;
using AssignmentSixteen.Task6;
using AssignmentSixteen.Task7;

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
        public static void Main(string[] args)
        {
            NotificationService notificationService = new NotificationService();
            notificationService.PerformEventsTask();

            ArrayManager arrayOperator = new ArrayManager();
            arrayOperator.PerformOperations(new int[] { 6, 5, 4, 3, 2, 1 });

            ListManager listOperator = new ListManager();
            listOperator.FilterAndSquareEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6 });

            ProductManager productManager = new ProductManager();
            productManager.PerformDelegateOperation();

            RecordManager recordManager = new RecordManager();
            recordManager.ManipulateRecords();

            ShapeManager shapeManager = new ShapeManager();
            shapeManager.ManageShape();
        }
    }
}
