using AssignmentEighteen.IOHelper;

namespace AssignmentEighteen.Task6
{
    /// <summary>
    /// Represents the functions to manage the configure await.
    /// </summary>
    public class ConfigureAwaitManager
    {
        /// <summary>
        /// Represents the method that waits for the result from the other method secs.
        /// </summary>
        /// <returns>Task object.</returns>
        public async Task MethodBAsync()
        {
            ConsolePresenter.DisplayMessage($"Method B - Thread before the awaiting task: {Thread.CurrentThread.ManagedThreadId}");
            await this.MethodAAsync();
            ConsolePresenter.DisplayMessage($"Method B - Thread after the awaiting task : {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task MethodAAsync()
        {
            ConsolePresenter.DisplayMessage($"Method A - Thread before the awaiting task: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000).ConfigureAwait(false);
            ConsolePresenter.DisplayMessage($"Method A - Thread after the awaiting task : {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
