using AssignmentTwo.Model.Bank;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// Provides Services
    /// </summary>
    public class BankServices
    {
        /// <summary>
        /// Minimum Initial deposit for the Savings account
        /// </summary>
        public const decimal MinimumInitialDepositForServiceAccount = 2000;

        /// <summary>
        /// Minimum Initial deposit for the checking account
        /// </summary>
        public const decimal MinimumInitialDepositForCheckingAccount = 0;

        /// <summary>
        /// Minimum balance for the Savings account
        /// </summary>
        public const decimal MinimumBalanceForServiceAccount = 2000;

        /// <summary>
        /// Minimum balance for the Checking account
        /// </summary>
        public const decimal MinimumBalanceForCheckingAccount = 0;

        /// <summary>
        /// To check whether the initial deposit is greater than the Minimum initial deposit
        /// </summary>
        /// <param name="amount">Initial deposit amount</param>
        /// <param name="accountType">1- Refers to Savings Account | 2- Refers to Checking Account</param>
        /// <returns>Empty string - If the validation succeeds | Validation error message - If Validation fails</returns>
        public static string IsAmountIsGreaterThanInitialDeposit(decimal amount, int accountType)
        {
            if (accountType == 1)
            {
                if (amount >= MinimumInitialDepositForServiceAccount)
                {
                    return string.Empty;
                }

                return $"Your Initial deposit should be greater than {MinimumInitialDepositForServiceAccount}";
            }

            if (amount > MinimumInitialDepositForCheckingAccount)
            {
                return string.Empty;
            }

            return $"Your Initial Deposit Should be greater than {MinimumInitialDepositForCheckingAccount}";
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
            if (account.Balance - withdrawMoney < 0)
            {
                return $"Insufficient Balance {account.Balance}";
            }

            if (account.Balance - withdrawMoney < MinimumBalanceForServiceAccount)
            {
                return $"Insufficient balance , Your account should always have a minimum balance of {MinimumBalanceForServiceAccount}";
            }

            return account.WithdrawFromAccount(withdrawMoney);
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
