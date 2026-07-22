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
        /// <returns>ContactValidationResult</returns>
        public ContactValidationResult AddContact(ContactInfo contact)
        {
            Guid idToBeAdded = Guid.NewGuid();
            ContactInfo contactToBeAdded = new ContactInfo(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
            this._contactRepository.Add(contactToBeAdded, idToBeAdded);
            return ContactValidationResult.Success;
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
        /// <param name="stringValueToreplace">name</param>
        /// <param name="guid">user Input Guid</param>
        /// <param name="editOption">option for which field to be edited</param>
        /// <returns>ContactValidationResult</returns>
        public ContactValidationResult UpdateContact(string? stringValueToreplace, Guid guid, OptionForEdit editOption)
        {
            if (this._contactRepository.Edit(stringValueToreplace, guid, editOption))
            {
                return ContactValidationResult.Success;
            }

            return ContactValidationResult.GuidNotFound;
        }

        /// <summary>
        /// Deletes the contact
        /// </summary>
        /// <param name="id">Guid to delete</param>
        /// <returns>ContactContactValidationResult</returns>
        public ContactValidationResult DeleteContact(Guid id)
        {
            this._contactRepository.Delete(id);
            return ContactValidationResult.Success;
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
        /// Gets guid
        /// </summary>
        /// <param name="sno">sno </param>
        /// <returns>guid</returns>
        public Guid GetGuid(int sno)
        {
            List<ContactInfo> list = this._contactRepository.Show();
            if (sno < 1 || sno > list.Count)
            {
                return Guid.Empty;
            }

            ContactInfo contact = list[sno - 1];
            return contact.Id;
        }

        /// <summary>
        /// To check and add or edit contact based the provided information.
        /// </summary>
        /// <param name="name">nane</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="id">Guid</param>
        /// <returns>ContactValidationResult</returns>
        private ContactValidationResult IsValidNamePhoneEmail(string? name, string? phone, string? email, string? notes, Guid id)
        {
            if (Helper.IsValidName(name) == ContactValidationResult.ValidName)
            {
                ContactValidationResult phoneRes = Helper.IsValidPhone(phone);
                if (phoneRes == ContactValidationResult.ValidPhone)
                {
                    bool flag = this.IsPhoneExists(phone, id);
                    if (flag == true)
                    {
                        // PhoneNumber already exists
                        return ContactValidationResult.PhoneAlreadyExists;
                    }

                    if (Helper.IsValidEmail(email) == ContactValidationResult.ValidEmail)
                    {
                        return ContactValidationResult.Success;
                    }

                    // Invalid Email
                    return ContactValidationResult.InvalidEmail;
                }
                else
                {
                    return phoneRes == ContactValidationResult.InvalidPhoneLength
                        ? ContactValidationResult.InvalidPhoneLength
                        : ContactValidationResult.InvalidPhone;
                }
            }

            // Invalid Name
            return ContactValidationResult.InvalidName;
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
    }
}