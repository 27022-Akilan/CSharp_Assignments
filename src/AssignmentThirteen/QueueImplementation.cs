namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the Queue implementation for a waiting list.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class QueueImplementation<T>
    {
        private Queue<T> _waitingQueue = new Queue<T>();

        /// <summary>
        /// To add,serve display people on the queue.
        /// </summary>
        /// <param name="items">Names of the people</param>
        public void PerformOperations(T[] items)
        {
            Console.WriteLine($"======================================" +
                              "\nWaiting List - Queue Implementation" +
                              "\n\"======================================");

            foreach (T item in items)
            {
                this.AddItemToQueue(item);
                this.DisplayQueue();
            }

            this.ServeItemOnQueue();
            this.DisplayQueue();
            this.ServeItemOnQueue();
            this.DisplayQueue();
        }

        private void AddItemToQueue(T item)
        {
            this._waitingQueue.Enqueue(item);
            Console.WriteLine($"Added {item} to the Queue");
        }

        private void ServeItemOnQueue()
        {
            if (this._waitingQueue.Count > 0)
            {
                Console.WriteLine("\n\nServing the first item on the queue.");
                T item = this._waitingQueue.Dequeue();
                Console.WriteLine($"{item} is served and discarded from the Queue.");
                return;
            }

            Console.WriteLine("No people in the Queue !!");
        }

        private void DisplayQueue()
        {
            if (this._waitingQueue.Count == 0)
            {
                Console.WriteLine("No item on the queue");
                return;
            }

            Console.WriteLine("\n\nThe item's in the Queue are :" +
                              "\n===============================================");
            int i = 1;
            foreach (var item in this._waitingQueue)
            {
                Console.WriteLine($"{i++}.{item}");
            }

            Console.WriteLine("===============================================\n");
        }
    }
}
