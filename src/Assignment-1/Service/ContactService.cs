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
            string res = this.IsValidNamePhoneEmail(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
            if (res == string.Empty)
            {
                Guid idToBeAdded = Guid.NewGuid();
                ContactInfo contactToBeAdded = new ContactInfo(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
                this._repository.Add(contactToBeAdded, idToBeAdded);
                return string.Empty;
            }

            return res;
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
            Guid id;
            if (Helper.IsValidGId(userInp, out id))
            {
                string res = this.IsValidNamePhoneEmail(name, phone, email, notes, id);
                if (res == string.Empty)
                {
                    if (this._repository.Edit(name, phone, email, notes, id))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return "GNF";
                    }
                }

                return res;
            }

            return "IG";
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

        /// <summary>
        /// To check and add or edit contact based the provided information.
        /// </summary>
        /// <param name="name">nane</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="id">Guid</param>
        /// <returns>string</returns>
        private string IsValidNamePhoneEmail(string? name, string? phone, string? email, string? notes, Guid id)
        {
            if (Helper.IsValidName(name) == "VN")
            {
                string phoneRes = Helper.IsValidPhone(phone);
                if (phoneRes == "VP")
                {
                    bool flag = this.IsPhoneExists(phone, id);
                    if (flag == true)
                    {
                        // PhoneNumber already exists
                        return "PAE";
                    }

                    if (Helper.IsValidEmail(email) == "VE")
                    {
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
        /// checks for existing phone num
        /// </summary>
        /// <param name="phone">ph</param>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        private bool IsPhoneExists(string? phone, Guid id)
        {
            List<ContactInfo> listForPhoneNumberCheck = this._repository.GetClone();
            foreach (var x in listForPhoneNumberCheck)
            {
                if (x.Phone == phone && id != x.Id)
                {
                    // if exists
                    return true;
                }
            }

            // if doesnt exists
            return false;
        }

        /// <summary>
        /// Guid exists or not
        /// </summary>
        /// <param name="id">Guid </param>
        /// <returns>bool</returns>
        private bool IsGuidExists(Guid id)
        {
            List<ContactInfo> list = this._repository.GetClone();
            foreach (var x in list)
            {
                if (x.Id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
