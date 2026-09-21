using AssignmentSixteen.Helper;

namespace AssignmentSixteen.Task4
{
    /// <summary>
    /// Represents the List operations.
    /// </summary>
    public class ListManager
    {
        /// <summary>s
        /// Filters the even numbers and squares it.
        /// </summary>
        /// <param name="list">List of integers.</param>
        public void FilterAndSquareEvenNumbers(List<int> list)
        {
            Console.WriteLine("=====Task 4=====");
            this.DisplayList("\nThe list is : ", list);

            IEnumerable<int> filteredList = list.Where(number => number % 2 == 0)
                                                .Select(evenNumber => evenNumber * evenNumber);

            this.DisplayList("\nAfter filtering the Even numbers and squaring it the result is :", filteredList);
            ConsoleHelper.WaitAndClear();
        }

        private void DisplayList(string message, IEnumerable<int> list)
        {
            Console.WriteLine(message);
            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
        }
    }
}
