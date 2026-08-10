using AssignmentFour.Model;
using AssignmentFour.Model.Enums;
using AssignmentFour.Service;
using ConsoleTables;

namespace AssignmentFour.View
{
    /// <summary>
    /// To view the Expense Tracker Application
    /// </summary>
    public class TransactionView
    {
        private const int MaxTries = 3;

        private readonly InputView _getValidInput;

        private readonly TransactionService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionView"/> class
        /// </summary>
        /// <param name="service">Instance of the Service Layer</param>
        /// <param name="getValidInput">Instance of the Input view Layer</param>
        public TransactionView(TransactionService service, InputView getValidInput)
        {
            this._service = service;
            this._getValidInput = getValidInput;
        }

        /// <summary>
        /// Starts to run the view
        /// </summary>
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                this.DisplayMenu();
                string choiceAsString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceAsString, out int choice))
                {
                    MenuOption option = (MenuOption)choice;
                    switch (option)
                    {
                        case MenuOption.AddIncome:
                            this.HandleIncome();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.AddExpense:
                            this.HandleExpense();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.UpdateTransaction:
                            this.UpdateTransaction();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.DeleteTransaction:
                            this.DeleteTransaction();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.SearchTransaction:
                            this.SearchTransaction();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.ShowTransactions:
                            this.ShowTransactions();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.ShowSummary:
                            this.ShowSummary();
                            Helper.PressKeyToContinue();
                            break;
                        case MenuOption.Exit:
                            exit = true;
                            break;
                        default:
                            Helper.DisplayWarningMessage("Invalid Choice. Please enter a number between 1 and 8.");
                            Helper.PressKeyToContinue();
                            break;
                    }
                }
                else
                {
                    Helper.DisplayWarningMessage("Invalid input. Please enter a number between 1 and 8.");
                    Helper.PressKeyToContinue();
                }
            }
        }

        /// <summary>
        /// Displays the main menu
        /// </summary>
        public void DisplayMenu()
        {
            Helper.DisplayInfoMessage("\t\t\t\t\tTrack Every Rupee and Grow Every Dream");
            Console.WriteLine(
                "\n===============================================" +
                "\n1.Add Income" +
                "\n2.Add Expense" +
                "\n3.Edit Transaction" +
                "\n4.Delete Transaction" +
                "\n5.Search Transaction" +
                "\n6.Display All Transactions" +
                "\n7.Display Summary" +
                "\n8.Exit" +
                "\n===============================================" +
                "\nEnter Your Choice:");
        }

        /// <summary>
        /// Handles adding an Income transaction
        /// </summary>
        public void HandleIncome()
        {
            if (!this.TryReadCommonFields(
                "Enter the Amount for Income:",
                "Enter the description for the Income:",
                "Enter the Date(DD/MM/YYYY)",
                out decimal amount,
                out string description,
                out DateOnly date))
            {
                return;
            }

            Source source;
            if (!this._getValidInput.TryReadSource("Enter the source of the income :", out source))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            Income income = new Income(Guid.Empty, amount, description, date, source);
            string result = this._service.AddTransaction(income);

            if (result == Messages.AddSuccess)
            {
                Helper.DisplaySuccessMessage(result);
            }
            else
            {
                Helper.DisplayErrorMessage(result);
            }
        }

        /// <summary>
        /// Handles adding an Expense transaction
        /// </summary>
        public void HandleExpense()
        {
            if (!this.TryReadCommonFields(
                "Enter the Amount for Expense:",
                "Enter the description for the Expense:",
                "Enter the Date(DD/MM/YYYY)",
                out decimal amount,
                out string description,
                out DateOnly date))
            {
                return;
            }

            Category category;
            if (!this._getValidInput.TryReadCategory("Enter the category of the Expense :", out category))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            Expense expense = new Expense(Guid.Empty, amount, description, date, category);
            string result = this._service.AddTransaction(expense);

            if (result == Messages.AddSuccess)
            {
                Helper.DisplaySuccessMessage(result);
            }
            else
            {
                Helper.DisplayErrorMessage(result);
            }
        }

        /// <summary>
        /// Updates an existing transaction. Asks Y/N per field for editing.
        /// </summary>
        public void UpdateTransaction()
        {
            List<Transaction> transactions = this._service.GetAllTransactions().ToList();
            if (transactions.Count == 0)
            {
                Helper.DisplayInfoMessage("No transactions available to update.");
                return;
            }

            this.DisplayTransaction(transactions);

            int index;
            if (!this._getValidInput.TryReadSerialNumber("Enter the Serial number of the Transaction to Update:", transactions.Count, out index))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            Transaction target = transactions[index - 1];
            Guid id = target.TransactionId;

            // Amount
            decimal amount = target.Amount;
            if (this.AskToUpdate("Amount", target.Amount.ToString()))
            {
                if (!this._getValidInput.TryReadDecimal("Enter the new Amount:", out amount))
                {
                    Helper.DisplayAbortMessage();
                    return;
                }
            }

            // Description
            string description = target.Description;
            if (this.AskToUpdate("Description", target.Description))
            {
                if (!this._getValidInput.TryReadDescription("Enter the new description:", out description))
                {
                    Helper.DisplayAbortMessage();
                    return;
                }
            }

            // Date
            DateOnly date = target.Date;
            if (this.AskToUpdate("Date", target.Date.ToString("dd/MM/yyyy")))
            {
                if (!this._getValidInput.TryReadDate("Enter the new Date(DD/MM/YYYY):", out date))
                {
                    Helper.DisplayAbortMessage();
                    return;
                }
            }

            // Source | Category
            Transaction updatedTransaction;
            if (target is Income income)
            {
                Source source = income.Source;
                if (this.AskToUpdate("Source", income.Source.ToString()))
                {
                    if (!this._getValidInput.TryReadSource("Enter the new source of the income:", out source))
                    {
                        Helper.DisplayAbortMessage();
                        return;
                    }
                }

                updatedTransaction = new Income(id, amount, description, date, source);
            }
            else if (target is Expense expense)
            {
                Category category = expense.Category;
                if (this.AskToUpdate("Category", expense.Category.ToString()))
                {
                    if (!this._getValidInput.TryReadCategory("Enter the new category of the Expense:", out category))
                    {
                        Helper.DisplayAbortMessage();
                        return;
                    }
                }

                updatedTransaction = new Expense(id, amount, description, date, category);
            }
            else
            {
                Helper.DisplayErrorMessage("Unknown transaction type. Cannot update.");
                return;
            }

            bool success = this._service.Update(updatedTransaction);
            if (success)
            {
                Helper.DisplaySuccessMessage("Transaction updated successfully.");
            }
            else
            {
                Helper.DisplayErrorMessage("Failed to update transaction.");
            }
        }

        /// <summary>
        /// Displays the search options for transactions
        /// </summary>
        public void SearchTransaction()
        {
            Console.WriteLine("Search By:" +
                              "\n1. Type (Income/Expense)" +
                              "\n2. Amount" +
                              "\n3. Description" +
                              "\n4. Date" +
                              "\n5.Exit" +
                              "\nEnter your choice (1-5):");

            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choice))
            {
                TransactionSearchOption searchOption = (TransactionSearchOption)choice;

                switch (searchOption)
                {
                    case TransactionSearchOption.ByType:
                        this.SearchByType();
                        break;
                    case TransactionSearchOption.ByAmount:
                        this.SearchByAmount();
                        break;
                    case TransactionSearchOption.ByDescription:
                        this.SearchByDescription();
                        break;
                    case TransactionSearchOption.ByDate:
                        this.SearchByDate();
                        break;
                    case TransactionSearchOption.Exit:
                        return;
                    default:
                        Helper.DisplayWarningMessage("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        /// <summary>
        /// Searches transactions by their type (Income or Expense) and displays the results.
        /// </summary>
        public void SearchByType()
        {
            if (!this._getValidInput.TryReadType("Enter the type of transaction to search (Income/Expense):", out TransactionType type))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            IEnumerable<Transaction> result = this._service.GetTransactionsByType(type);
            if (!result.Any())
            {
                Helper.DisplayInfoMessage($"No transactions found for type: {type}");
                return;
            }

            this.DisplayTransaction(result);
        }

        /// <summary>
        /// Searches transactions by their amount and displays the results.
        /// </summary>
        public void SearchByAmount()
        {
            if (!this._getValidInput.TryReadDecimal("Enter the amount for transaction to search:", out decimal amount))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            IEnumerable<Transaction> result = this._service.GetTransactionsByAmount(amount);
            if (!result.Any())
            {
                Helper.DisplayInfoMessage($"No transactions found for amount: {amount}");
                return;
            }

            this.DisplayTransaction(result);
        }

        /// <summary>
        /// Searches transactions by their date and displays the results.
        /// </summary>
        public void SearchByDescription()
        {
            if (!this._getValidInput.TryReadDescription("Enter the Description of the Transaction to be search:", out string description))
            {
                Helper.DisplayErrorMessage("Abotying due to maximum invalid tries attempted");
                return;
            }

            IEnumerable<Transaction> transaction = this._service.GetTransactionsByDescription(description);
            if (!transaction.Any())
            {
                Helper.DisplayInfoMessage($"No transactions found for description: {description}");
                return;
            }

            this.DisplayTransaction(transaction);
        }

        /// <summary>
        /// Searches transactions by their date and displays the results.
        /// </summary>
        public void SearchByDate()
        {
            if (!this._getValidInput.TryReadDate("Enter the date for transaction to search:", out DateOnly date))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            IEnumerable<Transaction> result = this._service.GetTransactionByDate(date);
            this.DisplayTransaction(result);
        }

        /// <summary>
        /// Deletes an existing transaction selected by index
        /// </summary>
        public void DeleteTransaction()
        {
            List<Transaction> transactions = this._service.GetAllTransactions().ToList();
            if (transactions.Count == 0)
            {
                Helper.DisplayInfoMessage("No transactions available to delete.");
                return;
            }

            this.DisplayTransaction(transactions);

            int index;
            if (!this._getValidInput.TryReadSerialNumber("Enter the Serial Number of the Transaction to Delete:", transactions.Count, out index))
            {
                Helper.DisplayAbortMessage();
                return;
            }

            Transaction target = transactions[index - 1];
            bool success = this._service.DeleteTransactionById(target.TransactionId);
            if (success)
            {
                Helper.DisplaySuccessMessage("Transaction deleted successfully.");
            }
            else
            {
                Helper.DisplayErrorMessage("Failed to delete transaction.");
            }
        }

        /// <summary>
        /// Shows the all the transaction.
        /// </summary>
        public void ShowTransactions()
        {
            IEnumerable<Transaction> transactions = this._service.GetAllTransactions();
            if (transactions.Count() == 0)
            {
                Helper.DisplayInfoMessage("No Transactions available to show");
                return;
            }

            this.DisplayTransaction(transactions);
        }

        /// <summary>
        /// Shows the summary of all the transaction.
        /// </summary>
        public void ShowSummary()
        {
            var summary = this._service.GetSummary();

            Console.WriteLine("================= Summary =================" +
                              $"\nTotal Income: {summary.TotalIncome}" +
                              $"\nTotal Expense: {summary.TotalExpense}" +
                              $"\nNet Balance: {summary.NetBalance}" +
                              $"\nTotal Transactions: {summary.TotalTransactions}" +
                              $"\nAverage Transaction Value: {summary.AverageTransactionValue:F2}");
        }

        /// <summary>
        /// To display the transaction in table format
        /// </summary>
        /// <param name="resultTransaction">Immutable List of Objects</param>
        public void DisplayTransaction(IEnumerable<Transaction> resultTransaction)
        {
            ConsoleTable table = new ConsoleTable("S.No", "Amount", "Description", "Date", "Type", "Source/Category");
            int serialNumber = 1;
            foreach (Transaction transaction in resultTransaction)
            {
                if (transaction is Income)
                {
                    table.AddRow(serialNumber++, transaction.Amount, transaction.Description, transaction.Date, transaction.TransactionType, ((Income)transaction).Source);
                }
                else if (transaction is Expense)
                {
                    table.AddRow(serialNumber++, transaction.Amount, transaction.Description, transaction.Date, transaction.TransactionType, ((Expense)transaction).Category);
                }
            }

            table.Write();
        }

        /// <summary>
        /// Reads the three fields common to every transaction: Amount, Description, and Date.
        /// </summary>
        /// <param name="amountPrompt">Prompt to display when asking for the amount.</param>
        /// <param name="descriptionPrompt">Prompt to display when asking for the description.</param>
        /// <param name="datePrompt">Prompt to display when asking for the date.</param>
        /// <param name="amount">Validated amount output.</param>
        /// <param name="description">Validated description output.</param>
        /// <param name="date">Validated date output.</param>
        /// <returns>True if all three fields were collected successfully; otherwise false.</returns>
        public bool TryReadCommonFields(string amountPrompt, string descriptionPrompt, string datePrompt, out decimal amount, out string description, out DateOnly date)
        {
            description = string.Empty;
            date = default;

            if (!this._getValidInput.TryReadDecimal(amountPrompt, out amount))
            {
                Helper.DisplayAbortMessage();
                return false;
            }

            if (!this._getValidInput.TryReadDescription(descriptionPrompt, out description))
            {
                Helper.DisplayAbortMessage();
                return false;
            }

            if (!this._getValidInput.TryReadDate(datePrompt, out date))
            {
                Helper.DisplayAbortMessage();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Asks the user whether they want to update a specific field.
        /// </summary>
        /// <param name="fieldName">Name of the field shown to the user.</param>
        /// <param name="currentValue">The current value of the field shown alongside the prompt.</param>
        /// <returns>True if the user enters Y or y; false otherwise (field is kept as-is).</returns>
        private bool AskToUpdate(string fieldName, string currentValue)
        {
            Console.WriteLine($"Update {fieldName}? (Current: {currentValue}) [Y/N]:");
            string input = Console.ReadLine() ?? string.Empty;
            if (input.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Trim().Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Helper.DisplayErrorMessage("Invalid choice cant edit the current field");
                return false;
            }
        }
    }
}