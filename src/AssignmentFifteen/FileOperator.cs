using System.Diagnostics;
using System.Text;

namespace AssignmentFifteen
{
    /// <summary>
    /// Represents the operations on the file.
    /// </summary>
    public class FileOperator
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperator"/> class.
        /// </summary>
        /// <param name="filePath">Relative path of the file.</param>
        public FileOperator(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Writes the data into the file using FileStreamer.
        /// </summary>
        public void Write()
        {
            string data = "This is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\nThis is safe placeholder text for upload, parser, and QA testing.\r\n";

            byte[] bytes = Encoding.UTF8.GetBytes(data);

            using FileStream fileStream = new FileStream(this._filePath, FileMode.OpenOrCreate, FileAccess.Write);
            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            Console.WriteLine("Writing into the file Started !!");
            for (int i = 0; i < 100000; i++)
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }

            stopWatch.Stop();
            Console.WriteLine("Writing into the file Completed !!");
            Console.WriteLine($"Time taken to write into the file is : {stopWatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        public void ReadUsingCustomBuffer()
        {
            using FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[1024];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (fileStream.Read(bytes, 0, bytes.Length) > 0)
            {
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a custom buffer is : " +
                              $"{stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Reading the file using the custom buffer.
        /// </summary>
        public void ReadUsingBufferedStream()
        {
            using FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read);
            using BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = new byte[1024];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (bufferedStream.Read(bytes, 0, bytes.Length) > 0)
            {
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken to Read data from file using a buffered stream is : " +
                              $"{stopwatch.ElapsedMilliseconds}");
        }
    }
}
