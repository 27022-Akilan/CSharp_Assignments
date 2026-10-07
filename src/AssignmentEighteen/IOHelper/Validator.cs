namespace AssignmentEighteen.IOHelper
{
    /// <summary>
    /// Represents the validation rules.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates the enumoption.
        /// </summary>
        /// <typeparam name="T">Generic value.</typeparam>
        /// <param name="input">Choice entered by the user.</param>
        /// <returns>Tuple consists of the validation success boolean,validated option,validation result message.</returns>
        public static (bool IsSuccess, T Value, string Message) ValidateEnumOption<T>(string input)
            where T : struct, Enum
        {
            var (isSuccess, value, message) = ParseEnum<T>(input);
            if (!isSuccess)
            {
                return (false, default, message);
            }

            if (!Enum.IsDefined<T>(value))
            {
                return (false, default, "Enter one of the options shown on the screen");
            }

            return (true, value, "success");
        }

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T">Generic value.</typeparam>
        /// <param name="input">Choice entered by the user.</param>
        /// <returns>Parsed value.</returns>
        public static (bool IsSuccess, T Value, string Message) ParseEnum<T>(string input)
            where T : struct, Enum
        {
            if (!Enum.TryParse<T>(input, true, out T result))
            {
                return (false, default, "Not a valid option");
            }

            return (true, result, "success");
        }
    }
}
