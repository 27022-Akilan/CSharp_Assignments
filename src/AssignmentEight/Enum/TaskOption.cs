namespace AssignmentEight.Enum
{
    /// <summary>
    /// Represents each demo in the main menu. Named after what the demo actually does,
    /// rather than "Task1", "Task2", etc.
    /// </summary>
    public enum TaskOption
    {
        /// <summary>
        /// Demonstrates try/catch/finally while dividing two numbers.
        /// </summary>
        DivisionWithTryCatchFinally = 1,

        /// <summary>
        /// Demonstrates catching an IndexOutOfRangeException and throwing a new,
        /// more descriptive exception from within the catch block.
        /// </summary>
        ArrayLookupWithRethrownException,

        /// <summary>
        /// Demonstrates validating user input and throwing a custom exception type
        /// (InvalidUserInputException) when the input is invalid.
        /// </summary>
        UserInputValidationWithCustomException,

        /// <summary>
        /// Demonstrates a truly unhandled exception being caught by the
        /// AppDomain.UnhandledException global handler.
        /// </summary>
        GlobalUnhandledExceptionDemo,

        /// <summary>
        /// Demonstrates throwing/catching an exception and reading its stack trace.
        /// </summary>
        StackTraceInterpretation,

        /// <summary>
        /// Exits the application.
        /// </summary>
        Exit,
    }
}
