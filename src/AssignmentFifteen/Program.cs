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
                string inputFilePath = @"SampleData.txt";
                string destinationFilePath = @"OutputFile.txt";
                FileOperator fileOperator = new FileOperator(inputFilePath, destinationFilePath);

                await fileOperator.Write();
                await Task.WhenAll(fileOperator.ReadUsingBufferedStream(), fileOperator.ReadUsingCustomBuffer(), fileOperator.ProcessUsingMemoryStream());
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