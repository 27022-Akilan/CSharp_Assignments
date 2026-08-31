namespace AssignmentFive.Repository.Log
{
    /// <summary>
    /// Represents the generic logger for application's events.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the informational message.
        /// </summary>
        /// <param name="message">Info message</param>
        public void LogInfo(string message);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">Warning message</param>
        public void LogWarning(string message);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">Error message</param>
        public void LogError(string message);
    }
}
