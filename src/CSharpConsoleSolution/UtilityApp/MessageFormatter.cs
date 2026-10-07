namespace UtilityApp
{
    /// <summary>
    /// Represents funtionalities for formatting the messages.
    /// </summary>
    public static class MessageFormatter
    {
        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="message">Message to be formatted.</param>
        /// <returns>Formatted message.</returns>
        public static string FormatMessage(string message)
        {
            return $"[Result] : {message}";
        }
    }
}
