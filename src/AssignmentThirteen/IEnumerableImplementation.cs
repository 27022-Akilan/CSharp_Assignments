namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the implementation of IEnumerable accepting concrete types.
    /// </summary>
    public class IEnumerableImplementation
    {
        /// <summary>
        /// Creates List,Array,Queue and performs operations on it.
        /// </summary>
        public void PerformOperations()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            this.SumOfElements("List", list);
            int[] array = { 1, 2, 3, 4, 5 };
            this.SumOfElements("Array", array);
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i);
            }

            this.SumOfElements("Queue", queue);
        }

        private void SumOfElements(string type, IEnumerable<int> enumerator)
        {
            long sum = 0;
            foreach (int element in enumerator)
            {
                sum += element;
            }

            Console.WriteLine($"Sum of the elements in {type} are : {sum}");
        }
    }
}
