using System.Text;

namespace AssignmentFifteen.LoggerImplementation
{
    /// <summary>
    /// Represents the logging functionality into the file.
    /// </summary>
    public class Logger
    {
        private static readonly Dictionary<string, object> _userLocks = new Dictionary<string, object>();

        private string _commonFileNameExtension = "log.txt";

        /// <summary>
        /// Logs the errors into the file.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="userId">Unique id of the user.</param>
        public void LogError(string message, string userId)
        {
            object? userLock;

            lock (_userLocks)
            {
                if (!_userLocks.TryGetValue(userId, out userLock))
                {
                    userLock = new object();
                    _userLocks[userId] = userLock;
                }
            }

            lock (userLock)
            {
                string userFile = userId + "_" + this._commonFileNameExtension;
                byte[] errorBuffer = Encoding.UTF8.GetBytes(message);
                using (FileStream fileStream = new FileStream(userFile, FileMode.Append))
                {
                    Console.WriteLine($"User Id :{userId}....Writing into the file !!");
                    fileStream.Write(errorBuffer, 0, errorBuffer.Length);
                    Console.WriteLine($"User Id :{userId}....Written successfully !!");
                }
            }
        }
    }
}
