namespace AssignmentEighteen.Task7
{
    /// <summary>
    /// Represents handling the exception.
    /// </summary>
    public class ExceptionHandler
    {
        /// <summary>
        /// Handles the exception thrown from async void and async Task method.
        /// </summary>
        /// <returns>Task object</returns>
        public async Task HandleExceptionAsync()
        {
            try
            {
                this.VoidMethodAsync();
            }
            catch (InvalidOperationException)
            {
                // This catch block will not be reached as the VoidMathodAsync return type is void so the exception gets swallowed.
                Console.WriteLine("Exception caught from the async void method");
            }

            try
            {
                await this.TaskMethodAsync();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Exception caught from the async Task method");
            }

            // Intentional wait for using async methods.
            await Task.Delay(1);
        }

        private async void VoidMethodAsync()
        {
            // Intentional wait for using async methods.
            await Task.Delay(1);

            throw new InvalidOperationException();
        }

        private async Task TaskMethodAsync()
        {
            // Intentional wait for using async methods.
            await Task.Delay(1);

            throw new InvalidOperationException();
        }
    }
}
