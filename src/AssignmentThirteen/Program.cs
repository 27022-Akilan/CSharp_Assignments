using AssignmentThirteen;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            //ListImplementation listImplementation = new ListImplementation();
            //listImplementation.PerformOperations();
            //StackImplementation stackImplementation = new StackImplementation();
            //stackImplementation.PerformOperations();

            //QueueImplementation queueImplementation = new QueueImplementation();
            //queueImplementation.PerformOperations();

            DictionaryImplementation dictionaryImplementation = new DictionaryImplementation();
            dictionaryImplementation.PerformOperations();
        }
    }
}