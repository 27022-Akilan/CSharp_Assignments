using Assignment1.Models;
using Assignment1.Persistance;

namespace Assignment1.Service
{
    /// <summary>
    /// Service provider for contact management
    /// </summary>
    internal class ContactService
    {
        private ContactRepository _contactRepository = new ContactRepository();

        /// <summary>
        /// Add the contact into list
        /// </summary>
        /// <param name="contact">Contact</param>
        /// <returns>String</returns>
        public string AddContact(ContactInfo contact)
        {
            string res = this.IsValidNamePhoneEmail(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
            if (res == string.Empty)
            {
                Guid idToBeAdded = Guid.NewGuid();
                ContactInfo contactToBeAdded = new ContactInfo(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
                this._contactRepository.Add(contactToBeAdded, idToBeAdded);
                return string.Empty;
            }

            return res;
        }

        /// <summary>
        /// Get List of Contact
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> GetContacts()
        {
            return this._contactRepository.Show();
        }

        /// <summary>
        /// Updates the contact
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="editContactGuid">user Input Guid</param>
        /// <returns>string</returns>
        public string UpdateContact(string? name, string? phone, string? email, string? notes, string? editContactGuid)
        {
            Guid validGuid;
            if (Helper.IsValidGId(editContactGuid, out validGuid))
            {
                string result = this.IsValidNamePhoneEmail(name, phone, email, notes, validGuid);
                if (result == string.Empty)
                {
                    if (this._contactRepository.Edit(name, phone, email, notes, validGuid))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        // Guid Not Found
                        return "GUID NOT FOUND";
                    }
                }

                return result;
            }

            // InValid Guid
            return "INVALID GUID";
        }

        /// <summary>
        /// Deletes the contact
        /// </summary>
        /// <param name="guidofContactToBeDeleted">Guid to delete</param>
        /// <returns>string</returns>
        public string DeleteContact(string? guidofContactToBeDeleted)
        {
            Guid validatedGuid;
            if (Helper.IsValidGId(guidofContactToBeDeleted, out validatedGuid))
            {
                return this._contactRepository.Delete(validatedGuid);
            }

            // Invalid Guid
            return "INVALID GUID";
        }

        /// <summary>
        /// Searching for Contact
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <returns>List</returns>
        public List<ContactInfo> SearchContact(string? name, string? phone, string? email, string? notes)
        {
            return this._contactRepository.Search(name, phone, email, notes);
        }

        /// <summary>
        /// Sorting
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> SortContact()
        {
            List<ContactInfo> sortedContactList = this._contactRepository.Show();
            sortedContactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
            return sortedContactList;
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
            if (Helper.IsValidName(name) == "VALID NAME")
            {
                string phoneRes = Helper.IsValidPhone(phone);
                if (phoneRes == "VALID PHONE")
                {
                    bool flag = this.IsPhoneExists(phone, id);
                    if (flag == true)
                    {
                        // PhoneNumber already exists
                        return "PHONE NUMBER ALREADY EXISTS";
                    }

                    if (Helper.IsValidEmail(email) == "VALID EMAIL")
                    {
                        return string.Empty;
                    }

                    // Invalid Email
                    return "INVALID EMAIL";
                }
                else
                {
                    return phoneRes;
                }
            }

            // INvalid Name
            return "INVALID NAME";
        }

        /// <summary>
        /// checks for existing phone number
        /// </summary>
        /// <param name="phone">ph</param>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        private bool IsPhoneExists(string? phone, Guid id)
        {
            List<ContactInfo> listForPhoneNumberCheck = this._contactRepository.Show();
            foreach (var contact in listForPhoneNumberCheck)
            {
                if (contact.Phone == phone && id != contact.Id)
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
            List<ContactInfo> list = this._contactRepository.Show();
            foreach (var contact in list)
            {
                if (contact.Id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
