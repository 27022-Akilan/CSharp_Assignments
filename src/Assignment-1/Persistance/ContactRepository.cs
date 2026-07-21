using Assignment1.Models;

namespace Assignment1.Persistance
{
    /// <summary>
    /// To store and fetch
    /// </summary>
    internal class ContactRepository
    {
        private readonly List<ContactInfo> _contactInfoList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        public ContactRepository()
        {
            this._contactInfoList = new List<ContactInfo>();
        }

        /// <summary>
        /// Adds a contact with the given id.
        /// </summary>
        /// <param name="contact">Contact object</param>
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
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <param name="notes">notes</param>
        /// <param name="id">id</param>
        /// < returns>bool</returns>
        public bool Edit(string? name, string? phone, string? email, string? notes, Guid id)
        {
            foreach (var x in this._contactInfoList)
            {
                if (x.Id == id)
                {
                    x.Name = name;
                    x.Phone = phone;
                    x.Email = email;
                    x.Notes = notes;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Deleting the contact
        /// </summary>
        /// <param name="guidOfTheCotactToBeDeleted">Guid</param>
        /// <returns>string</returns>
        public string Delete(Guid guidOfTheCotactToBeDeleted)
        {
            foreach (var x in this._contactInfoList)
            {
                if (x.Id == guidOfTheCotactToBeDeleted)
                {
                    this._contactInfoList.Remove(x);
                    return string.Empty;
                }
            }

            // Guid Not found
            return "GUID NOT FOUND";
        }

        /// <summary>
        /// To return a cloned list.
        /// </summary>
        /// <returns>list</returns>
        public List<ContactInfo> Show()
        {
            return this._contactInfoList.Select(c => new ContactInfo(c.Name, c.Phone, c.Email, c.Notes, c.Id)).ToList();
        }

        /// <summary>
        /// To return the Search results
        /// </summary>
        /// <param name="inputName">name</param>
        /// <param name="inputPhone">phone</param>
        /// <param name="inputEmail">email</param>
        /// <param name="inputNotes">notes</param>
        /// <returns>Searched contact list</returns>
        public List<ContactInfo> Search(string? inputName, string? inputPhone, string? inputEmail, string? inputNotes)
        {
            List<ContactInfo> searchedContactList = new List<ContactInfo>();

            foreach (var contact in this._contactInfoList)
            {
                if (Helper.Compare(contact.Name, inputName)
                    || Helper.Compare(contact.Phone, inputPhone)
                    || Helper.Compare(contact.Email, inputEmail)
                    || Helper.Compare(contact.Notes, inputNotes))
                {
                    ContactInfo clonedContactList = new ContactInfo(contact.Name, contact.Phone, contact.Email, contact.Notes, contact.Id);
                    searchedContactList.Add(clonedContactList);
                }
            }

            return searchedContactList;
        }
    }
}