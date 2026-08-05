namespace Assignment1.Models
{
    /// <summary>
    /// Base model of the data
    /// </summary>
    internal class ContactInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfo"/> class .
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="id">guid</param>
        public ContactInfo(string? name, string? phone, string? email, string? notes, Guid id)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Notes = notes;
        }

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        /// /// <value>
        /// A <see cref="string"/> containing the name of the product.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the product.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets phone
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the product.
        /// </value>
        public string? Phone { get; set; }

        /// /// <summary>
        /// Gets or sets Email
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the product.
        /// </value>
        public string? Email { get; set; }

        /// /// <summary>
        /// Gets or sets Notes
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the product.
        /// </value>
        public string? Notes { get; set; }
    }
}
