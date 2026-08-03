using AssignmentTwo;
using AssignmentTwo.Model;
using AssignmentTwo.View;

namespace Assignments
{
    /// <summary>
    /// This is the base program's entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Its the main method to start the application.
        /// </summary>
        /// <param name="args">Default args</param>
        public static void Main(string[] args)
        {
            Option option;
            int choice;
            do
            {
                Console.WriteLine("----------------------------------" +
                    "\n1.Shape    - Task 1" +
                    "\n2.Employee - Task 2 " +
                    "\n3.Account  - Task 3" +
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
                            viewAccount.DisplayMenu();
                            break;
                        case Option.Exit:
                            Helper.DisplaySuccessMessage("Exiting!!");
                            break;
                        default:
                            Helper.DisplayFailedMessage("Enter valid number between 1 to 4");
                            break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Enter a valid number , you didn't enter a number");
                }
            }
            while (choice != 4);
        }
    }
}