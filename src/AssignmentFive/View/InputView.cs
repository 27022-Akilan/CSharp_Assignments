using AssignmentFive.Constants;
using AssignmentFive.Model.Enums;
using AssignmentFive.Service;

namespace AssignmentFive.View
{
    /// <summary>
    /// Gets the User input and Validate
    /// </summary>
    public class InputView
    {
        private const int MaxTries = Value.MaximumTries;

        private readonly TransactionService _service;

        // Custom delegate: For parser having out Parameter.
        private delegate bool TryParser<T>(string input, out T value);

        /// <summary>
        /// Groups the two warning messages that always travel together for a given field.
        /// </summary>
        /// <param name="parseError">Shown when the raw input cannot be parsed into T.</param>
        /// <param name="validationError">Shown when parsing succeeds but the value fails validation.</param>
        private readonly record struct ValidationMessages(string parseError, string validationError);

        /// <summary>
        /// Initializes a new instance of the <see cref="InputView"/> class
        /// </summary>
        /// <param name="service">Service instance</param>
        public InputView(TransactionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Try's to read a valid Amount.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="amount">validated amount.</param>
        /// <returns>True - Got Valid Amount | False - Cannot get a valid Amount.</returns>
        public bool TryReadDecimal(string prompt, out decimal amount) =>
            this.TryReadValidated(
                prompt,
                decimal.TryParse,
                this._service.IsValidAmount,
                new ValidationMessages(Messages.InvalidAmountFormat, Messages.ValidationErrorOnAmount),
                out amount);

        /// <summary>
        /// Try's to read a valid Description.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="description">validated description.</param>
        /// <returns>True - Got Valid description | False - Cannot get a valid description.</returns>
        public bool TryReadDescription(string prompt, out string description) =>

            this.TryReadValidated<string>(
                prompt,
                (string input, out string value) =>
                {
                    value = input;
                    return true;
                },
                d => !string.IsNullOrWhiteSpace(d),
                new ValidationMessages(string.Empty, Messages.ValidationErrorOnDescription), // ParseError never hit: parser above always returns true
                out description);

        /// <summary>
        /// Try's to read a valid date.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="date">validated date.</param>
        /// <returns>True - Got Valid date | False - Cannot get a valid date.</returns>
        public bool TryReadDate(string prompt, out DateOnly date) =>
            this.TryReadValidated(
                prompt,
                DateOnly.TryParse,
                this._service.IsValidDate,
                new ValidationMessages(Messages.InvalidDateFormat, Messages.ValidationErrorOnDate),
                out date);

        /// <summary>
        /// Try's to read a valid 1-based index within the given range.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="max">Maximum valid index (inclusive, 1-based).</param>
        /// <param name="index">Validated index.</param>
        /// <returns>True - Got Valid index | False - Cannot get a valid index.</returns>
        public bool TryReadSerialNumber(string prompt, int max, out int index)
        {
            string message = $"Invalid Serial Number. Please enter a number between 1 and {max}.";
            return this.TryReadValidated(
                prompt,
                (string input, out int value) => int.TryParse(input, out value),
                value => value >= 1 && value <= max,
                new ValidationMessages(message, message),
                out index);
        }

        /// <summary>
        /// Try's to read a valid Source.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="source">validated source.</param>
        /// <returns>True - Got Valid source | False - Cannot get a valid source.</returns>
        public bool TryReadSource(string prompt, out Source source) =>
            this.TryReadEnum(
                prompt +
                "\n==========================" +
                "\n1. Salary" +
                "\n2. Freelance" +
                "\n3. Investment" +
                "\n4. Gift" +
                "\n5. Other" +
                "\n==========================",
                out source);

        /// <summary>
        /// Try's to read a valid Category.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="category">validated category.</param>
        /// <returns>True - Got Valid category | False - Cannot get a valid category.</returns>
        public bool TryReadCategory(string prompt, out Category category) =>
            this.TryReadEnum(
                prompt +
                "\n1. Food" +
                "\n2. Travel" +
                "\n3. Utilities" +
                "\n4. Entertainment" +
                "\n5. Other",
                out category);

        /// <summary>
        /// Try's to read a valid Type.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="type">Validated type.</param>
        /// <returns>True - Got Valid type | False - Cannot get a valid type.</returns>
        public bool TryReadType(string prompt, out TransactionType type) =>
            this.TryReadEnum(
                prompt +
                "\n1. Income" +
                "\n2. Expense",
                out type);

        /// <summary>
        /// Generic read-validate-retry loop for enum menu choices.
        /// </summary>
        /// <typeparam name="T">The enum type to parse the choice into.</typeparam>
        /// <param name="menuText">Full prompt including the printed menu options.</param>
        /// <param name="result">The validated enum value, if successful.</param>
        /// <returns>True if a valid enum choice was read within MaxTries; otherwise false.</returns>
        private bool TryReadEnum<T>(string menuText, out T result)
            where T : struct, Enum
        {
            result = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(menuText);
                Console.Write("Enter choice: ");
                string choiceString = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(choiceString, out int choice) && Enum.IsDefined(typeof(T), choice))
                {
                    result = (T)(object)choice; // box through object: can't cast int -> T directly under an Enum constraint
                    return true;
                }

                Helper.DisplayWarningMessage($"Your input should be a valid {typeof(T).Name.ToLower()} number!\nTries Left : {MaxTries - i}");
            }

            return false;
        }

        /// <summary>
        /// Generic read-validate-retry loop.
        /// </summary>
        /// <typeparam name="T">The type being parsed (decimal, DateOnly, int, string...).</typeparam>
        /// <param name="prompt">Prompt shown to the user.</param>
        /// <param name="parse">Delegate that attempts to parse the raw input into T.</param>
        /// <param name="isValid">Delegate that checks business-rule validity of the parsed value.</param>
        /// <param name="messages">The parse-error and validation-error messages for this field.</param>
        /// <param name="result">The validated value, if successful.</param>
        /// <returns>True if a valid value was read within MaxTries; otherwise false.</returns>
        private bool TryReadValidated<T>(
            string prompt,
            TryParser<T> parse,
            Func<T, bool> isValid,
            ValidationMessages messages,
            out T result)
        {
            result = default!;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (parse(input, out result))
                {
                    if (isValid(result))
                    {
                        return true;
                    }

                    Helper.DisplayWarningMessage($"{messages.validationError}\nTries Left : {MaxTries - i}");
                }
                else
                {
                    Helper.DisplayWarningMessage($"{messages.parseError}\nTries Left : {MaxTries - i}");
                }
            }

            return false;
        }
    }
}
