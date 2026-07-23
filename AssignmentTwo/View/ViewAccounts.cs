using AssignmentTwo.Model.Bank;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// To view Account
    /// </summary>
    internal class ViewAccounts
    {
        private BankServices _bankServices = new BankServices();

        /// <summary>
        /// Menu for accessing accounts
        /// </summary>
        public void Menu()
        {
            BankAccount account;
            do
            {
                Console.WriteLine("1.Create Savings Account \n2.Create Checking Account \n3.Exit \nEnter your Choice");
                string choice = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choice, out int ch))
                {
                    switch (ch)
                    {
                        case 1:
                            Helper.GetNameAndInitialDeposit(out string name, out decimal initialDeposit);
                            account = new SavingsAccount(name, Helper.CreateGuid(), initialDeposit);
                            this.SubMenu(account);
                            break;
                        case 2:
                            Helper.GetNameAndInitialDeposit(out name, out initialDeposit);
                            account = new SavingsAccount(name, Helper.CreateGuid(), initialDeposit);
                            this.SubMenu(account);
                            break;
                        case 3:
                            break;
                    }

                    if (ch == 3)
                    {
                        break;
                    }
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
            do
            {
                Console.WriteLine("10.Deposit \n20.Withdraw \n30.Print Details \n40.Exit \nEnter your Choice : ");
                string choiceForDepositOrWithdrawalOrGetDetails = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceForDepositOrWithdrawalOrGetDetails, out int numberForDepositOrWithdrawal))
                {
                    // Console.WriteLine("hiiiii");
                    switch (numberForDepositOrWithdrawal)
                    {
                        case 10:
                            Console.WriteLine("Deposit chooseed");
                            decimal deopsitAmount = Helper.GetAmount();
                            Console.WriteLine(this._bankServices.DepositAmount(account, deopsitAmount));
                            break;
                        case 20:
                            decimal withdrawAmount = Helper.GetAmount();
                            Console.WriteLine(this._bankServices.WithdrawAmount(account, withdrawAmount));
                            break;
                        case 30:
                            // Console.WriteLine("hiii in case 30");
                            Console.WriteLine(this._bankServices.GetDetails(account));
                            break;
                        case 40:
                            Console.WriteLine("Exiting!!!");
                            break;
                    }

                    if (numberForDepositOrWithdrawal == 40)
                    {
                        break;
                    }
                }
            }
            while (true);
        }
    }
}