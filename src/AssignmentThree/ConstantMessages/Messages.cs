namespace AssignmentThree.ConstantMessages
{
    /// <summary>
    /// Contains constant messages used for validation, errors, and success notifications.
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Displayed when the product name is empty or contains only whitespace.
        /// </summary>
        public const string NameCantBeEmpty =
            "Product name cannot be empty or consist only of whitespace.";

        /// <summary>
        /// Displayed when the product name contains only numeric characters.
        /// </summary>
        public const string NameCannotBeOnlyNumbers =
            "Product name must contain at least one alphabetic character.";

        /// <summary>
        /// Displayed when the product name contains invalid characters.
        /// </summary>
        public const string NameShouldBeAlphaNumeric =
            "Product name can contain only letters and numbers.";

        /// <summary>
        /// Displayed when the product ID is empty or contains only whitespace.
        /// </summary>
        public const string IdCantBeEmpty =
            "Product ID cannot be empty or consist only of whitespace.";

        /// <summary>
        /// Displayed when the entered price is invalid.
        /// </summary>
        public const string NotAPrice =
            "Price must be a valid numeric value.";

        /// <summary>
        /// Displayed when the price is less than or equal to zero.
        /// </summary>
        public const string PriceCantBeLessThanZero =
            "Price must be greater than zero.";

        /// <summary>
        /// Displayed when the entered quantity is invalid.
        /// </summary>
        public const string NotAQuantity =
            "Quantity must be a valid whole number.";

        /// <summary>
        /// Displayed when the quantity is negative.
        /// </summary>
        public const string QuantityCantBeLessThanZero =
            "Quantity cannot be negative.";

        /// <summary>
        /// Displayed when the input must be either 0 or 1.
        /// </summary>
        public const string OnlyBeOneOrZero =
            "Please enter either 0 or 1.";

        /// <summary>
        /// Displayed when a numeric input contains alphabetic characters.
        /// </summary>
        public const string CantBeLetters =
            "Please enter numbers only.";

        /// <summary>
        /// Displayed when the input contains non-printable control characters.
        /// </summary>
        public const string CantHaveControlCharacters =
            "Input contains invalid control characters such as ^A (Think so you pressed the key along with ctrl key). Please enter valid text.";
    }
}
