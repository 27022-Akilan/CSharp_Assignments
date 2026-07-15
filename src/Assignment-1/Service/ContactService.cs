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
        /// gh
        /// </summary>
        /// <param name="contact">hjd</param>
        /// <returns>bool</returns>
        public string AddContact(ContactInfo contact)
        {
            if (Helper.IsValidName(contact.Name) == "VN")
            {
                if (Helper.IsValidPhone(contact.Phone) == "VP")
                {
                    if (Helper.IsValidEmail(contact.Email) == "VE")
                    {
                        Guid id= Guid.NewGuid();
                        this._repository.Add(contact, id);
                        return "";
                    }

                    return "IE";
                }
                else
                {
                    return "IP";
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
            return this._repository.Get();
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
        public string EditContact(string name, string phone, string email, string notes, string userInp)
        {
            List<ContactInfo> list = this._repository.Get();
            if (Helper.IsValidName(name) == "VN")
            {
                if (Helper.IsValidPhone(phone) == "VP")
                {
                    if (Helper.IsValidEmail(email) == "VE")
                    {
                        Guid id;
                        if (Helper.IsValidGId(userInp, out id))
                        {
                            foreach (var x in list)
                            {
                                if (x.Id == id)
                                {
                                    this._repository.Edit(x, name, phone, email, notes);
                                    return "";
                                }
                            }

                            return "IG";
                        }

                        return "IG";
                    }

                    return "IE";
                }
                else
                {
                    return "IP";
                }
            }
            return "IN";
        }

        /// <summary>
        /// hjhjhj
        /// </summary>
        /// <param name="userInp">usrch</param>
        /// <returns>string</returns>
        public string DeleteContact(string userInp)
        {
            List<ContactInfo> list = this._repository.Get();
            Guid id;
            if (Helper.IsValidGId(userInp, out id))
            {
                foreach (var x in list)
                {
                    if (x.Id == id)
                    {
                        this._repository.Delete(x);
                        return "";
                    }
                }
            }

            return "IG";
        }

        /// <summary>
        /// Searchin for Contact
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <returns>List</returns>
        public List<ContactInfo> SearchContact(string name, string phone, string email, string notes)
        {
            List<ContactInfo> list = this._repository.Get();
            List<ContactInfo> outList = new List<ContactInfo>();
            foreach (var x in list)
            {
                if (x.Name == name || x.Phone == phone || x.Email == email || x.Notes == notes)
                {
                    outList.Add(x);
                }
            }

            return new List<ContactInfo>(outList);
        }
        /// <summary>
        /// Sorting
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> SortContact()
        {
            List<ContactInfo> sortedList=_repository.GetClone();
            sortedList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
            return sortedList;
        }
    }
}