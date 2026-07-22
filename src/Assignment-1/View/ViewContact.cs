using Assignment1.Models;
using Assignment1.Service;

namespace Assignment1.View
{
    /// <summary>
    /// View Contact class
    /// </summary>
    internal class ViewContact
    {
        private ContactService _contactService = new ContactService();

        /// <summary>
        /// Viewing contacts
        /// </summary>
        public void ViewContacts()
        {
            int choice;
            MenuOption option;
            do
            {
                Console.WriteLine("\n====================================" +
                "\n1.Add Contacts " +
                "\n2.Show Contacts " +
                "\n3.Edit Contacts " +
                "\n4.Delete Contacts" +
                "\n5.Sort Contacts" +
                "\n6.Search Contacts" +
                "\n7.Exit" +
                "\n====================================");
                Console.WriteLine("\nEnter the choice to navigate:");

                string? userInputString = Console.ReadLine();

                if (int.TryParse(userInputString, out choice))
                {
                    option = (MenuOption)choice;
                    switch (option)
                    {
                        // Add
                        case MenuOption.Add:
                            if (Helper.ReadNameAndValidate(out string? name) == ContactValidationResult.TrysCompleted
                                || Helper.ReadPhoneAndValidate(out string? phone) == ContactValidationResult.TrysCompleted
                                || Helper.ReadEmailAndValidate(out string? email) == ContactValidationResult.TrysCompleted
                                || Helper.ReadNotesAndValidate(out string? notes) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            ContactInfo contact = new ContactInfo(name, phone, email, notes, Guid.Empty);
                            ContactValidationResult res = this._contactService.AddContact(contact);

                            if (res == ContactValidationResult.Success)
                            {
                                Console.WriteLine("Contact Added");
                            }
                            else
                            {
                                Console.WriteLine("Cant be Added");
                                this.ReturnResultSimplification(res);
                            }

                            break;

                        // Show
                        case MenuOption.Show:
                            List<ContactInfo> contactList = this._contactService.GetContacts();
                            if (contactList.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                                break;
                            }

                            if (contactList.Count > 0)
                            {
                                this.PrintDetails(contactList);
                            }

                            break;

                        // Edit
                        case MenuOption.Edit:
                            contactList = this._contactService.GetContacts();
                            if (contactList.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                                break;
                            }

                            this.PrintDetails(contactList);
                            Console.WriteLine("Enter the S.No of the contact to be edited");
                            string? userInputSno = Console.ReadLine();
                            this.EditField(userInputSno);
                            break;

                        // Delete
                        case MenuOption.Delete:
                            contactList = this._contactService.GetContacts();
                            if (contactList.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                            }
                            else
                            {
                                this.PrintDetails(contactList);

                                Console.WriteLine("Enter the S.No of the contact to be deleted");
                                string? sNo = Console.ReadLine();
                                int validSNo;
                                if (!int.TryParse(sNo, out validSNo))
                                {
                                    Console.WriteLine(" Invalid Number Aborting");
                                    break;
                                }

                                Guid validGuid = this._contactService.GetGuid(validSNo);
                                ContactValidationResult result = this._contactService.DeleteContact(validGuid);

                                if (result == ContactValidationResult.Success)
                                {
                                    Console.WriteLine("Contact Deleted Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Cant Delete contact");
                                    this.ReturnResultSimplification(result);
                                }
                            }

                            break;

                        // Sort
                        case MenuOption.Sort:
                            List<ContactInfo> sortedContact = this._contactService.SortContact();
                            if (sortedContact.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                                break;
                            }

                            foreach (var x in sortedContact)
                            {
                                Console.WriteLine($"{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}");
                            }

                            break;

                        // Search
                        case MenuOption.Search:
                            Helper.GetInput(out name, out phone, out email, out notes);

                            List<ContactInfo> searchedlist = this._contactService.SearchContact(name, phone, email, notes);

                            if (searchedlist.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Contact Found");
                                this.PrintDetails(searchedlist);
                            }

                            break;

                        // Exit
                        case MenuOption.Exit:
                            Console.WriteLine("Exiting!!!!");
                            break;

                        default:
                            Console.WriteLine("Choose the correct number");
                            choice = -1;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Choose the correct number");
                    choice = -1;
                }
            }
            while (choice != 7);
        }

        /// <summary>
        /// Simplification method
        /// </summary>
        /// <param name="res">The result</param>
        public void ReturnResultSimplification(ContactValidationResult res)
        {
            switch (res)
            {
                case ContactValidationResult.InvalidName:
                    Console.WriteLine("Invalid Name!!");
                    break;

                case ContactValidationResult.PhoneAlreadyExists:
                    Console.WriteLine("The Phone Number Already Exists!!");
                    break;

                case ContactValidationResult.InvalidPhoneLength:
                    Console.WriteLine("Invalid Phone Number Length (Should be 10)");
                    break;

                case ContactValidationResult.InvalidPhone:
                    Console.WriteLine("Invalid Phone Number (Can only be numbers without spaces)");
                    break;

                case ContactValidationResult.GuidNotFound:
                    Console.WriteLine("Guid Not Found!!");
                    break;

                case ContactValidationResult.InvalidGuid:
                    Console.WriteLine("Invalid index!!");
                    break;

                case ContactValidationResult.InvalidEmail:
                    Console.WriteLine("Invalid Email!!");
                    break;
                case ContactValidationResult.ListEmpty:
                    Console.WriteLine("Contacts are empty!!");
                    break;
                default:
                    Console.WriteLine("Unrecognized result: " + res);
                    break;
            }
        }

        /// <summary>
        /// Edit a Particular field
        /// </summary>
        /// <param name="userInputSno">Input Guid from user</param>
        public void EditField(string? userInputSno)
        {
            bool flagForExit = false;
            OptionForEdit optionForEdit;
            if (int.TryParse(userInputSno, out int validUserInputSno))
            {
                Guid validGuid = this._contactService.GetGuid(validUserInputSno);
                if (validGuid == Guid.Empty)
                {
                    Console.WriteLine("SNo is Not between the Range");
                    return;
                }

                string? stringchoiceForEdit;
                Console.WriteLine("Edit?\n1.Name" +
                    "\n2.Phone NUmber" +
                    "\n3.Email" +
                    "\n4.Notes" +
                    "\n5.Exit");
                stringchoiceForEdit = Console.ReadLine();
                if (int.TryParse(stringchoiceForEdit, out int choiceForEdit))
                {
                    optionForEdit = (OptionForEdit)choiceForEdit;
                    switch (optionForEdit)
                    {
                        case OptionForEdit.Name:
                            if (Helper.ReadNameAndValidate(out string? editName) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            Console.WriteLine(this._contactService.UpdateContact(editName, validGuid, optionForEdit));
                            break;

                        case OptionForEdit.PhoneNumber:
                            if (Helper.ReadPhoneAndValidate(out string? editPhone) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            Console.WriteLine(this._contactService.UpdateContact(editPhone, validGuid, optionForEdit));
                            break;

                        case OptionForEdit.Email:
                            if (Helper.ReadEmailAndValidate(out string? editEmail) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            Console.WriteLine(this._contactService.UpdateContact(editEmail, validGuid, optionForEdit));
                            break;

                        case OptionForEdit.Notes:
                            if (Helper.ReadNotesAndValidate(out string? editNotes) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            Console.WriteLine(this._contactService.UpdateContact(editNotes, validGuid, optionForEdit));
                            break;
                        case OptionForEdit.Exit:
                            flagForExit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Choice!! only between 1-5");
                            break;
                    }

                    if (flagForExit)
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid Number for the Choice(Between 1 - 5)");
                }
            }
            else
            {
                this.ReturnResultSimplification(ContactValidationResult.InvalidGuid);
            }
        }

        /// <summary>
        /// Prints the Contacts
        /// </summary>
        /// <param name="contactList">ContactList</param>
        public void PrintDetails(List<ContactInfo> contactList)
        {
            int index = 1;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var x in contactList)
            {
                Console.WriteLine($"{index++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}");
            }

            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}