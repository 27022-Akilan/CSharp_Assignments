using AssignmentSixteen;
using AssignmentSixteen.Task7;

namespace Assignments
{
    public record Book(string title, string author, string iSBN);

    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            PerformEventsTask();
            PerformArrayOperations();
            PerformListOperations();
            PerformDelegateOperations();
            PerformRecordOperations();
            PerformPatternMatching();
        }

        private static void PerformEventsTask()
        {
            Console.WriteLine("=====Task 1=====");
            Notifier notifier = new Notifier();
            notifier.OnAction += DisplayMessage;
            notifier.SendNotification();
            WaitAndClear();
        }

        private static void PerformArrayOperations()
        {
            Console.WriteLine("=====Task 3=====");
            ArrayOperator arrayOperator = new ArrayOperator();
            arrayOperator.PerformOperations(new int[] { 6, 5, 4, 3, 2, 1 });
            WaitAndClear();
        }

        private static void PerformListOperations()
        {
            Console.WriteLine("=====Task 4=====");
            ListOperator listOperator = new ListOperator();
            listOperator.FilterAndSquareEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6 });
            WaitAndClear();
        }

        private static void PerformDelegateOperations()
        {
            Console.WriteLine("=====Task 5=====");
            ProductManager productManager = new ProductManager();
            List<Product> products = productManager.CreateProducts();
            Console.WriteLine("\n\n====Sorts by Name====\n\n");
            productManager.SortAndDisplayProducts(products, SortByName);
            Console.WriteLine("\n\n====Sorts by Category====\n\n");
            productManager.SortAndDisplayProducts(products, SortByCategory);
            Console.WriteLine("\n\n====Sorts by Price====\n\n");
            productManager.SortAndDisplayProducts(products, SortByPrice);
            WaitAndClear();
        }

        private static void PerformRecordOperations()
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
            ChangeBookDetailsAndDisplay();
            WaitAndClear();
        }

        private static void PerformPatternMatching()
        {
            Console.WriteLine("=====Task 7=====");
            List<Shape> shapes = new List<Shape>();
            Shape rectangle = new Rectangle("Rectangle", 5, 4);
            Shape circle = new Circle("Circle", 5);
            Shape triangle = new Triangle("Triangle", 3, 7);
            shapes.Add(rectangle);
            shapes.Add(circle);
            shapes.Add(triangle);

            foreach (Shape shape in shapes)
            {
                DisplayShapeDetails(shape);
            }

            WaitAndClear();
        }

        private static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine($"Name : {circle.Name} | Radius : {circle.Radius}| Area of the circle : {circle.CalculateArea()}");
                    break;
                case Triangle triangle:
                    Console.WriteLine($"Name : {triangle.Name} | Base Length : {triangle.BaseLength} | Height : {triangle.Height} | Area of Triangle : {triangle.CalculateArea()}");
                    break;
                case Rectangle rectangle:
                    Console.WriteLine($"Name: {rectangle.Name} | Base Length: {rectangle.Length} | Height : {rectangle.Breadth} | Area of Triangle : {rectangle.CalculateArea()}");
                    break;
                case null:
                    Console.WriteLine("Shape cant be null !!");
                    break;
                default:
                    Console.WriteLine("No properties are defined for this shape");
                    break;
            }
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        private static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        private static int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
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

        private static void ChangeBookDetailsAndDisplay()
        {
            Book originalBook = new Book("C++", "Kavin", "Cpp101");
            Console.WriteLine("Original book before with operator : ");
            DisplayBook(originalBook);
            Book updatedBook = originalBook with { title = "LabView" };
            Console.WriteLine("Original book after extending by another book and changing Title to 'LabView' : ");
            DisplayBook(originalBook);
        }

        private static void WaitAndClear()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress Any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}