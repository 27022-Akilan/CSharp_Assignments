namespace AssignmentTwelve
{
    /// <summary>
    /// Represents the memory eater class.
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memoryAllocation = new List<int[]>();

        /// <summary>
        /// Memory Optimization technique 1.
        /// </summary>
        public void OptimizeMemoryMethod1()
        {
            // case 1 : When I don't need the List
            while (true)
            {
                int[] array = new int[1000];

                // Perform the operations on the array. When needed break.
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Memory Optimization technique 2.
        /// </summary>
        public void OptimizeMemoryMethod2()
        {
            // Case 2 : When you need a list.
            // Optimization by having a limit for list size.
            int listLimit = 100;
            int i = 0;
            while (i < listLimit)
            {
                this._memoryAllocation.Add(new int[1000]);
                Thread.Sleep(1000);
                i++;
            }
        }
    }
}
