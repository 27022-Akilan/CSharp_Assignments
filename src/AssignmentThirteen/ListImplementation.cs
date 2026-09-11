namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the List operations.
    /// </summary>
    public class ListImplementation
    {
        private List<string> _books = new List<string>();

        /// <summary>
        /// Performs operation on List such as Add,Remove,Display.
        /// </summary>
        public void PerformOperations()
        {
            Console.WriteLine("----------------------------------------" +
                              "\n    ------List Implementation------" +
                              "\n----------------------------------------");
            this.AddItem("Kavin's c++ book");
            this.AddItem("Akilan's C# book");
            this.AddItem("Vishnu's Python book");
            this.AddItem("Alice's clean code");
            Console.WriteLine("\nAfter Adding all the books");
            this.DisplayItems();
            this.Contains("Bob's Consistency");
            this.DisplayItems();
            this.RemoveItem("Alice's clean code");
            Console.WriteLine("\nAfter Deleting the book : Alice's clean code");
            this.DisplayItems();
            this.RemoveItem("Andrew's Self Improvement");
        }

        /// <summary>
        /// Adds the book into the list.
        /// </summary>
        /// <param name="bookName">Name of the book to be added.</param>
        private void AddItem(string bookName)
        {
            this._books.Add(bookName);
            Console.WriteLine($"{bookName} added into the list.");
        }

        /// <summary>
        /// Removes the book from the list.
        /// </summary>
        /// <param name="bookName">Name of the book to be deleted.</param>
        private void RemoveItem(string bookName)
        {
            bool isDeleted = this._books.Remove(bookName);
            if (isDeleted)
            {
                Console.WriteLine($"{bookName} book  deleted.");
                return;
            }

            Console.WriteLine($"{bookName} not found, so can't be deleted.");
        }

        /// <summary>
        /// To check whether the book is inside the list.
        /// </summary>
        /// <param name="bookName">Name of the book to check whether the book is inside the list or not.</param>
        private void Contains(string bookName)
        {
            if (this._books.Contains(bookName))
            {
                Console.WriteLine($"{bookName} found.");
                return;
            }

            Console.WriteLine($"{bookName} not found.");
        }

        /// <summary>
        /// To display the books in the list.
        /// </summary>
        private void DisplayItems()
        {
            if (this._books.Count == 0)
            {
                Console.WriteLine("No books are in the list !!");
                return;
            }

            Console.WriteLine("The books are : " +
                              "\n====================================");
            foreach (string book in this._books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("====================================");
        }
    }
}
