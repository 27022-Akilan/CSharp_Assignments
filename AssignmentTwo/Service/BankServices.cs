using AssignmentTwo.Model.Bank;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// Provides Services
    /// </summary>
    public class BankServices
    {
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
