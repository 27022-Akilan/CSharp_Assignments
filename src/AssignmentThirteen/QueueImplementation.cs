namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the Queue implementation for a waiting list.
    /// </summary>
    public class QueueImplementation
    {
        private Queue<string> _waitingQueue = new Queue<string>();

        /// <summary>
        /// To add,serve display people on the queue.
        /// </summary>
        public void PerformOperations()
        {
            Console.WriteLine($"======================================" +
                              "\nWaiting List Queue Implementation" +
                              "\n\"======================================");

            this.AddPeopleToQueue("Kavin anna");
            this.DisplayQueue();
            this.AddPeopleToQueue("Akilan");
            this.DisplayQueue();
            this.AddPeopleToQueue("Vishnu");
            this.DisplayQueue();

            this.ServePeopleOnQueue();
            this.DisplayQueue();
            this.ServePeopleOnQueue();
            this.DisplayQueue();
        }

        private void AddPeopleToQueue(string peopleName)
        {
            this._waitingQueue.Enqueue(peopleName);
            Console.WriteLine($"Added {peopleName} to the Queue");
        }

        private void ServePeopleOnQueue()
        {
            if (this._waitingQueue.Count > 0)
            {
                Console.WriteLine("\n\nServing the first person on the queue.");
                string personName = this._waitingQueue.Dequeue();
                Console.WriteLine($"{personName} Served and discarded from the Queue.");
                return;
            }

            Console.WriteLine("No people in the Queue !!");
        }

        private void DisplayQueue()
        {
            if (this._waitingQueue.Count == 0)
            {
                Console.WriteLine("No people on the queue");
                return;
            }

            Console.WriteLine("The person's in the Queue are :");
            int i = 1;
            foreach (var personName in this._waitingQueue)
            {
                Console.WriteLine($"{i++}.{personName}");
            }
        }
    }
}
