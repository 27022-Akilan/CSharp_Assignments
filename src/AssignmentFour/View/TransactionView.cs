using AssignmentFour.Model;
using AssignmentFour.Service;

namespace AssignmentFour.View
{
    /// <summary>
    /// To view the Expense Tracker Application
    /// </summary>
    public class TransactionView
    {
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
        /// Displays the Menu to the User
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine(
                "Track Every Rupee and Grow Every Dream" +
                "\n===============================================" +
                "\n1.Add Transaction" +
                "\n2.Edit Transaction" +
                "\n3.Delete Transaction" +
                "\n4.Display All Transactions" +
                "\n===============================================" +
                "\nEnter Your Choice:");

            string choiceAsString = Console.ReadLine() ?? string.Empty;
            int choice;
            if (int.TryParse(choiceAsString, out choice))
            {
                MenuOption option = (MenuOption)choice;
                switch (option)
                {
                    case MenuOption.AddTransaction:
                        Console.WriteLine("Enter E for Expense and I for Income");
                        string transactionType = Console.ReadLine() ?? string.Empty;
                        break;
                }
            }
        }
    }
}
