namespace AssignmentSixteen
{
    /// <summary>
    /// Represents the array operations.
    /// </summary>
    public class ArrayOperator
    {
        /// <summary>
        /// Performs operations on the array.
        /// </summary>
        /// <param name="array">Array of integers in which operations to be performed.</param>
        public void PerformOperations(int[] array)
        {
            this.DisplayArray(array, "\nThe original array is : ");
            int[] sortedArray = this.SortArray(array);
            this.DisplayArray(sortedArray, "\nThe sorted array is : ");
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
                return a - b;
            });

            return array;
        }

        private void DisplayArray(int[] array, string message)
        {
            Console.WriteLine(message);
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
