namespace AssignmentFour.Constants
{
    /// <summary>
    /// It holds the return messages. 
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// Transaction Added Success full message
        /// </summary>
        public const string AddSuccess = "Transaction added Successfully";

        /// <summary>
        /// Transaction Added failed message
        /// </summary>
        public const string AddFailed = "Transaction cant be added.";

        /// <summary>
        /// Adding the transaction failed due to Null
        /// </summary>
        public const string AddFailedDueToNull = "Transaction cant be added , because of Empty values";

        /// <summary>
        /// Adding the transaction failed due to Invalid amount
        /// </summary>
        public const string AddFailedDueToAmountLessThanZero = "Transaction cant be added , because of amount less than 0";
    }
}
