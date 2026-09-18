namespace AssignmentSixteen
{
    /// <summary>
    /// Represents the notification operations.
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Delegate representing to notify.
        /// </summary>
        /// <param name="message">Message of the notification.</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Event that represents the delegate notify.
        /// </summary>
        public event Notify? OnAction;

        /// <summary>
        /// Sends notification to all the subscribed methods.
        /// </summary>
        public void SendNotification()
        {
            this.OnAction?.Invoke("Notification arrived !!");
        }
    }
}
