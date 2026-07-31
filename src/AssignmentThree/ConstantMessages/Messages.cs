namespace AssignmentThree.ConstantMessages
{
    /// <summary>
    ///  Hold the const Messages for the errors and success
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string NameCantBeEmpty = "Name of the product cant be empty or whitespace";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string NameCannotBeOnlyNumbers = "Name of the Product Should Atleast Contain One Character";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string NameShouldBeAlphaNumeric = "Name of the Product Should Contain only Letters and numbers";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string IdCantBeEmpty = "Id of the Product cant be empty or whitespace";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string PriceCantBeLessThanZero = "Price cant be Less Than Zero";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string NotAPrice = "Price Should Only be a number";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string NotAQuantity = "Quantity Should Only be a number";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string QuantityCantBeLessThanZero = "Quantity Should Only be a number";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string OnlyBeOneOrZero = "Input Should be only 1 or 0";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string CantBeLetters = "Input Should be only Numbers(0 or 1)";

        /// <summary>
        /// Name of the product Can be empty message
        /// </summary>
        public const string CantHaveControlCharaters = "Please dont use Keyboard Shortcuts and (^)Symbol, Enter valid text only.";
    }
}
