namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the List operations.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class ListImplementation<T>
    {
        private List<T> _items = new List<T>();

        /// <summary>
        /// Performs operation on List such as Add,Remove,Display.
        /// </summary>
        /// <param name="itemToBeAdded">Item to be added.</param>
        /// <param name="itemToBeSearched">Item to be searched.</param>
        /// <param name="itemToBeDeleted">Item to be deleted.</param>
        public void PerformOperations(T[] itemToBeAdded, T[] itemToBeSearched, T[] itemToBeDeleted)
        {
            Console.WriteLine("----------------------------------------" +
                              "\n    ------List Implementation------" +
                              "\n----------------------------------------");

            foreach (T item in itemToBeAdded)
            {
                this.AddItem(item);
                this.DisplayItems();
            }

            foreach (T book in itemToBeSearched)
            {
                this.Contains(book);
            }

            foreach (T item in itemToBeDeleted)
            {
                this.RemoveItem(item);
                Console.WriteLine($"\nAfter Deleting the item : {item}");
                this.DisplayItems();
            }
        }

        /// <summary>
        /// Adds the item into the list.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        private void AddItem(T item)
        {
            this._items.Add(item);
            Console.WriteLine($"{item} added into the list.");
        }

        /// <summary>
        /// Removes the item from the list.
        /// </summary>
        /// <param name="item">Item to be deleted.</param>
        private void RemoveItem(T item)
        {
            bool isDeleted = this._items.Remove(item);
            if (isDeleted)
            {
                Console.WriteLine($"{item} deleted.");
                return;
            }

            Console.WriteLine($"{item} not found, so can't be deleted.");
        }

        /// <summary>
        /// To search for an item inside the list.
        /// </summary>
        /// <param name="item">Item to be searched</param>
        private void Contains(T item)
        {
            if (this._items.Contains(item))
            {
                Console.WriteLine($"{item} found.");
                return;
            }

            Console.WriteLine($"{item} not found.");
        }

        /// <summary>
        /// To display the item in the list.
        /// </summary>
        private void DisplayItems()
        {
            if (this._items.Count == 0)
            {
                Console.WriteLine("No items are in the list !!");
                return;
            }

            Console.WriteLine("The items are : " +
                              "\n====================================");
            foreach (T item in this._items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================");
        }
    }
}
