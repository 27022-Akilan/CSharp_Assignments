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
        /// <param name="args">Default arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                string inputFilePath = @"SampleData.txt";
                string destinationFilePath = @"OutputFile.txt";
                FileOperator fileOperator = new FileOperator(inputFilePath, destinationFilePath);

                fileOperator.Write();
                fileOperator.ReadUsingBufferedStream();
                fileOperator.ReadUsingCustomBuffer();
                fileOperator.ProcessUsingMemoryStream();
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