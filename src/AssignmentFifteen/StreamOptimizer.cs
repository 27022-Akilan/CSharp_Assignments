using System.Text;

namespace AssignmentFifteen
{
    /// <summary>
    /// Represents to optimize the stream operations.
    /// </summary>
    public class StreamOptimizer
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamOptimizer"/> class.
        /// </summary>
        /// <param name="filePath">path of the file</param>
        public StreamOptimizer(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Optimizes the memory stream.
        /// </summary>
        public void OptimizeStream()
        {
            string data = "This is some test data";

            // To write
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            using (FileStream fileStream = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }

            // To Read
            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open))
            {
                byte[] readBuffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    Console.Write(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));
                }
            }
        }
    }
}
