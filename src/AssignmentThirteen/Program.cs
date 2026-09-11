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
            ListImplementation<string> listImplementation = new ListImplementation<string>();
            string[] booksToBeAdded = { "Kavin's c++ book", "Akilan's C# book", "Vishnu's Python book", "Alice's clean code" };
            string[] booksToBeSearched = { "Akilan's C# book" };
            string[] booksToBeDeleted = { "Alice's clean code", "Andrew's Self Improvement" };
            listImplementation.PerformOperations(booksToBeAdded, booksToBeSearched, booksToBeDeleted);
            WaitAndClear();

            StackImplementation stackImplementation = new StackImplementation();
            stackImplementation.PerformOperations();
            WaitAndClear();

            QueueImplementation<string> queueImplementation = new QueueImplementation<string>();
            string[] peopleName = { "Kavin Anna", "Akilan", "Vishnu" };
            queueImplementation.PerformOperations(peopleName);
            WaitAndClear();

            DictionaryImplementation<string, int> dictionaryImplementation = new DictionaryImplementation<string, int>();
            string[] studentNames = { "Kavin anna", "Akilan", "Alice" };
            int[] studentMark = { 90, 98, 76 };
            string[] studentToBeDeleted = { "Jai", "Alice" };
            dictionaryImplementation.PerformOperations(studentNames, studentMark, studentToBeDeleted);
            WaitAndClear();
        }

        private static void WaitAndClear()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}