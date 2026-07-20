namespace AssignmentTwo
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// To check if its a number
        /// </summary>
        /// <param name="number">string num</param>
        /// <param name="res">res to be outed</param>
        /// <returns>bool</returns>
        public static bool IsNumber(string number, out double res)
        {
            if (double.TryParse(number, out res))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check Valid color or not
        /// </summary>
        /// <param name="word">color</param>
        /// <returns> bool </returns>
        public static bool IsValidWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return word.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }
}
