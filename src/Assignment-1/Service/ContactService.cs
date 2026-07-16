using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assignment1.Models;
using Assignment1.Persistance;

namespace Assignment1.Service
{
    /// <summary>
    /// Business logic
    /// </summary>
    internal class ContactService
    {
        private Repository _repository = new Repository();

        /// <summary>
        /// Add the contact into list
        /// </summary>
        /// <param name="contact">hjd</param>
        /// <returns>bool</returns>
        public string AddContact(ContactInfo contact)
        {
            if (Helper.IsValidName(contact.Name) == "VN")
            {
                string phoneRes = Helper.IsValidPhone(contact.Phone);
                if (phoneRes == "VP")
                {
                    if (Helper.IsValidEmail(contact.Email) == "VE")
                    {
                        Guid id = Guid.NewGuid();
                        this._repository.Add(contact, id);
                        return string.Empty;
                    }

                    return "IE";
                }
                else
                {
                    return phoneRes;
                }
            }

            return "IN";
        }

        /// <summary>
        /// Get List of Contact
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> Show()
        {
            return this._repository.GetClone();
        }

        /// <summary>
        /// ghghghghg
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="userInp">userinp</param>
        /// <returns>string</returns>
        public string EditContact(string? name, string? phone, string? email, string? notes, string? userInp)
        {
            if (Helper.IsValidName(name) == "VN")
            {
                string phoneRes = Helper.IsValidPhone(phone);
                if (phoneRes == "VP")
                {
                    if (Helper.IsValidEmail(email) == "VE")
                    {
                        Guid id;
                        if (Helper.IsValidGId(userInp, out id))
                        {
                            this._repository.Edit(name, phone, email,  notes, id);

                            return string.Empty;
                        }

                        return "IG";
                    }

                    return "IE";
                }
                else
                {
                    return phoneRes;
                }
            }

            return "IN";
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="userInp">usrch</param>
        /// <returns>string</returns>
        public string DeleteContact(string? userInp)
        {
            return this._repository.Delete(userInp);
        }

        /// <summary>
        /// Searchin for Contact
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <returns>List</returns>
        public List<ContactInfo> SearchContact(string? name, string? phone, string? email, string? notes)
        {
            return this._repository.Search(name, phone, email, notes);
        }

        /// <summary>
        /// Sorting
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> SortContact()
        {
            List<ContactInfo> sortedList = this._repository.GetClone();
            sortedList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
            return sortedList;
        }
    }
}
