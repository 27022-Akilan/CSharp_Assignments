namespace AssignmentEighteen.Task5
{
    /// <summary>
    /// Represents the functionalities to recover from the deadlock.
    /// </summary>
    public class DeadlockRecoverer
    {
        /// <summary>
        ///  Method to recover from the deadlock.
        /// </summary>
        /// <returns>Task object.</returns>
        public async Task DeadlockMethodAsync()
        {
            // Result is a blocking operation, so then this waits for the result from the SomeOperationAsync() method
            // and after Task.Delay() ,the next line waits for the thread to execute it but its blocked in the .Result.
            // So its a DeadLock when there's like a UI thread.
            // var result = this.SomeOperationAsync().Result;
            var result = await this.SomeOperationAsync();
            Console.WriteLine(result);
        }

        private async Task<string> SomeOperationAsync()
        {
            await Task.Delay(3000);
            return "Hii Akilan";
        }
    }
}
