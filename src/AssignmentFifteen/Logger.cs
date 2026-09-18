using System.Text;

namespace AssignmentFifteen
{
    /// <summary>
    /// Represents the logging functionality into the file.
    /// </summary>
    public class Logger
    {
        private static readonly object _lock = new object();

        private string _logFilePath = "log.txt";

        /// <summary>
        /// Logs the errors into the file.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="userId">Unique id of the user.</param>
        public void LogError(string message, string userId)
        {
            byte[] errorBuffer = Encoding.UTF8.GetBytes(message);
            lock (_lock)
            {
                using (FileStream fileStream = new FileStream(this._logFilePath, FileMode.Append))
                {
                    Console.WriteLine($"User Id :{userId}....Writing into the file !!");
                    fileStream.Write(errorBuffer, 0, errorBuffer.Length);
                    Console.WriteLine($"User Id :{userId}....Written successfully !!");
                }
            }
        }
    }
}
