namespace ValueAndReferenceType
{
    /// <summary>
    /// Represents the functionalities to analyse the heap and local variables.
    /// </summary>
    public class StackVsHeap
    {
        /// <summary>
        /// To analyse the heap memory.
        /// </summary>
        public void AnalyseHeapMemory()
        {
            int[]? array = new int[1000000];
            Console.WriteLine("Look into the Memory usage by Debug -> Windows -> Show Diagnostic Tool");
            array = null;
            Console.ReadKey();
        }

        /// <summary>
        /// To analyse the local variables resides.
        /// </summary>
        public void AnalyseStackMemory()
        {
            int num1 = 10;
            int num2 = 10;
            int num3 = 10;
            int num4 = 10;
            int sumOfFirstFour = num1 + num2 + num3 + num4;
            Console.WriteLine("\nSee the local variables inside the Debug -> Windows -> Locals");
            Console.ReadKey();
        }
    }
}
