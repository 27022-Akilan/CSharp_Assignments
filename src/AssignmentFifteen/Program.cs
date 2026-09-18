namespace AssignmentFifteen
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <returns>A task object<returns>
        public static async Task Main()
        {
            try
            {
                //string inputFilePath = @"SampleData.txt";
                //string destinationFilePath = @"OutputFile.txt";
                //string dummyFilePath = @"Dummy.txt";

                //Console.WriteLine("==================================" +
                //                  "\nNormal File operations" +
                //                  "\n==================================");

                //FileOperator fileOperator = new FileOperator(inputFilePath, destinationFilePath);
                //fileOperator.Write();
                //fileOperator.ReadUsingCustomBuffer();
                //fileOperator.ReadUsingBufferedStream();
                //fileOperator.ProcessUsingMemoryStream();

                //Console.WriteLine("==================================" +
                //                  "\nAsynchronous File operations" +
                //                  "\n==================================");
                //AsynchronousFileOperator asynchronousFileOperator = new AsynchronousFileOperator(inputFilePath, destinationFilePath);
                //await asynchronousFileOperator.Write();
                //await Task.WhenAll(asynchronousFileOperator.ReadUsingBufferedStream(), asynchronousFileOperator.ReadUsingCustomBuffer(), asynchronousFileOperator.ProcessUsingMemoryStream());

                //Console.WriteLine("==================================" +
                //                  "\n      Optimizing stream" +
                //                  "\n==================================");
                //StreamOptimizer streamOptimizer = new StreamOptimizer(dummyFilePath);
                //streamOptimizer.OptimizeStream();

                Console.WriteLine("==================================" +
                                  "\n     Logger Implementation" +
                                  "\n==================================");

                Logger logger = new Logger();
                logger.LogError("Error occurred on authentication");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access denied to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}