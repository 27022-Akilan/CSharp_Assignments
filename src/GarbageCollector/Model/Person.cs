namespace GarbageCollector.Model
{
    /// <summary>
    /// Represents the person information.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets the data of the person (just a byte for seeing the memory allocation.)
        /// </summary>
        /// <value>Data of the person</value>
        public byte[] Data => new byte[1024];
    }
}
