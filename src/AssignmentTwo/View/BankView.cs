using AssignmentTwo.Model.Bank;
using AssignmentTwo.Model.EnumModels;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// To view Account
    /// </summary>
    public class BankView
    {
        private BankServices _bankServices = new BankServices();

        /// <summary>
        /// Menu for accessing accounts
        /// </summary>
        public void DisplayMenu()
        {
            OptionForBank optionForBank;
            long accountNumber = 0;
            BankAccount account;
            do
            {
                Console.WriteLine("\n==================================" +
                    "\n1.Create Savings Account " +
                    "\n2.Create Checking Account " +
                    "\n3.Exit " +
                    "\n==================================" +
                    "\nEnter your Choice:");
                string choice = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choice, out int ch))
                {
                    optionForBank = (OptionForBank)ch;
                    switch (optionForBank)
                    {
                        case OptionForBank.CreateAndViewSavingsAccount:
                            bool getNameTriesOut = Helper.GetName(out string name);
                            if (getNameTriesOut)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation account due to maximum tries of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(ch);
                            bool getAmountTriesOut = this.GetAmount(out decimal amount, ch);
                            if (getAmountTriesOut)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation of the account due to maximum tries of invalid Initial Deposit");
                                break;
                            }

                            account = new SavingsAccount(name, ++accountNumber, amount);
                            Helper.DisplaySuccessMessage("Savings Account created Successfully");
                            this.DisplaySubMenu(account);
                            break;

                        case OptionForBank.CreateAndViewCheckingAccount:
                            getNameTriesOut = Helper.GetName(out name);
                            if (getNameTriesOut)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation of the account due to maximum tries of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(ch);
                            getAmountTriesOut = this.GetAmount(out amount, ch);
                            if (getAmountTriesOut)
                            {
                                Helper.DisplayFailedMessage("Aborting the creation account due to maximum tries of invalid Initial deposit");
                                break;
                            }

                            account = new CheckingAccount(name, ++accountNumber, amount);
                            Helper.DisplaySuccessMessage("Checking Account created Successfully");
                            this.DisplaySubMenu(account);
                            break;

                        case OptionForBank.Exit:
                            Helper.DisplaySuccessMessage("Exited!!");
                            break;
                        default:
                            Helper.DisplayFailedMessage("Enter Correct Value between 1 to 3");
                            break;
                    }

                    if (ch == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Enter valid number and can be only between (1-5)");
                }
            }
            while (true);
        }

        /// <summary>
        /// Operations Deposit,Withdraw,print
        /// </summary>
        /// <param name="account">account object</param>
        public void DisplaySubMenu(BankAccount account)
        {
            BankOperation bankOperation;
            do
            {
                Console.WriteLine("\nIf you need any more services " +
                    "\n1.Deposit " +
                    "\n2.Withdraw " +
                    "\n3.Print Details " +
                    "\n4.Exit " +
                    "\nEnter your Choice : ");
                string choiceForDepositOrWithdrawalOrGetDetails = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceForDepositOrWithdrawalOrGetDetails, out int numberForDepositOrWithdrawal))
                {
                    bool outOfTries = true;
                    bankOperation = (BankOperation)numberForDepositOrWithdrawal;
                    switch (bankOperation)
                    {
                        case BankOperation.Deposit:
                            Console.WriteLine("Deposit chose");
                            outOfTries = this.GetOrPutMoney(account, BankOperation.Deposit);
                            break;
                        case BankOperation.Withdraw:
                            Console.WriteLine("Withdraw chose");
                            outOfTries = this.GetOrPutMoney(account, BankOperation.Withdraw);
                            break;
                        case BankOperation.PrintDetails:
                            Helper.DisplaySuccessMessage(this._bankServices.GetDetails(account));
                            break;
                        case BankOperation.Exit:
                            Helper.DisplaySuccessMessage("Exited!!");
                            break;
                        default:
                            Helper.DisplayFailedMessage("Invalid Choice");
                            break;
                    }

                    if (!outOfTries || bankOperation == BankOperation.Exit)
                    {
                        break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Enter valid number can be only (1 to 4)");
                }
            }
            while (true);
        }

        /// <summary>
        /// To print the initial amount that should be deposited for creation
        /// </summary>
        /// <param name="accountType">Type of the account (savings or checking)</param>
        public void PrintInitialDepositValue(int accountType)
        {
            if (accountType == 1)
            {
                Console.WriteLine($"The Initial Deposit should be Greater than {BankServices.MinimumInitialDepositForServiceAccount}");
            }
            else
            {
                Console.WriteLine($"The Initial Deposit should be Greater than {BankServices.MinimumInitialDepositForCheckingAccount}");
            }
        }

        /// <summary>
        /// to withdraw and deposit amount
        /// </summary>
        /// <param name="account">account object</param>
        /// <param name="bankOperation">choice for deposit or withdraw</param>
        /// <returns>bool</returns>
        public bool GetOrPutMoney(BankAccount account, BankOperation bankOperation)
        {
            decimal amount;
            bool getOrPutAmount = this.GetAmountForDepositOrWithdraw(out amount);
            if (getOrPutAmount == false)
            {
                if (bankOperation == BankOperation.Deposit)
                {
                    Helper.DisplaySuccessMessage(this._bankServices.DepositAmount(account, amount));
                    return true;
                }

                Helper.DisplaySuccessMessage(this._bankServices.WithdrawAmount(account, amount));
                return true;
            }

            return true;
        }

        /// <summary>
        /// to get amount for deposit and withdraw
        /// </summary>
        /// <param name="amount">to out the amount using</param>
        /// <returns>bool</returns>
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
                    return false;
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
            return true;
        }

        /// <summary>
        /// To get the amount
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="accountType">Account Type</param>
        /// <returns>True - Valid Amount False - Invalid Amount</returns>
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
                    result = BankServices.IsAmountIsGreaterThanInitialDeposit(amount, accountType);
                    if (result == string.Empty)
                    {
                        // as it gets valid input so the outOfTries == false
                        return false;
                    }
                }
                else
                {
                    result = "You must enter only a number";
                }

                Helper.DisplayWarningMessage($"Invalid amount!\n{result} \nNumber of Tries Left is:{tries}\n ");
            }
            while (tries > 0);
            return true;
        }
    }
}