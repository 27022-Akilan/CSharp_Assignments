namespace AssignmentFive.Repository.Log
{
    /// <summary>
    /// Singleton pattern implementation for the Logger.
    /// </summary>
    public class FileLogger : ILogger
    {
        private const string TimeStampFormat = "yyyy-MM-dd HH:mm:ss";

        private const string DefaultFilePath = @"C:\C#\Assignment5Logger.json";

        private static readonly object _lock = new object();

        private static FileLogger? _instance;

        private readonly string _filePath;

        private FileLogger(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Gets the instance of the file logger 
        /// </summary>
        /// <returns>FileLogger instance</returns>
        public static FileLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileLogger(DefaultFilePath);
                    }
                }
            }

            return _instance;
        }

        /// <inheritdoc/>
        public void LogInfo(string message)
        {
            this.Write("Info", message);
        }

        /// <inheritdoc/>
        public void LogWarning(string message)
        {
            this.Write("Warning", message);
        }

        /// <inheritdoc/>
        public void LogError(string message)
        {
            this.Write("Error", message);
        }

        private void Write(string level, string message)
        {
            string timeStamp = DateTime.Now.ToString(TimeStampFormat);
            string line = $"{timeStamp} [{level}] {message}";

            try
            {
                File.AppendAllText(this._filePath, line + Environment.NewLine);
            }

            // Because the logger should not crash the application.
            catch (IOException)
            {
            }
        }
    }
}
