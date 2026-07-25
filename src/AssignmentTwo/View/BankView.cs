using AssignmentTwo.Model;
using AssignmentTwo.Model.Bank;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// To view Account
    /// </summary>
    internal class BankView
    {
        private BankServices _bankServices = new BankServices();

        /// <summary>
        /// Menu for accessing accounts
        /// </summary>
        public void Menu()
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
                            bool getNameTrysOut = Helper.GetName(out string name);
                            if (getNameTrysOut)
                            {
                                Helper.WriteFailed("Aborting the creation account due to maximum trys of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(ch);
                            bool getAmountTrysOut = Helper.GetAmount(out decimal amount, ch);
                            if (getAmountTrysOut)
                            {
                                Helper.WriteFailed("Aborting the creation of the account due to maximum trys of invalid Initial Deposit");
                                break;
                            }

                            account = new SavingsAccount(name, ++accountNumber, amount);
                            this.SubMenu(account);
                            break;

                        case OptionForBank.CreateAndViewCheckingAccount:
                            getNameTrysOut = Helper.GetName(out name);
                            if (getNameTrysOut)
                            {
                                Helper.WriteFailed("Aborting the creation of the account due to maximum trys of invalid name");
                                break;
                            }

                            this.PrintInitialDepositValue(ch);
                            getAmountTrysOut = Helper.GetAmount(out amount, ch);
                            if (getAmountTrysOut)
                            {
                                Helper.WriteFailed("Aborting the creation account due to maximum trys of invalid Initial deposit");
                                break;
                            }

                            account = new CheckingAccount(name, ++accountNumber, amount);
                            this.SubMenu(account);
                            break;

                        case OptionForBank.Exit:
                            Helper.WriteSuccess("Exited!!");
                            break;
                        default:
                            Helper.WriteFailed("Enter Correct Value between 1 to 3");
                            break;
                    }

                    if (ch == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Helper.WriteFailed("Enter valid number and can be only between (1-5)");
                }
            }
            while (true);
        }

        /// <summary>
        /// Operations Deposit,Withdraw,print
        /// </summary>
        /// <param name="account">account object</param>
        public void SubMenu(BankAccount account)
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
                    bool outOfTrys = true;
                    bankOperation = (BankOperation)numberForDepositOrWithdrawal;
                    switch (bankOperation)
                    {
                        case BankOperation.Deposit:
                            Console.WriteLine("Deposit choosed");
                            outOfTrys = this.GetOrPutMoney(account, BankOperation.Deposit);
                            break;
                        case BankOperation.Withdraw:
                            Console.WriteLine("Withdraw choosed");
                            outOfTrys = this.GetOrPutMoney(account, BankOperation.Withdraw);
                            break;
                        case BankOperation.PrintDetails:
                            Helper.WriteSuccess(this._bankServices.GetDetails(account));
                            break;
                        case BankOperation.Exit:
                            Helper.WriteSuccess("Exited!!");
                            break;
                        default:
                            Helper.WriteFailed("Invalid Choice");
                            break;
                    }

                    if (!outOfTrys || numberForDepositOrWithdrawal == 40)
                    {
                        break;
                    }
                }
                else
                {
                    Helper.WriteFailed("Enter valid number can be only (1 to 4)");
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
                Console.WriteLine("The Initial Deposit should be Greater than 2000");
            }
            else
            {
                Console.WriteLine("The Initial Deposit should be Greater than 1000");
            }
        }

        /// <summary>
        /// to withdraw and deposit amount
        /// </summary>
        /// <param name="account">account onject</param>
        /// <param name="bankOperation">choice for deposit or withdraw</param>
        /// <returns>bool</returns>
        public bool GetOrPutMoney(BankAccount account, BankOperation bankOperation)
        {
            decimal amount;
            bool getorPutAmount = this.GetAmountForDepositOrWithdraw(out amount);
            if (getorPutAmount == false)
            {
                if (bankOperation == BankOperation.Deposit)
                {
                    Helper.WriteSuccess(this._bankServices.DepositAmount(account, amount));
                    return true;
                }

                Helper.WriteSuccess(this._bankServices.WithdrawAmount(account, amount));
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
            int trys = 3;
            do
            {
                trys -= 1;
                Console.WriteLine("Enter the Amount :");
                string stringAmount = Console.ReadLine() ?? string.Empty;
                if (Helper.IsNumber(stringAmount, out amount) && (amount > 0))
                {
                    return false;
                }

                Helper.WriteFailed($"Invalid Amount! Number of Tries Left : {trys}\n");
            }
            while (trys > 0);
            return true;
        }
    }
}