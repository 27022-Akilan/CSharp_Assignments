namespace AssignmentSixteen
{
    /// <summary>
    /// Represents the List operations.
    /// </summary>
    public class ListOperator
    {
        /// <summary>
        /// Filters the even numbers and squares it.
        /// </summary>
        /// <param name="list">List of integers.</param>
        public void FilterAndSquareEvenNumbers(List<int> list)
        {
            this.DisplayList(list, "\nThe list is : ");
            IEnumerable<int> filteredList = list.Where(number => number % 2 == 0)
                                                .Select(evenNumber => evenNumber * evenNumber);
            this.DisplayList(filteredList, "\nAfter filtering the Even numbers and squaring it the result is :");
        }

        private void DisplayList(IEnumerable<int> list, string message)
        {
            Console.WriteLine(message);
            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
        }
    }
}
