using System.Diagnostics;
using System.Text;

namespace AssignmentFifteen
{
    /// <summary>
    /// Represents the operations on the file.
    /// </summary>
    public class FileOperator
    {
        private readonly string _inputFilePath;
        private readonly string _destinationFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperator"/> class.
        /// </summary>
        /// <param name="inputFilePath">Relative path of the file.</param>
        /// <param name="destinationFilePath">Relative path of the destination file.</param>
        public FileOperator(string inputFilePath, string destinationFilePath)
        {
            this._inputFilePath = inputFilePath;
            this._destinationFilePath = destinationFilePath;
        }

        /// <summary>
        /// Writes the data into the file using FileStreamer.
        /// </summary>
        /// <returns>A Task object</returns>
        public async Task Write()
        {
            const long oneGB = 1024 * 1024 * 1024;
            string data = "\nHii Buddy lets learn C#, Have a nice day.";
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            // byte[] bytes = new byte[1024 * 1024];
            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read, bufferSize: 1024 * 1024, true);
            Console.WriteLine("Writing into the file Started !!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long totalBytes = 0;
            while (totalBytes < oneGB)
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
                totalBytes += bytes.Length;
            }

            stopwatch.Stop();
            Console.WriteLine("Writing into the file Completed !!");
            Console.WriteLine($"Time taken to write into the file is : " +
                              $"{stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        /// <returns>A task object.</returns>
        public async Task ReadUsingCustomBuffer()
        {
            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024 * 1024, true);
            byte[] bytes = new byte[8];

            Console.WriteLine("Reading using the custom buffer started !!");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (await fileStream.ReadAsync(bytes, 0, bytes.Length) > 0)
            {
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a custom buffer is : " +
                              $"{stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        /// <returns>A task object</returns>
        public async Task ReadUsingBufferedStream()
        {
            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024 * 1024, true);
            using BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = new byte[8];

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Reading using the Buffered stream started !!");
            stopwatch.Start();
            while (await bufferedStream.ReadAsync(bytes, 0, bytes.Length) > 0)
            {
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a buffered stream is : " +
                              $"{stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// To process the file contents taken from the file and process and put into other file.
        /// </summary>
        /// <returns>A task object.</returns>
        public async Task ProcessUsingMemoryStream()
        {
            int available;
            using FileStream inputFile = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1024 * 1024, true);
            using FileStream destinationFile = new FileStream(this._destinationFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read, bufferSize: 1024 * 1024, true);

            byte[] buffer = new byte[25 * 1024]; // 25 kb

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing on the file contents and writing started !!");
            stopwatch.Start();
            while ((available = await inputFile.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                using MemoryStream memoryStream = new MemoryStream();
                buffer = this.ProcessData(buffer, available);
                await memoryStream.WriteAsync(buffer, 0, available);
                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(destinationFile);
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken to read process and write into a file is using Memory stream: " +
                              $"{stopwatch.Elapsed.TotalMilliseconds}");
        }

        private byte[] ProcessData(byte[] buffer, int readLength)
        {
            for (int i = 0; i < readLength; i++)
            {
                buffer[i] = (byte)char.ToUpper((char)buffer[i]);
            }

            return buffer;
        }
    }
}
