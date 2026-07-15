using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    /// <summary>
    /// this is the model
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
        public ContactInfo(string name, string phone, string email, string notes, Guid id)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Notes = notes;
        }

        /// <summary>
        /// Gets Id
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
        /// Gets or sets Phonr
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
