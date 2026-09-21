namespace AssignmentSixteen.Task3
{
    /// <summary>
    /// Represents the array operations.
    /// </summary>
    public class ArrayManager
    {
        /// <summary>
        /// Performs operations on the array.
        /// </summary>
        /// <param name="array">Array of integers in which operations to be performed.</param>
        public void PerformOperations(int[] array)
        {
            Console.WriteLine("=====Task 3=====");
            this.DisplayArray("\nThe original array is : ", array);
            int[] sortedArray = this.SortArray(array);
            this.DisplayArray("\nThe sorted array is : ", sortedArray);
        }

        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <returns>A sorted array</returns>
        private int[] SortArray(int[] array)
        {
            Array.Sort(array, (a, b) =>
            {
                return a.CompareTo(b);
            });

            return array;
        }

        private void DisplayArray(string message, int[] array)
        {
            Console.WriteLine(message);
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
