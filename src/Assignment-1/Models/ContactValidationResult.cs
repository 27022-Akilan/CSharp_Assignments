namespace Assignment1.Models
{
    /// <summary>
    /// Represents the outcome of a contact validation or lookup operation.
    /// </summary>
    internal enum ContactValidationResult
    {
        /// <summary>
        /// Success
        /// </summary>
        Success,

        /// <summary>
        /// Invalid Name
        /// </summary>s
        InvalidName,

        /// <summary>
        /// Invalid Phone Number
        /// </summary>
        InvalidPhone,

        /// <summary>
        /// Invalid Phone NUmber length
        /// </summary>
        InvalidPhoneLength,

        /// <summary>
        /// PhoneNumber Already Exists
        /// </summary>
        PhoneAlreadyExists,

        /// <summary>
        /// Invalid Email
        /// </summary>
        InvalidEmail,

        /// <summary>
        /// Invalid guid
        /// </summary>
        InvalidGuid,

        /// <summary>
        /// Guid not found
        /// </summary>
        GuidNotFound,

        /// <summary>
        /// Valid name
        /// </summary>
        ValidName,

        /// <summary>
        /// Valid phone
        /// </summary>
        ValidPhone,

        /// <summary>
        /// Valid Email
        /// </summary>
        ValidEmail,

        /// <summary>
        /// valid notes
        /// </summary>
        ValidNotes,

        /// <summary>
        /// Trys completed
        /// </summary>
        TrysCompleted,

        /// <summary>
        /// List is Empty
        /// </summary>
        ListEmpty,
    }
}