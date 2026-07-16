using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Method for viewing contacts
        /// </summary>
        public void ViewContacts()
        {
            ContactService contactService = new ContactService();
            int userInput;
            do
            {
                Console.WriteLine("1.Add Contacts \n2.Show Contacts \n3.Edit Contacts \n4.Delete Contacts\n5.Sort Contacts\n6.Search Contacts\n7.Exit");
                Console.WriteLine("\nEnter the number to navigate");
                string? userInputString = Console.ReadLine();
                if (int.TryParse(userInputString, out userInput))
                {
                    // ADD
                    if (userInput == 1)
                    {
                        Helper.GetInput(out string? name, out string? phone, out string? email, out string? notes);
                        if (Helper.IsNotNull(name, phone, email, notes))
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
                            Console.WriteLine("Cant Add");
                        }
                    }

                    // display
                    else if (userInput == 2)
                    {
                        List<ContactInfo> contactList = contactService.Show();
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
                    }

                    // edit
                    else if (userInput == 3)
                    {
                        List<ContactInfo> contactList = contactService.Show();
                        long indx = 1;
                        foreach (var x in contactList)
                        {
                            Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                        }

                        Console.WriteLine("Enter the GUID of the contact to be edited");
                        string? userInp = Console.ReadLine();
                        Helper.GetInput(out string? name, out string? phone, out string? email, out string? notes);
                        string res = contactService.EditContact(name, phone, email, notes, userInp);
                        if (res == string.Empty)
                        {
                            Console.WriteLine("Edited Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Cant be Edited");
                            if (res == "IG")
                            {
                                Console.WriteLine("Invalid GUiID");
                            }
                            else
                            {
                                this.ReturnResultSimplification(res);
                            }
                        }
                    }

                    // delete
                    else if (userInput == 4)
                    {
                        List<ContactInfo> contactList = contactService.Show();
                        long indx = 1;
                        foreach (var x in contactList)
                        {
                            Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                        }

                        Console.WriteLine("Enter the GUI ID to be deleted");
                        string? userChoice = Console.ReadLine();
                        string res = contactService.DeleteContact(userChoice);
                        if (res == string.Empty)
                        {
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Cant Delete contact");
                            if (res == "IG")
                            {
                                Console.WriteLine("Ivalid Gui Id Type");
                            }
                            else
                            {
                                Console.WriteLine("ID not found on the contact");
                            }
                        }
                    }
                    else if (userInput == 5)
                    {
                        List<ContactInfo> sortedContact = contactService.SortContact();
                        foreach (var x in sortedContact)
                        {
                            Console.WriteLine($"{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}");
                        }
                    }

                    // search
                    else if (userInput == 6)
                    {
                        Helper.GetInput(out string? name, out string? phone, out string? email, out string? notes);
                        List<ContactInfo> searchedlist = contactService.SearchContact(name, phone, email, notes);
                        if (searchedlist.Count == 0)
                        {
                            Console.WriteLine("No Contact Found");
                        }
                        else
                        {
                            Console.WriteLine("Contact Found");
                            int indx = 1;
                            foreach (var x in searchedlist)
                            {
                                Console.WriteLine($"{indx++}\t{x.Name}\t{x.Phone}\t{x.Email}\t{x.Notes}\t{x.Id}");
                            }
                        }
                    }
                    else if (userInput == 7)
                    {
                        Console.WriteLine("Exiting!!!!");
                    }
                }
                else
                {
                    Console.WriteLine("choose the crct num");
                    userInput = -1;
                }
            }
            while (userInput != 7);
        }

        /// <summary>
        /// Simplication method
        /// </summary>
        /// <param name="res">the result </param>
        public void ReturnResultSimplification(string res)
        {
            if (res == "IN")
            {
                Console.WriteLine("Invalid Name");
            }
            else if (res == "IPL")
            {
                Console.WriteLine("Invalid Phone NUmber Length (Should be 10)");
            }
            else if (res == "IP")
            {
                Console.WriteLine("Invalid Phone Number (Can only be numbers without spaces)");
            }
            else
            {
                Console.WriteLine("Invalid Email");
            }
        }
    }
}
