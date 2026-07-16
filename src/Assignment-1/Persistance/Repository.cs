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
        /// Edits an existing contact.
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">ph</param>
        /// <param name="email">em</param>
        /// <param name="notes">notes</param>
        /// <param name="id">id</param>
        public void Edit(string? name, string? phone, string? email, string? notes, Guid id)
        {
            foreach (var x in this._contactInfoList)
            {
                if (x.Id == id)
                {
                    x.Name = name;
                    x.Phone = phone;
                    x.Email = email;
                    x.Notes = notes;
                }
            }
        }

        /// <summary>
        /// Deleting the contact
        /// </summary>
        /// <param name="userInp">Guid</param>
        /// <returns>string</returns>
        public string Delete(string? userInp)
        {
            Guid id;
            if (Helper.IsValidGId(userInp, out id))
            {
                foreach (var x in this._contactInfoList)
                {
                    if (x.Id == id)
                    {
                        this._contactInfoList.Remove(x);
                        return string.Empty;
                    }
                }

                // Guid Not found
                return "GNF";
            }

            return "IG";
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

        /// <summary>
        /// To return the Search results
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">ph</param>
        /// <param name="email">em</param>
        /// <param name="notes">not</param>
        /// <returns>list</returns>
        public List<ContactInfo> Search(string? name, string? phone,  string? email, string? notes)
        {
            List<ContactInfo> searchedList = new List<ContactInfo>();

            foreach (var x in this._contactInfoList)
            {
                if (x.Name == name || x.Phone == phone || x.Email == email || x.Notes == notes)
                {
                    ContactInfo clonedContact = new ContactInfo(x.Name, x.Phone, x.Email, x.Notes, x.Id);
                    searchedList.Add(clonedContact);
                }
            }

            return searchedList;
        }
    }
}