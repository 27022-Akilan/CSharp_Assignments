namespace AssignmentFour.Constants
{
    /// <summary>
    /// Represents the result messages of the operations performed.
    /// </summary>
    public class ResultMessages
    {
        /// <summary>
        /// Message displayed when a transaction added is successfully.
        /// </summary>
        public const string AddSuccess = "Transaction added Successfully";

        /// <summary>
        /// Message displayed when a transaction cannot be added because of the storage error.
        /// </summary>
        public const string AddFailedDueToStorage = "Transaction cant be added because of the storage error";

        /// <summary>
        /// Message displayed when a transaction cannot be added because of missing values.
        /// </summary>
        public const string AddFailedDueToMissingValues = "Transaction cant be added because of the missing Values";

        /// <summary>
        /// Message displayed when a transaction cannot be added because of invalid amount.
        /// </summary>
        public const string AddFailedDueToInvalidAmount = "Transaction cant be added because of amount less than 1";

        /// <summary>
        /// Message displayed when a transaction cannot be added because of invalid type of transaction.
        /// </summary>
        public const string AddFailedDueToInvalidType = "Transaction cant be added because of the invalid type of transaction";

        /// <summary>
        /// Message displayed when the transaction description is empty or contains only whitespace.
        /// </summary>
        public const string InvalidDescription = "The description can't be empty or whitespace";

        /// <summary>
        /// Message displayed when a the amount input is not a valid numeric value.
        /// </summary>
        public const string InvalidAmountFormat = "Amount must contains number only!";

        /// <summary>
        /// Message displayed when the amount is less than the minimum allowed value.
        /// </summary>
        public const string InvalidAmount = "Amount must be greater than or equal to 1";

        /// <summary>
        /// Message displayed when the date input is not in the desired format.
        /// </summary>
        public const string InvalidDateFormat = "Date must be in this format DD/MM/YYYY";

        /// <summary>
        /// Message displayed when the date is less than the current date.
        /// </summary>
        public const string InvalidDate = "Date should be less than or equal to current date.";
    }
}
