using AssignmentTwo.Model.Bank;
using AssignmentTwo.Model.EnumModels;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// To view Account and Account operations
    /// </summary>
    public class BankView
    {
        private BankServices _bankServices = new BankServices();

        /// <summary>
        /// Displays menu for accessing accounts
        /// </summary>
        public void DisplayMenu()
        {
            BankOption optionForBank;
            long accountNumber = 0;
            BankAccount account;
            do
            {
                Console.WriteLine(
                    "\n==================================" +
                    "\n1.Create Savings Account " +
                    "\n2.Create Checking Account " +
                    "\n3.Exit " +
                    "\n==================================" +
                    "\nEnter your Choice:");
                string choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out int choice))
                {
                    optionForBank = (BankOption)choice;
                    switch (optionForBank)
                    {
                        case BankOption.CreateAndViewSavingsAccount:
                            bool getName = Helper.GetName(out string name);
                            if (!getName)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation account due to maximum tries of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(choice);
                            bool getAmount = this.GetAmount(out decimal amount, choice);
                            if (!getAmount)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation of the account due to maximum tries of invalid Initial Deposit");
                                break;
                            }

                            account = new SavingsAccount(name, ++accountNumber, amount);
                            Helper.DisplaySuccessMessage("Savings Account created Successfully");
                            this.DisplaySubMenu(account);
                            break;

                        case BankOption.CreateAndViewCheckingAccount:
                            getName = Helper.GetName(out name);
                            if (!getName)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation of the account due to maximum tries of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(choice);
                            getAmount = this.GetAmount(out amount, choice);
                            if (!getAmount)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation account due to maximum tries of invalid Initial deposit");
                                break;
                            }

                            account = new CheckingAccount(name, ++accountNumber, amount);
                            Helper.DisplaySuccessMessage("Checking Account created Successfully");
                            this.DisplaySubMenu(account);
                            break;

                        case BankOption.Exit:
                            Helper.DisplaySuccessMessage("Exited!!");
                            break;
                        default:
                            Helper.DisplayFailedMessage("Enter Correct Value between 1 to 3");
                            break;
                    }

                    if (choice == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Enter valid number and can be only between (1-3)");
                }
            }
            while (true);
        }

        /// <summary>
        /// Displays menu for operations on the account
        /// </summary>
        /// <param name="account">Account object</param>
        public void DisplaySubMenu(BankAccount account)
        {
            BankOperation bankOperation;
            bool result = true;
            do
            {
                Console.WriteLine(
                    "\nIf you need any more services " +
                    "\n1.Deposit " +
                    "\n2.Withdraw " +
                    "\n3.Print Details " +
                    "\n4.Exit " +
                    "\nEnter your Choice : ");
                string choiceForDepositOrWithdrawalOrGetDetails = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceForDepositOrWithdrawalOrGetDetails, out int numberForDepositOrWithdrawal))
                {
                    bankOperation = (BankOperation)numberForDepositOrWithdrawal;
                    switch (bankOperation)
                    {
                        case BankOperation.Deposit:
                            Console.WriteLine("Deposit chose");

                            this.GetOrPutMoney(account, BankOperation.Deposit);
                            break;
                        case BankOperation.Withdraw:
                            Console.WriteLine("Withdraw chose");

                            this.GetOrPutMoney(account, BankOperation.Withdraw);
                            break;
                        case BankOperation.PrintDetails:
                            Helper.DisplaySuccessMessage(this._bankServices.GetDetails(account));

                            // result = true;
                            break;
                        case BankOperation.Exit:
                            Helper.DisplaySuccessMessage("Exited!!");
                            result = false;
                            break;
                        default:
                            Helper.DisplayFailedMessage("Invalid Choice");

                            // result = true;
                            break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Enter valid number can be only (1 to 4)");
                }
            }
            while (result);
        }

        /// <summary>
        /// To print the initial amount that should be deposited for creating the particular account
        /// </summary>
        /// <param name="accountType">Type of the account (savings or checking)</param>
        public void PrintInitialDepositValue(int accountType)
        {
            if (accountType == 1)
            {
                Console.WriteLine($"The Initial Deposit should be Greater than {BankServices.MinimumInitialDepositForSavingsAccount}");
            }
            else
            {
                Console.WriteLine($"The Initial Deposit should be Greater than {BankServices.MinimumInitialDepositForCheckingAccount}");
            }
        }

        /// <summary>
        /// To withdraw and deposit amount into account
        /// </summary>
        /// <param name="account">Account object</param>
        /// <param name="bankOperation">Choice for deposit or withdraw</param>
        /// <returns>Bool - true if transaction succeeds | false - if transaction fails</returns>
        public bool GetOrPutMoney(BankAccount account, BankOperation bankOperation)
        {
            decimal amount;
            bool getOrPutAmount = this.GetAmountForDepositOrWithdraw(out amount);
            if (getOrPutAmount == true)
            {
                if (bankOperation == BankOperation.Deposit)
                {
                    Helper.DisplaySuccessMessage(this._bankServices.DepositAmount(account, amount));
                    return true;
                }

                // else its Withdraw
                string result = this._bankServices.WithdrawAmount(account, amount);
                if (result == string.Empty)
                {
                    Helper.DisplaySuccessMessage("Withdrawn successfully !");
                    return true;
                }

                Helper.DisplayWarningMessage(result);
                return false;
            }

            return false;
        }

        /// <summary>
        /// To read amount for deposit and withdraw from the user and validate
        /// </summary>
        /// <param name="amount">To return the amount using out parameter</param>
        /// <returns>Bool - true if valid amount | false if invalid amount</returns>
        public bool GetAmountForDepositOrWithdraw(out decimal amount)
        {
            int tries = 3;
            do
            {
                tries -= 1;
                Console.WriteLine("Enter the Amount :");
                string stringAmount = Console.ReadLine() ?? string.Empty;
                if (Helper.IsNumber(stringAmount, out amount) && (amount > 0))
                {
                    return true;
                }

                if (amount <= 0)
                {
                    Helper.DisplayFailedMessage($"Your input should be greater than 0! Number of Tries Left : {tries}\n");
                }
                else
                {
                    Helper.DisplayFailedMessage($"Your input should only contains number! Number of Tries Left : {tries}\n");
                }
            }
            while (tries > 0);
            return false;
        }

        /// <summary>
        /// To get the amount from the user 
        /// </summary>
        /// <param name="amount">To get, validate and return Amount through out parameter</param>
        /// <param name="accountType">Account Type</param>
        /// <returns>True - Valid Amount | False - Invalid Amount</returns>
        public bool GetAmount(out decimal amount, int accountType)
        {
            int tries = 3;
            do
            {
                tries--;
                string result = string.Empty;
                Console.WriteLine("Enter the Amount :");
                string stringAmount = Console.ReadLine() ?? string.Empty;
                if (Helper.IsNumber(stringAmount, out amount))
                {
                    result = BankServices.IsValidInitialDeposit(amount, accountType);
                    if (result == string.Empty)
                    {
                        return true;
                    }
                }
                else
                {
                    result = "You must enter only a number";
                }

                Helper.DisplayWarningMessage($"Invalid amount!\n{result} \nNumber of Tries Left is:{tries}\n ");
            }
            while (tries > 0);
            return false;
        }
    }
}