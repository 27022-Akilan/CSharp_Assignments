namespace AssignmentEighteen.Enums
{
    /// <summary>
    /// Represents the options to navigate the main menu.
    /// </summary>
    public enum MenuOptions
    {
        /// <summary>
        /// Option to scrape content from the website.
        /// </summary>
        WebsiteScrapping = 1,

        /// <summary>
        /// Option to perform operations on array.
        /// </summary>
        ArrayOperations,

        /// <summary>
        /// Option to implement multithreading.
        /// </summary>
        MultiThreading,

        /// <summary>
        /// Option to analyse data that is scrapped from the website.
        /// </summary>
        DataAnalyser,

        /// <summary>
        /// Option to analyse the deadlock and remove it.
        /// </summary>
        DeadLockAnalyser,

        /// <summary>
        /// Option to configure the await and perform the operation.
        /// </summary>
        ConfigureAwaitManager,

        /// <summary>
        /// Option to handle the exceptions using async avoid/async Task.
        /// </summary>
        ExceptionHandler,

        /// <summary>
        /// Option to exit the menu.
        /// </summary>
        Exit,
    }
}
