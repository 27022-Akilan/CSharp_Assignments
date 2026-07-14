using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Assignments
{
    /// <summary>
    /// this is the entry point
    /// </summary>
    public class Program
    {
        private static Dictionary<string, List<string>> contact= new Dictionary<string, List<string>>();
        /// <summary>
        /// this is the root class
        /// </summary>
        /// <param name="args">this is default</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Welcome to Contact Manager");
            int userInput;
            do
            {
                Console.Write("\n1.Add Contacts \n2.Show Contacts \n3.Edit Contacts \n4.Delete Contacts\n5.Sort Contacts\n6.Search Contacts\n7.Exit");
                Console.WriteLine("\nEnter the number to navigate");
                string? userInputString = Console.ReadLine();
                if (int.TryParse(userInputString, out userInput))
                {
                    if (userInput == 1)
                    {
                        AddContact();
                    }
                    else if (userInput == 2)
                    {
                        ShowContact();
                    }
                    else if (userInput == 3)
                    {
                        EditContact();
                    }
                    else if (userInput == 4)
                    {
                        DeleteContact();
                    }
                    else if (userInput == 5)
                    {
                        SortContact();
                    }
                    else if (userInput == 6)
                    {
                        string search = GetNameOrNum();
                        string res;
                        SearchContact(search, out res);
                    }
                }
                else
                {
                    Console.WriteLine("choose the crct num");
                    userInput = -1;
                }
            }
            while (userInput != 7);
            Console.WriteLine("Exited!!!");
        }

        /// <summary>
        /// To add the Contact
        /// </summary>
        private static void AddContact()
        {
            string? name;
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Cant be null or Empty!!");
                return;
            }

            if (contact.ContainsKey(name))
            {
                Console.WriteLine("Name already exists!!");
                return;
            }

            string? phone;
            while (true)
            {
                Console.WriteLine("Enter the Phone number");
                phone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phone))
                {
                    continue;
                }

                if (!long.TryParse(phone, out _))
                {
                    Console.WriteLine("Invalid Number");
                    continue;
                }

                bool exists = false;
                foreach (var details in contact.Values)
                {
                    if (details[0] == phone)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    Console.WriteLine("Number already exists");
                    continue;
                }

                break;
            }

            Console.WriteLine("Enter email");
            string? email = Console.ReadLine();

            Console.WriteLine("Enter Additional Info");
            string? addInfo = Console.ReadLine();
            contact[name] = new List<string>
        {
            phone,
            email,
            addInfo
        };

            Console.WriteLine("Contact Added Successfully");
        }

        /// <summary>
        /// to display all contacts
        /// </summary>
        private static void ShowContact()
        {
            if (contact.Count == 0)
            {
                Console.WriteLine("Empty!!!!");
            }

            foreach (string key in contact.Keys)
            {
                var ls = contact[key];
                Console.WriteLine(key + "\t" + ls[0] + "\t" + ls[1] + "\t" + ls[2]);
            }
        }

        /// <summary>
        /// to Edit the contacts
        /// </summary>
        private static void EditContact()
        {
            string search = GetNameOrNum();
            string res;
            int found = SearchContact(search, out res);
            if (found == 1)
            {
                bool canParse = false;
                int choice;

                do
                {
                    Console.WriteLine("10 for edit name \n20 for edit phone number \n30 for Edit email \n40 for edit additonal info \n50 for abort");
                    string? strCh = Console.ReadLine();
                    if (int.TryParse(strCh, out choice))
                    {
                        canParse = true;
                    }
                    else
                    {
                        canParse = false;
                        Console.WriteLine("Enter the choice(numbers)");
                    }
                }
                while (canParse == false);
                if (canParse)
                {
                    List<string> temp = contact[res];
                    if (choice == 10)
                    {
                        string? name;
                        while (true)
                        {
                            Console.WriteLine("Enter new name:");
                            name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Cant be null or Empty");
                                continue;
                            }

                            if (contact.ContainsKey(name))
                            {
                                Console.WriteLine("Name already exists!!");
                                continue;
                            }

                            break;
                        }

                        contact.Remove(res);
                        contact[name] = temp;
                    }

                    if (choice == 20)
                    {
                        string? newPh;
                        while (true)
                        {
                            Console.WriteLine("Enter new phone numeber");
                            newPh = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newPh))
                            {
                                Console.WriteLine("Number Cant be empty or null");
                                continue;
                            }

                            if (!long.TryParse(newPh, out _))
                            {
                                Console.WriteLine("Enter only number no letters");
                                continue;
                            }

                            bool canChange = true;
                            foreach (var findName in contact.Keys)
                            {
                                if (findName == res)
                                {
                                    continue;
                                }

                                List<string> details = contact[findName];
                                if (details[0] == newPh)
                                {
                                    canChange = false;
                                    break;
                                }
                            }

                            if (!canChange)
                            {
                                Console.WriteLine("Already this number exists cant update");
                                continue;
                            }

                            temp[0] = newPh;
                            break;
                        }
                    }

                    if (choice == 30)
                    {
                        Console.WriteLine("Enter new email");
                        string newEmail = Console.ReadLine();
                        temp[1] = newEmail;
                    }

                    if (choice == 40)
                    {
                        Console.WriteLine("Enter new additional info");
                        string newAddCon = Console.ReadLine();
                        temp[2] = newAddCon;
                    }

                    if (choice == 50)
                    {
                        Console.WriteLine("Aborted");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Not found!!!");
            }
        }
        /// <summary>
        /// to search the contacts
        /// </summary>
        /// <param name="search">Name or number to be Searched</param>
        /// <param name="res">returns the name of the founded contact</param>
        /// <returns>Returns found or not</returns>
        private static int SearchContact(string search, out string res)
        {
            if (contact.ContainsKey(search))
            {
                res = search;
                Console.WriteLine($"{res} {string.Join("\t", contact[search])} ");
                return 1;
            }

            foreach (string key in contact.Keys)
            {
                List<string> ls = contact[key];
                if (ls[0] == search)
                {
                    res = key;
                    Console.WriteLine($"{res} {string.Join("\t", contact[key])} ");
                    return 1;
                }
            }

            res = null;
            return 0;
        }
        /// <summary>
        /// To Delete the contact
        /// </summary>
        private static void DeleteContact()
        {
            Console.WriteLine("Enter name or number to be searched");
            string? search;
            search = Console.ReadLine();
            string res;
            if (!string.IsNullOrWhiteSpace(search))
            {
                int found = SearchContact(search, out res);
                if (found == 1)
                {
                    contact.Remove(res);
                    Console.WriteLine("Contact deleted");
                }
                else
                {
                    Console.WriteLine("No contact found");
                }
            }
        }
        /// <summary>
        /// to sort the contact
        /// </summary>
        private static void SortContact()
        {
            var sortedContact = contact.OrderBy(k => k.Key);

            foreach (var k in sortedContact)
            {
                Console.WriteLine($"{k.Key}\t{string.Join("\t", k.Value)} ");
            }
        }

        /// <summary>
        /// To get the name or number
        /// </summary>
        /// <returns>returns name or number</returns>
        private static string GetNameOrNum()
        {
            Console.WriteLine("Enter name or number to be searched");
            string? search;
            search = Console.ReadLine();
            return search;
        }
    }
}