namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the dictionary in Generic format.
    /// </summary>
    /// <typeparam name="TKey">Generic key type.</typeparam>
    /// <typeparam name="TValue">Generic Value type.</typeparam>
    public class DictionaryImplementation<TKey, TValue>
        where TKey : notnull
    {
        private Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Performs operation like Add,Delete and remove items.
        /// </summary>
        /// <param name="itemKey">Key of the item.</param>
        /// <param name="itemValue">Value of the item.</param>
        /// <param name="itemsToBeDeleted">Items to be deleted.</param>
        public void PerformOperations(TKey[] itemKey, TValue[] itemValue, TKey[] itemsToBeDeleted)
        {
            Console.WriteLine("==================================================================" +
                              "\n     Representing Item and their value in Dictionary" +
                              "\n==================================================================");

            int length = itemKey.Length;
            for (int i = 0; i < length; i++)
            {
                this.AddItem(itemKey[i], itemValue[i]);
            }

            this.DisplayItem();

            foreach (TKey item in itemsToBeDeleted)
            {
                this.RemoveItem(item);
                this.DisplayItem();
            }
        }

        private void AddItem(TKey itemKey, TValue itemValue)
        {
            if (this._items.TryAdd(itemKey, itemValue))
            {
                Console.WriteLine($"ItemKey :{itemKey} | Item Value : {itemValue} added successfully");
                return;
            }

            Console.WriteLine($"ItemKey : {itemKey} already exists so cannot be added.");
        }

        private void RemoveItem(TKey itemKey)
        {
            if (this._items.Remove(itemKey))
            {
                Console.WriteLine($"\n{itemKey} removed.");
                return;
            }

            Console.WriteLine($"\nItem Key : {itemKey} not found so cannot be deleted.");
        }

        private void DisplayItem()
        {
            Console.WriteLine("\n\nItem and their value is :");
            foreach (var student in this._items)
            {
                Console.WriteLine($"Item Key : {student.Key}  Item Value : {student.Value}");
            }
        }
    }
}
