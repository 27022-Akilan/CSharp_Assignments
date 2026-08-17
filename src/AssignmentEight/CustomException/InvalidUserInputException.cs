namespace AssignmentEight.CustomException
{
    /// <summary>
    ///  User defined exception for invalid user input.
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Message fo the exception</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
