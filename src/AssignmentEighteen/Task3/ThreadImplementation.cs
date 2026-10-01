namespace AssignmentEighteen.Task3
{
    /// <summary>
    /// Represents the implemenatation of threads.
    /// </summary>
    public class ThreadImplementation
    {
        private int[] _arrayOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] _arrayTwo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int _additionResult = 0;
        private int _multiplicationResult = 1;

        /// <summary>
        /// Runs diferent threads.
        /// </summary>
        public void RunThread()
        {
            Thread t1 = new Thread(this.AddArrayElements);
            Thread t2 = new Thread(this.MultiplyArrayElements);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"The result of summing up the array is : {this._additionResult}" +
                              $"\nThe result of multiplying the array is : {this._multiplicationResult}");
        }

        private void AddArrayElements()
        {
            for (int i = 0; i < this._arrayOne.Length; i++)
            {
                this._additionResult += this._arrayOne[i];
            }
        }

        private void MultiplyArrayElements()
        {
            for (int i = 0; i < this._arrayTwo.Length; i++)
            {
                this._multiplicationResult *= this._arrayTwo[i];
            }
        }
    }
}
