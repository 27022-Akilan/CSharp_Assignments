using System.Diagnostics;

namespace AssignmentFifteen
{
    /// <summary>
    /// Represents the load testing functionality.
    /// </summary>
    public class LoadTester
    {
        private readonly Logger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadTester"/> class.
        /// </summary>
        /// <param name="logger">Instance of the logger</param>
        public LoadTester(Logger logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Tests the load handling and performance.
        /// </summary>
        public void TestLoad()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, 100, userId =>
            {
                string userIdAsString = userId.ToString();
                this._logger.LogError($"{userId} : Error on login..", userIdAsString);
            });
            stopwatch.Stop();
            Console.WriteLine("Tested for multiple users single file :" +
                              $"{stopwatch.ElapsedMilliseconds}");
        }
    }
}
