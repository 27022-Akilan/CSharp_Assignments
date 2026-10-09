using Contract;

namespace Assignments
{
    /// <inheritdoc/>
    public class EncryptionServiceA : IPlugin
    {
        /// <inheritdoc/>
        public string Encryption(string textMessage)
        {
            return textMessage + 'a';
        }

        /// <inheritdoc/>
        public string Decryption(string textMessage)
        {
            return textMessage.Substring(0, textMessage.Length - 1);
        }
    }
}