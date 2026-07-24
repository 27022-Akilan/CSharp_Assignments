using AssignmentTwo;
using AssignmentTwo.Model;
using AssignmentTwo.View;

namespace Assignments
{
    /// <summary>
    /// THis is the basse prgrm entry point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// THis is the entry point
        /// </summary>
        /// <param name="args">Default args</param>
        public static void Main(string[] args)
        {
            Option option;
            int choice;
            do
            {
                Console.WriteLine("----------------------------------" +
                    "\n1.Shape " +
                    "\n2.Employee " +
                    "\n3.Account " +
                    "\n4.Exit" +
                    "\n----------------------------------" +
                    "\nEnter Your Choice");
                string? ch = Console.ReadLine();

                if (int.TryParse(ch, out choice))
                {
                    option = (Option)choice;
                    switch (option)
                    {
                        case Option.CreateAndViewShape:
                            ShapeView viewShape = new ShapeView();
                            viewShape.Menu();
                            break;
                        case Option.CreateAndViewEmployee:
                            EmployeeView viewEmployee = new EmployeeView();
                            viewEmployee.Menu();
                            break;
                        case Option.CreateAndViewAccount:
                            BankView viewAccount = new BankView();
                            viewAccount.Menu();
                            break;
                        case Option.Exit:
                            Console.WriteLine("Exiting!!");
                            break;
                        default:
                            Helper.WriteFailed("Enter valid number between 1 to 4");
                            break;
                    }
                }
                else
                {
                    Helper.WriteFailed("Enter a valid number , you didnt enter a number");
                }
            }
            while (choice != 4);
        }
    }
}