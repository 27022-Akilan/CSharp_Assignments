using System.Text;

namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the stack implementation to reverse a string.
    /// </summary>
    public class StackImplementation
    {
        private Stack<char> _stringCharacters = new Stack<char>();

        /// <summary>
        /// Reverses a string by pushing and popping from the stack.
        /// </summary>
        public void PerformOperations()
        {
            Console.WriteLine("==============================================" +
                              "\n Stack implementation to reverse a word" +
                              "\n==============================================");
            string word = "Hello";
            this.PushToStack(word);
            string reversedWord = this.PopFromStack();
            Console.WriteLine($"The reversed word of {word} is {reversedWord}");
        }

        /// <summary>
        /// Pushes each character of string into the stack.
        /// </summary>
        /// <param name="word">Characters of the word to be pushed into stack.</param>
        private void PushToStack(string word)
        {
            foreach (char c in word)
            {
                this._stringCharacters.Push(c);
            }
        }

        /// <summary>
        /// Pops each character in the stack and builds the reversed string.
        /// </summary>
        /// <returns>Reversed string.</returns>
        private string PopFromStack()
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in this._stringCharacters)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
