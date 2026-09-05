namespace IDisposableDemo
{
    /// <summary>
    /// Represents the file operations.
    /// </summary>
    public class FileOperator : IDisposable
    {
        private StreamWriter _writer;
        private string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperator"/> class.
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        public FileOperator(string filePath)
        {
            this._filePath = filePath;
            this._writer = new StreamWriter(this._filePath);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._writer.Close();
            Console.WriteLine("\n\nThe file was closed automatically.");
        }

        /// <summary>
        /// To write on to the file.
        /// </summary>
        /// <param name="content">Content to written on the file.</param>
        public void Write(string content)
        {
            this._writer.WriteLine(content);
            this._writer.Flush();
            Console.WriteLine($"Content : {content} written into the file location : {this._filePath}.");
        }
    }
}
