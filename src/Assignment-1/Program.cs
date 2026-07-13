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
                        //SortContact();
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
        public static void AddContact()
        {
            string? name;
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Cant be null");
            }
            else if (contact.ContainsKey(name))
            {
                Console.WriteLine("Name already exists!!");
            }
            else
            {
                List<string> list = new List<string>() {null, null, null};
                contact[name] = list;
                string? string_number;
                do
                {
                    Console.WriteLine("Enter the phone number");
                    string_number = Console.ReadLine();
                }
                while (string_number.Length == 0);
                long number;
                if (long.TryParse(string_number, out number))
                {
                    bool exists = false;
                    foreach (var ls in contact.Values)
                    {
                        if (ls[0] == string_number)
                        {
                            Console.WriteLine("Already number exists");
                            exists = true;
                            AddContact();
                        }
                    }
                    if (exists == false)
                    {
                        list[0] = string_number;
                    }
                }
                string? email = null;
                Console.WriteLine("Enter email");
                email = Console.ReadLine();
                List<string> info = contact[name];
                if (email != null)
                {
                    info[1] = email;
                }
                Console.WriteLine("Enter additonal info");
                string? addInfo = Console.ReadLine();
                if (addInfo != null)
                {
                    info[2] = addInfo;
                }
            }
        }

        /// <summary>
        /// to display all contacts
        /// </summary>
        public static void ShowContact()
        {
            if (contact.Count == 0)
            {
                Console.WriteLine("Empty!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
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
        public static void EditContact()
        {
            string search = GetNameOrNum();
            string res;
            int found = SearchContact(search, out res);
            if (found == 1)
            {
                bool canParse = false;
                int choice;
                Console.WriteLine("10 for edit name \n20 for edit phone number \n30 for Edit email \n40 for edit additonal info \n50 for abort");
                string? strCh = Console.ReadLine();
                if (int.TryParse(strCh, out choice))
                {
                    canParse = true;
                }
                else
                {
                    canParse = false;
                }

                if (canParse)
                {
                    List<string> temp = contact[res];
                    if (choice == 10)
                    {
                        contact.Remove(res);
                        string? name;
                        Console.WriteLine("Enter new name:");
                        name = Console.ReadLine();
                        if (name == null)
                        {
                            Console.WriteLine("Cant be null");
                        }
                        else if (contact.ContainsKey(name))
                        {
                            Console.WriteLine("Name already exists!!");
                        }
                        else
                        {
                            contact[name] = temp;
                        }
                    }

                    if (choice == 20)
                    {
                        Console.WriteLine("Enter new phone numeber");
                        string? newPh;
                        newPh = Console.ReadLine();
                        long number;
                        if (long.TryParse(newPh, out number))
                        {
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

                            if (canChange)
                            {
                                temp[0] = newPh;
                            }
                            else
                            {
                                Console.WriteLine("Already this number exists cant update");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empty or invalid number!! Aborting ");
                        }
                    }

                    if (choice == 30)
                    {
                        Console.WriteLine("Enter new email");
                        string newEmail=Console.ReadLine();
                        temp[1] = newEmail;
                    }

                    if (choice == 40)
                    {
                        Console.WriteLine("Enter new additional info");
                        string newAddCon = Console.ReadLine();
                        temp[2] = newAddCon;
                    }

                    if(choice == 50)
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
        private static int SearchContact(string search, out string res)
        {
            if (contact.ContainsKey(search))
            {
                res = search;
                Console.WriteLine($"{res}    {string.Join("\t", contact[search])} ");
                return 1;
            }
            foreach (string key in contact.Keys)
            {
                List<string> ls = contact[key];
                if (ls[0] == search)
                {
                    res = key;
                    Console.WriteLine($"{res}    {string.Join("\t", contact[key])} ");
                    return 1;
                }
            }

            res =null;
            return 0;
        }

        private static void DeleteContact()
        {
            Console.WriteLine("enter name or number to be searched");
            string? search;
            search = Console.ReadLine();
            string res;
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

        private static string GetNameOrNum()
        {
            Console.WriteLine("Enter name or number to be searched");
            string? search;
            search = Console.ReadLine();
            return search;
        }
    }
}