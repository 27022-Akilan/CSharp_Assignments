using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Service;

namespace Assignment1.Persistance
{
    /// <summary>
    /// To store and fetch
    /// </summary>
    internal class Repository
    {
        private readonly List<ContactInfo> _contactInfoList;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository()
        {
            this._contactInfoList = new List<ContactInfo>();
        }

        /// <summary>
        /// Adds a contact with the given id.
        /// </summary>
        /// <param name="contact">add</param>
        /// <param name="id">id</param>
        public void Add(ContactInfo contact, Guid id)
        {
            contact.Id = id;
            this._contactInfoList.Add(contact);
        }

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> Get()
        {
            return new List<ContactInfo>(this._contactInfoList);
        }

        /// <summary>
        /// Edits an existing contact.
        /// </summary>
        /// <param name="contact">obj</param>
        /// <param name="name">name</param>
        /// <param name="phone">ph</param>
        /// <param name="email">em</param>
        /// <param name="notes">notes</param>
        public void Edit(ContactInfo contact, string? name, string? phone, string? email, string? notes)
        {
            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;
            contact.Notes = notes;
        }

        /// <summary>
        /// Deletes a contact.
        /// </summary>
        /// <param name="contact">hjhg</param>
        /// <returns>bool</returns>
        public bool Delete(ContactInfo contact)
        {
            this._contactInfoList.Remove(contact);
            return true;
        }

        /// <summary>
        /// Gets the id at a given index.
        /// </summary>
        /// <param name="indx">indx</param>
        /// <returns>guid</returns>
        public Guid GetGId(int indx)
        {
            return this._contactInfoList[indx].Id;
        }

        /// <summary>
        /// Returns a cloned list.
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> GetClone()
        {
            List<ContactInfo> list = new List<ContactInfo>();
            foreach (var contact in this._contactInfoList)
            {
                ContactInfo cloned = new ContactInfo(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
                list.Add(cloned);
            }

            return list;
        }
    }
}