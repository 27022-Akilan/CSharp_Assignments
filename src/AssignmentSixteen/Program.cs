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
            Notifier notifier = new Notifier();
            notifier.OnAction += DisplayMessage;
            notifier.SendNotification();
            WaitAndClear();

            ArrayOperator arrayOperator = new ArrayOperator();
            arrayOperator.PerformOperations(new int[] { 6, 5, 4, 3, 2, 1 });
            WaitAndClear();

            ListOperator listOperator = new ListOperator();
            listOperator.FilterAndSquareEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6 });
            WaitAndClear();

            ProductManager productManager = new ProductManager();
            List<Product> products = productManager.CreateProducts();
            productManager.SortAndDisplayProducts(products, SortByName);
            productManager.SortAndDisplayProducts(products, SortByCategory);
            productManager.SortAndDisplayProducts(products, SortByPrice);
            WaitAndClear();

            Book book1 = new Book("Clean Code", "Kavin", "BCC1");
            Book book2 = new Book("MVC", "Akilan", "BMVC101");
            Book book3 = new Book("Clean Code", "Kavin", "BCC1");
            DisplayBook(book1);
            DisplayBook(book2);
            DisplayBook(book3);
            CompareBookValues(book1, book2);
            CompareBookValues(book1, book3);
            ChangeBookDetailsAndDisplay();
            WaitAndClear();

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
        }

        public static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle:
                    var circle = shape as Circle;
                    circle.Name;

            }
        }
        /// <summary>
        /// Displays the message to the user.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Compares product by name and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 name is smaller than product 2 name
        /// 0 If two products names are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        /// <summary>
        /// Compares product by category and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 category is smaller than product 2 category
        /// 0 If two products category are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        /// <summary>
        /// Compares product by price and returns an integer representing the result.
        /// </summary>
        /// <param name="product1">Product 1</param>
        /// <param name="product2">Product 2</param>
        /// <returns>
        /// -1 if product 1 price is smaller than product 2 price
        /// 0 If two products price are equal
        /// 1 otherwise
        /// </returns>
        public static int SortByPrice(Product product1, Product product2)
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
            Console.WriteLine("Press Any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}