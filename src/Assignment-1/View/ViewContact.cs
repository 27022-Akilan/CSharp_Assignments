using Assignment1.Models;
using Assignment1.Service;

namespace Assignment1.View
{
    /// <summary>
    /// View Contact class
    /// </summary>
    internal class ViewContact
    {
        /// <summary>
        /// Viewing contacts
        /// </summary>
        public void ViewContacts()
        {
            ContactService contactService = new ContactService();
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
                Console.WriteLine("\nEnter the number to navigate");

                string? userInputString = Console.ReadLine();

                if (int.TryParse(userInputString, out choice))
                {
                    option = (MenuOption)choice;
                    switch (option)
                    {
                        // Add
                        case MenuOption.Add:
                            if (Helper.ReadNameAndValidate(out string? name) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            if (Helper.ReadPhoneAndValidate(out string? phone) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            if (Helper.ReadEmailAndValidate(out string? email) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            if (Helper.ReadNotesAndValidate(out string? notes) == ContactValidationResult.TrysCompleted)
                            {
                                break;
                            }

                            // Console.WriteLine("hii before call");
                            ContactInfo contact = new ContactInfo(name, phone, email, notes, Guid.Empty);
                            ContactValidationResult res = contactService.AddContact(contact);

                            // Console.WriteLine("hii after call");
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
                            List<ContactInfo> contactList = contactService.GetContacts();
                            long indx = 1;

                            if (contactList.Count > 0)
                            {
                                foreach (var x in contactList)
                                {
                                    Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Empty No Contacts!!!");
                            }

                            break;

                        // Edit
                        case MenuOption.Edit:
                            contactList = contactService.GetContacts();
                            indx = 1;

                            foreach (var x in contactList)
                            {
                                Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                            }

                            bool flagForExit = false;
                            OptionForEdit optionForEdit;
                            Console.WriteLine("Enter the GUID of the contact to be edited");
                            string? userInputGuid = Console.ReadLine();
                            if (Guid.TryParse(userInputGuid, out Guid validGuid))
                            {
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

                                            Console.WriteLine(contactService.UpdateContact(editName, validGuid, optionForEdit));
                                            break;

                                        case OptionForEdit.PhoneNumber:
                                            if (Helper.ReadPhoneAndValidate(out string? editPhone) == ContactValidationResult.TrysCompleted)
                                            {
                                                break;
                                            }

                                            Console.WriteLine(contactService.UpdateContact(editPhone, validGuid, optionForEdit));
                                            break;

                                        case OptionForEdit.Email:
                                            if (Helper.ReadEmailAndValidate(out string? editEmail) == ContactValidationResult.TrysCompleted)
                                            {
                                                break;
                                            }

                                            Console.WriteLine(contactService.UpdateContact(editEmail, validGuid, optionForEdit));
                                            break;

                                        case OptionForEdit.Notes:
                                            if (Helper.ReadNameAndValidate(out string? editNotes) == ContactValidationResult.TrysCompleted)
                                            {
                                                break;
                                            }

                                            Console.WriteLine(contactService.UpdateContact(editNotes, validGuid, optionForEdit));
                                            break;
                                        case OptionForEdit.Exit:
                                            flagForExit = true;
                                            break;
                                    }

                                    if (flagForExit)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter Valid Number Choice");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not a type of Guid");
                            }

                            break;

                        // Delete
                        case MenuOption.Delete:
                            contactList = contactService.GetContacts();
                            indx = 1;
                            if (contactList.Count == 0)
                            {
                                this.ReturnResultSimplification(ContactValidationResult.ListEmpty);
                            }
                            else
                            {
                                foreach (var x in contactList)
                                {
                                    Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                                }

                                Console.WriteLine("Enter the GUID to be deleted");
                                string? guidToDelete = Console.ReadLine();

                                ContactValidationResult result = contactService.DeleteContact(guidToDelete);

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
                            List<ContactInfo> sortedContact = contactService.SortContact();

                            foreach (var x in sortedContact)
                            {
                                Console.WriteLine($"{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}");
                            }

                            break;

                        // Search
                        case MenuOption.Search:
                            Helper.GetInput(out name, out phone, out email, out notes);

                            List<ContactInfo> searchedlist = contactService.SearchContact(name, phone, email, notes);

                            if (searchedlist.Count == 0)
                            {
                                Console.WriteLine("No Contact Found");
                            }
                            else
                            {
                                Console.WriteLine("Contact Found");
                                indx = 1;

                                foreach (var x in searchedlist)
                                {
                                    Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                                }
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
                    Console.WriteLine("Invalid Name");
                    break;

                case ContactValidationResult.PhoneAlreadyExists:
                    Console.WriteLine("The Phone Number Already Exists");
                    break;

                case ContactValidationResult.InvalidPhoneLength:
                    Console.WriteLine("Invalid Phone Number Length (Should be 10)");
                    break;

                case ContactValidationResult.InvalidPhone:
                    Console.WriteLine("Invalid Phone Number (Can only be numbers without spaces)");
                    break;

                case ContactValidationResult.GuidNotFound:
                    Console.WriteLine("Guid Not Found");
                    break;

                case ContactValidationResult.InvalidGuid:
                    Console.WriteLine("Invalid GUID");
                    break;

                case ContactValidationResult.InvalidEmail:
                    Console.WriteLine("Invalid Email");
                    break;
                case ContactValidationResult.ListEmpty:
                    Console.WriteLine("Contacts are empty!!");
                    break;
                default:
                    Console.WriteLine("Unrecognized result: " + res);
                    break;
            }
        }
    }
}