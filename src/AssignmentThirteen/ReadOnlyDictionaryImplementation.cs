namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the operations on IReadOnlyDictionary.
    /// </summary>
    public class ReadOnlyDictionaryImplementation
    {
        /// <summary>
        /// Creates performs operations on dictionary.
        /// </summary>
        public void PerformOperations()
        {
            IReadOnlyDictionary<string, int> dictionary = this.GenerateDictionary();
            this.PrintDictionary(dictionary);
            this.ModifyDictionary(dictionary);
        }

        private void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Item name : {item.Key} \t Quantity : {item.Value}");
            }
        }

        private void ModifyDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            // This below line can't be done as it is readonly.
            // dictionary["Apple"] = 0;
        }

        /// <summary>
        /// Generates a IReadOnlyDictionary which can only be read.
        /// </summary>
        /// <returns>Read only dictionary which cannot be modified</returns>
        private IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Apple", 10);
            dictionary.Add("Banana", 32);
            dictionary.Add("Grapes", 20);
            return dictionary;
        }
    }
}
