namespace Contract
{
    /// <summary>
    /// Represents the contract for managing encryption and decryption operations.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Encrypts the text message.
        /// </summary>
        /// <param name="textMessage">Message to be encrypted.</param>
        /// <returns>Encrypted text message.</returns>
        public string Encryption(string textMessage);

        /// <summary>
        /// Decrypts the text message.
        /// </summary>
        /// <param name="textMessage">Message to be decrypted</param>
        /// <returns>Decrypted text message.</returns>
        public string Decryption(string textMessage);
    }
}
