using AssignmentTwo.Model.Bank;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// Provides Services
    /// </summary>
    public class BankServices
    {
        /// <summary>
        /// To check whether the initial deposit is greater than the threshold.
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        /// <param name="accountType">Stores the Type of the Account</param>
        /// <returns>("")Empty string - Validation success | String Message - Validation failed message </returns>
        public static string IsAmountIsGreaterThanInitialDeposit(decimal amount, int accountType)
        {
            if (accountType == 1)
            {
                return (amount > SavingsAccount.MinimumInitialDeposit) ? string.Empty
                    : $"The initial deposit Should be greater than {SavingsAccount.MinimumBalance}";
            }
            else
            {
                return (amount > CheckingAccount.MinimumInitialDeposit) ? string.Empty
                    : $"The initial deposit Should be greater than {CheckingAccount.MinimumBalance}";
            }
        }

        /// <summary>
        /// To deposit
        /// </summary>
        /// <param name="account">Account object</param>
        /// <param name="depositMoney">deposit amount</param>
        /// <returns>string</returns>
        public string DepositAmount(BankAccount account, decimal depositMoney)
        {
            return account.DepositIntoAccount(depositMoney);
        }

        /// <summary>
        /// To withdraw
        /// </summary>
        /// <param name="account">Account object</param>
        /// <param name="withdrawMoney">withdraw amount</param>
        /// <returns>string</returns>
        public string WithdrawAmount(BankAccount account, decimal withdrawMoney)
        {
            if (account is SavingsAccount)
            {
                if (account.Balance - withdrawMoney < SavingsAccount.MinimumBalance)
                {
                    return $"Cant Withdraw from your Account because after withdrawing, your account should have minimum amount of 2000" +
                    $"\nCurrent Balance :{account.Balance}";
                }

                return account.WithdrawFromAccount(withdrawMoney);
            }
            else
            {
                if (account.Balance - withdrawMoney < 0)
                {
                    return $"Insufficient balance !!! Balance is: {account.Balance}";
                }

                return account.WithdrawFromAccount(withdrawMoney);
            }
        }

        /// <summary>
        /// To withdraw
        /// </summary>
        /// <param name="account">Account object</param>
        /// <returns>string</returns>
        public string GetDetails(BankAccount account)
        {
            return account.PrintDetails();
        }
    }
}
