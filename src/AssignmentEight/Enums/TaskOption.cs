namespace AssignmentEight.Enums
{
    /// <summary>
    /// Represents each demo in the main menu. Named after what the demo actually does,
    /// rather than "Task1", "Task2", etc.
    /// </summary>
    public enum TaskOption
    {
        /// <summary>
        /// Option for demonstrating a DivideByZeroException and how to catch it.
        /// </summary>
        DivisionByZero = 1,

        /// <summary>
        /// Option for demonstrating an ArrayIndexOutOfRangeException and to throw and catch it.
        /// </summary>
        ArrayIndexOutOfRange,

        /// <summary>
        /// Option for demonstrating a custom exception class and how to throw/catch it.
        /// </summary>
        CustomException,

        /// <summary>
        /// Option for demonstrating a global unhandled exception and how to catch it.
        /// </summary>
        GlobalUnhandledException,

        /// <summary>
        /// Option for demonstrating how to interpret a stack trace and understand the flow of an exception.
        /// </summary>
        StackTraceInterpretation,

        /// <summary>
        /// Option for exiting the application.
        /// </summary>
        Exit,
    }
}
