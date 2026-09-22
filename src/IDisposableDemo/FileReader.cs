namespace IDisposableDemo
{
    /// <summary>
    /// Represents the file reader.
    /// </summary>
    public class FileReader : IDisposable
    {
        private string _filePath;

        private StreamReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filePath">File path</param>
        public FileReader(string filePath)
        {
            this._filePath = filePath;
            this._reader = new StreamReader(filePath);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._reader.Dispose();
            Console.WriteLine("\nThe file was closed automatically.");
        }

        /// <summary>
        /// Reads the data from the file.
        /// </summary>
        public void Read()
        {
            Console.WriteLine("Reading the file .....");
            string? line;
            while ((line = this._reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
