using System.Diagnostics;

namespace AssignmentEighteen.ArrayManager
{
    /// <summary>
    /// Represents the functionalities to create and manipulate array.
    /// </summary>
    public class ArrayManager
    {
        /// <summary>
        /// Performs squaring operation on the array.
        /// </summary>
        public void SquareArray()
        {
            int[] array = new int[100];
            int[] dummy = new int[100];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < dummy.Length; i++)
            {
                dummy[i] = array[i] * array[i];
                Thread.Sleep(100);
            }

            stopwatch.Stop();
            this.PrintArray("\nInitial array", array);
            this.PrintTime("For Loop", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Parallel.For(0, 100, i =>
            {
                array[i] *= array[i];
                Thread.Sleep(100);
            });

            stopwatch.Stop();
            this.PrintArray("\nArray after squaring the numbers using Parallel", array);
            this.PrintTime("Parallel", stopwatch.ElapsedMilliseconds);
        }

        private void PrintArray(string message, int[] array)
        {
            Console.WriteLine(message);
            foreach (int number in array)
            {
                Console.Write($"{number},");
            }
        }

        private void PrintTime(string type, long time)
        {
            Console.WriteLine($"\nThe time taken for squaring the array using [{type}] " +
                              $"\n====================" +
                              $"\n{time}" +
                              $"\n====================");
        }
    }
}
