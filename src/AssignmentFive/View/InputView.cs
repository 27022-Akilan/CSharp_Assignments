using AssignmentFive.Constants;
using AssignmentFive.Model.Enums;
using AssignmentFive.Service;

namespace AssignmentFive.View
{
    /// <summary>Gui
    /// Gets the User input and Validate
    /// </summary>
    public class InputView
    {
        private const int MaxTries = Value.MaximumTries;

        private readonly TransactionService _service;

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
        public bool TryReadDecimal(string prompt, out decimal amount)
        {
            amount = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    bool validationResult = this._service.IsValidAmount(amount);
                    if (validationResult)
                    {
                        return true;
                    }

                    Helper.DisplayWarningMessage($"Your amount cant be less than or equal to zero\nTries Left : {MaxTries - i}");
                }
                else
                {
                    Helper.DisplayWarningMessage($"Your input Should contains number only! \nTries Left : {MaxTries - i}");
                }
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid Description.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="description">validated description.</param>
        /// <returns>True - Got Valid description | False - Cannot get a valid description.</returns>
        public bool TryReadDescription(string prompt, out string description)
        {
            description = string.Empty;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(prompt);
                description = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(description))
                {
                    return true;
                }

                Helper.DisplayWarningMessage($"The description can't be Empty or Whitespace\nTries Left : {MaxTries - i}");
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid date.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="date">validated date.</param>
        /// <returns>True - Got Valid date | False - Cannot get a valid date.</returns>
        public bool TryReadDate(string prompt, out DateOnly date)
        {
            date = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(prompt);
                string dateString = Console.ReadLine() ?? string.Empty;
                if (DateOnly.TryParse(dateString, out date))
                {
                    if (this._service.IsValidDate(date))
                    {
                        return true;
                    }

                    Helper.DisplayWarningMessage($"Invalid date : you input date should be less than or equal to current date." +
                                                 $"\nTries Left : {MaxTries - i}");
                }
                else
                {
                    Helper.DisplayWarningMessage($"Invalid date format. Please enter as DD/MM/YYYY" +
                                                $"\nTries Left : {MaxTries - i}");
                }
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid 1-based index within the given range.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="max">Maximum valid index (inclusive, 1-based).</param>
        /// <param name="index">Validated index.</param>
        /// <returns>True - Got Valid index | False - Cannot get a valid index.</returns>
        public bool TryReadSerialNumber(string prompt, int max, out int index)
        {
            index = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(prompt);
                string indexString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(indexString, out index) && index >= 1 && index <= max)
                {
                    return true;
                }

                Helper.DisplayWarningMessage($"Invalid Serial Number. Please enter a number between 1 and {max}.\nTries Left : {MaxTries - i}");
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid Source.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="source">validated source.</param>
        /// <returns>True - Got Valid source | False - Cannot get a valid source.</returns>
        public bool TryReadSource(string prompt, out Source source)
        {
            source = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(
                    prompt +
                    "\n==========================" +
                    "\n1. Salary" +
                    "\n2. Freelance" +
                    "\n3. Investment" +
                    "\n4. Gift" +
                    "\n5. Other" +
                    "\n==========================");
                Console.Write("Enter choice: ");
                string choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out int choice) && Enum.IsDefined(typeof(Source), choice))
                {
                    source = (Source)choice;
                    return true;
                }

                Helper.DisplayWarningMessage($"Your input should be a valid source number!\nTries Left : {MaxTries - i}");
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid Category.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="category">validated category.</param>
        /// <returns>True - Got Valid category | False - Cannot get a valid category.</returns>
        public bool TryReadCategory(string prompt, out Category category)
        {
            category = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(
                    prompt +
                    "\n1. Food" +
                    "\n2. Travel" +
                    "\n3. Utilities" +
                    "\n4. Entertainment" +
                    "\n5. Other");
                Console.Write("Enter choice: ");
                string choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out int choice) && Enum.IsDefined(typeof(Category), choice))
                {
                    category = (Category)choice;
                    return true;
                }

                Helper.DisplayWarningMessage($"Your input should be a valid category number!\nTries Left : {MaxTries - i}");
            }

            return false;
        }

        /// <summary>
        /// Try's to read a valid Type.
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user.</param>
        /// <param name="type">Validated type.</param>
        /// <returns>True - Got Valid type | False - Cannot get a valid type.</returns>
        public bool TryReadType(string prompt, out TransactionType type)
        {
            type = default;
            for (int i = 1; i <= MaxTries; i++)
            {
                Console.WriteLine(
                    prompt +
                    "\n1. Income" +
                    "\n2. Expense");
                Console.Write("Enter choice: ");
                string choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out int choice) && Enum.IsDefined(typeof(TransactionType), choice))
                {
                    type = (TransactionType)choice;
                    return true;
                }

                Helper.DisplayWarningMessage($"Your input should be a valid type number!\nTries Left : {MaxTries - i}");
            }

            return false;
        }
    }
}
