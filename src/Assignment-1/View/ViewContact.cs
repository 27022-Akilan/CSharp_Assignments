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
                Console.WriteLine("\n1.Add Contacts \n2.Show Contacts \n3.Edit Contacts \n4.Delete Contacts\n5.Sort Contacts\n6.Search Contacts\n7.Exit");
                Console.WriteLine("\nEnter the number to navigate");

                string? userInputString = Console.ReadLine();

                if (int.TryParse(userInputString, out choice))
                {
                    option = (MenuOption)choice;
                    switch (option)
                    {
                        // Add
                        case MenuOption.Add:
                            Helper.GetInput(out string? name, out string? phone, out string? email, out string? notes);

                            if (Helper.IsNotNull(name, phone))
                            {
                                ContactInfo contact = new ContactInfo(name, phone, email, notes, Guid.Empty);
                                string res = contactService.AddContact(contact);

                                if (res == string.Empty)
                                {
                                    Console.WriteLine("Added");
                                }
                                else
                                {
                                    Console.WriteLine("Cant be Added");
                                    this.ReturnResultSimplification(res);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Name or Number cant be Empty");
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

                            Console.WriteLine("Enter the GUID of the contact to be edited");
                            string? userInp = Console.ReadLine();

                            Helper.GetInput(out name, out phone, out email, out notes);

                            string result = contactService.UpdateContact(name, phone, email, notes, userInp);

                            if (result == string.Empty)
                            {
                                Console.WriteLine("Edited Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Cant be Edited");

                                if (result == "INVALID GUID")
                                {
                                    Console.Write("\t Invalid GUiID");
                                }
                                else
                                {
                                    this.ReturnResultSimplification(result);
                                }
                            }

                            break;

                        // Delete
                        case MenuOption.Delete:
                            contactList = contactService.GetContacts();
                            indx = 1;

                            foreach (var x in contactList)
                            {
                                Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                            }

                            Console.WriteLine("Enter the GUID to be deleted");
                            string? guidToDelete = Console.ReadLine();

                            result = contactService.DeleteContact(guidToDelete);

                            if (result == string.Empty)
                            {
                                Console.WriteLine("Contact Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Cant Delete contact");

                                if (result == "INVALID GUID")
                                {
                                    Console.Write("\t Ivalid Gui Id Type");
                                }
                                else
                                {
                                    Console.Write("\t ID not found on the contact");
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
        public void ReturnResultSimplification(string res)
        {
            switch (res)
            {
                case "INVALID NAME":
                    Console.Write(" Invalid Name");
                    break;

                case "PHONE ALREADY EXISTS":
                    Console.Write(" The Phone Number Already Exists");
                    break;

                case "INVALID PHONE LENGTH":
                    Console.Write(" Invalid Phone Number Length (Should be 10)");
                    break;

                case "INVALID PHONE":
                    Console.Write(" Invalid Phone Number (Can only be numbers without spaces)");
                    break;
                case "GUID NOT FOUND":
                    Console.Write(" Guid Not Found");
                    break;
                default:
                    Console.Write(" Invalid Email");
                    break;
            }
        }
    }
}