using Contract;

namespace Assignments
{
    /// <inheritdoc/>
    public class EncryptionServiceB : IPlugin
    {
        /// <inheritdoc/>
        public string Encryption(string textMessage)
        {
            return textMessage + 'B';
        }

        /// <inheritdoc/>
        public string Decryption(string textMessage)
        {
            return textMessage.Substring(0, textMessage.Length - 1);
        }
    }
}