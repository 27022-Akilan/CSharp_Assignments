using AssignmentFour.Model;
using AssignmentFour.Service;

namespace AssignmentFour.View
{
    /// <summary>
    /// To view the Expense Tracker Application
    /// </summary>
    public class TransactionView
    {
        private const int MaxTries = 3;

        private readonly TransactionService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionView"/> class
        /// </summary>
        /// <param name="service">Instance of the Service Layer</param>
        public TransactionView(TransactionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts to run the view
        /// </summary>
        public void Run()
        {
            this.DisplayMenu();
            string choiceAsString = Console.ReadLine() ?? string.Empty;
            int choice;
            if (int.TryParse(choiceAsString, out choice))
            {
                MenuOption option = (MenuOption)choice;
                switch (option)
                {
                    case MenuOption.AddIncome:
                        this.HandleIncome();
                        break;
                    case MenuOption.AddExpense:
                        this.HandleExpense();
                        break;
                    case MenuOption.UpdateTransaction:
                        this.UpdateIncome();
                        break;
                    case MenuOption.DeleteTransaction:
                        this.DeleteTransaction();
                        break;
                    case MenuOption.ShowTransaction:
                        this.ShowTransaction();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        this.DisplayMenu();
                        break;
                }
            }
        }

        /// <summary>
        /// To display the main menu
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine(
                "Track Every Rupee and Grow Every Dream" +
                "\n===============================================" +
                "\n1.Add Income" +
                "\n2.Add Expense" +
                "\n3.Edit Transaction" +
                "\n4.Delete Transaction" +
                "\n5.Display All Transactions" +
                "\n===============================================" +
                "\nEnter Your Choice:");
        }

        /// <summary>
        /// Handles adding the Income
        /// </summary>
        public void HandleIncome()
        {
            decimal amount;
            if (!this.TryReadDecimal("Enter the Amount for Income:", out amount))
            {
                this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
                return;
            }

            string description;
            if (!this.TryReadDescription("Enter the description for the Income:", out description))
            {
                this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
                return;
            }

            DateTime date;
            if (!this.TryReadDate("Enter the Date(DD/MM/YYYY)", out date))
            {
                this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
                return;
            }

            string source;
            if (!this.TryReadSource("Enter the source of the income :", out source))
            {
                this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
                return;
            }
        }

        //public void HandleExpense()
        //{
        //    decimal amount;
        //    if (!TryReadDecimal(out amount))
        //    {
        //        this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
        //        return;
        //    }

        //    string description;
        //    if (!TryReadDescription(out description))
        //    {
        //        this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
        //        return;
        //    }

        //    DateTime date;
        //    if (!TryReadDate(out date))
        //    {
        //        this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
        //        return;
        //    }

        //    string source;
        //    if (!TryReadCategory(out source))
        //    {
        //        this.DisplayWarningMessage("Aborting due to maximum invalid tries attempted");
        //        return;
        //    }
        // }

        /// <summary>
        /// Try's to read a valid Amount
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user</param>
        /// <param name="amount">validated amount</param>
        /// <returns>True - Got Valid Amount | False - Cannot get a valid Amount</returns>
        public bool TryReadDecimal(string prompt, out decimal amount)
        {
            for (int i = 1; i < MaxTries; i++)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    string validationResult = this._service.IsValidAmount(amount);
                    if (validationResult == string.Empty)
                    {
                        return true;
                    }

                    this.DisplayWarningMessage($"{validationResult}\nTries Left : {MaxTries - i}");
                }
                else
                {
                    this.DisplayWarningMessage($"Your input Should contains number only! \nTries Left : {MaxTries - i}");
                }
            }

            amount = default;
            return false;
        }

        /// <summary>
        /// Try's to read a valid Description
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user</param>
        /// <param name="description">validated description</param>
        /// <returns>True - Got Valid description | False - Cannot get a valid description</returns>
        public bool TryReadDescription(string prompt, out string description)
        {
            for (int i = 1; i < MaxTries; i++)
            {
                Console.WriteLine(prompt);
                description = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description))
                {
                    return true;
                }

                Console.WriteLine("The description cant be Empty or Whitespace");
            }

            description = string.Empty;
            return false;
        }

        /// <summary>
        /// Try's to read a valid date
        /// </summary>
        /// <param name="prompt">Prompt that should be Displayed to user</param>
        /// <param name="date">validated date</param>
        /// <returns>True - Got Valid date | False - Cannot get a valid date</returns>
        public bool TryReadDate(string prompt, out DateTime date)
        {
            for (int i = 1; i < MaxTries; i++)
            {
                Console.WriteLine(prompt);
                string dateString = Console.ReadLine() ?? string.Empty;
                if (DateTime.TryParse(dateString, out date))
                {
                    return true;
                }

                Console.WriteLine("");
            }

            date = default;
            return false;
        }

        public bool TryReadSource(string prompt, out string source)
        {
            for (int i = 1; i < MaxTries; i++)
            {
                Console.WriteLine(prompt);
                string dateString = Console.ReadLine() ?? string.Empty;


                Console.WriteLine("");
            }

            date = default;
            return false;
        }

        /// <summary>
        /// Displays the warning message in yellow color
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public void DisplayWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}