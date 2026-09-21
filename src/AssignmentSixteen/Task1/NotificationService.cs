using AssignmentSixteen.Helper;

namespace AssignmentSixteen.Task1
{
    /// <summary>
    /// Represents the notification service.
    /// </summary>
    public class NotificationService
    {
        /// <summary>
        /// Subscribe and unsubscribe events.
        /// </summary>
        public void PerformEventsTask()
        {
            Console.WriteLine("=====Task 1=====");
            Notifier notifier = new Notifier();
            notifier.OnAction += this.DisplayMessage;
            notifier.SendNotification();
            ConsoleHelper.WaitAndClear();
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
