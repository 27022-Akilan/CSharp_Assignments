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
        private readonly Stopwatch _stopwatch = new Stopwatch();

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
        public void Write()
        {
            const long oneGB = 1024 * 1024 * 1024;
            string data = "This is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\n";
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            Console.WriteLine("Writing into the file Started !!");

            this._stopwatch.Start();
            while (true)
            {
                FileInfo fileInfo = new FileInfo(this._inputFilePath);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
                if (fileInfo.Length > oneGB)
                {
                    break;
                }
            }

            this._stopwatch.Stop();
            Console.WriteLine("Writing into the file Completed !!");
            Console.WriteLine($"Time taken to write into the file is : " +
                              $"{this._stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        public void ReadUsingCustomBuffer()
        {
            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[8];

            this._stopwatch.Start();
            while (fileStream.Read(bytes, 0, bytes.Length) > 0)
            {
            }

            this._stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a custom buffer is : " +
                              $"{this._stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        public void ReadUsingBufferedStream()
        {
            using FileStream fileStream = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read);
            using BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = new byte[8];

            this._stopwatch.Start();
            while (bufferedStream.Read(bytes, 0, bytes.Length) > 0)
            {
            }

            this._stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a buffered stream is : " +
                              $"{this._stopwatch.Elapsed.TotalMilliseconds}");
        }

        /// <summary>
        /// To process the file contents taken from the file and process and put into other file.
        /// </summary>
        public void ProcessUsingMemoryStream()
        {
            int available;
            using FileStream inputFile = new FileStream(this._inputFilePath, FileMode.Open, FileAccess.Read);
            using FileStream destinationFile = new FileStream(this._destinationFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] buffer = new byte[25 * 1024]; // 25 kb

            this._stopwatch.Start();
            while ((available = inputFile.Read(buffer, 0, buffer.Length)) > 0)
            {
                using MemoryStream memoryStream = new MemoryStream();
                buffer = this.ProcessData(buffer, available);
                memoryStream.Write(buffer, 0, available);
                memoryStream.Position = 0;
                memoryStream.CopyTo(destinationFile);
            }

            this._stopwatch.Stop();
            Console.WriteLine($"Time Taken to read process and write into a file is using Memory stream: " +
                              $"{this._stopwatch.Elapsed.TotalMilliseconds}");
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
