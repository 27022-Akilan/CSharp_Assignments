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
        /// Adding the transaction failed due to invalid amount
        /// </summary>
        public const string AddFailedDueToInvalidAmount = "Transaction cant be added , because of amount less than 1";

        /// <summary>
        /// Adding the transaction failed due to invalid type of transaction.
        /// </summary>
        public const string CantAddDueToInvalidType = "Cant add the transaction, due to invalid type of transaction";

        /// <summary>
        /// Validation of description failed message
        /// </summary>
        public const string ValidationErrorOnDescription = "The description can't be Empty or Whitespace";

        /// <summary>
        /// Type of the Amount is not correct message.
        /// </summary>
        public const string InvalidAmountFormat = "Your input Should contains number only!";

        /// <summary>
        /// Invalid Amount.
        /// </summary>
        public const string ValidationErrorOnAmount = "Your amount should be greater than 0";

        /// <summary>
        /// Invalid Date format message.
        /// </summary>
        public const string InvalidDateFormat = "Invalid date format. Please enter as DD/MM/YYYY";

        /// <summary>
        /// Validation error message for Date.
        /// </summary>
        public const string ValidationErrorOnDate = "Invalid date : you input date should be less than or equal to current date.";
    }
}
