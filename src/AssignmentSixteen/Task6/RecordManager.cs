using AssignmentSixteen.Helper;

namespace AssignmentSixteen.Task6
{
    /// <summary>
    /// Represents the operations performed on the records.
    /// </summary>
    public class RecordManager
    {
        public record Book(string title, string author, string iSBN);

        /// <summary>
        /// To create and perform operations on Records.
        /// </summary>
        public void ManipulateRecords()
        {
            Console.WriteLine("=====Task 6=====");
            Book book1 = new Book("Clean Code", "Kavin", "BCC1");
            Book book2 = new Book("MVC", "Akilan", "BMVC101");
            Book book3 = new Book("Clean Code", "Kavin", "BCC1");

            Console.WriteLine("\n==== Books List ====");
            DisplayBook(book1);
            DisplayBook(book2);
            DisplayBook(book3);

            Console.WriteLine("\n==== Comparing Books ====");
            CompareBookValues(book1, book2);

            Console.WriteLine("\n==== Comparing Books ====");
            CompareBookValues(book1, book3);

            Console.WriteLine("\n==== Changing book details using 'with{}'====");
            UpdateBookAndDisplay();

            ConsoleHelper.WaitAndClear();
        }

        private static void CompareBookValues(Book book1, Book book2)
        {
            Console.WriteLine("Comparing books :\nBook1");
            DisplayBook(book1);
            Console.WriteLine("\nBook2");
            DisplayBook(book2);
            if (book1 == book2)
            {
                Console.WriteLine("Book values are equal !!");
                return;
            }

            Console.WriteLine("Book values are not equal !!");
        }

        private static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"Title : {title}");
            Console.WriteLine($"Author : {author}");
            Console.WriteLine($"ISBN : {isbn}");
        }

        private static void UpdateBookAndDisplay()
        {
            Book originalBook = new Book("C++", "Kavin", "Cpp101");
            Console.WriteLine("Original book before with operator : ");
            DisplayBook(originalBook);
            Book updatedBook = originalBook with { title = "LabView" };
            Console.WriteLine("Original book after extending by another book and changing Title to 'LabView' : ");
            DisplayBook(originalBook);
        }
    }
}
