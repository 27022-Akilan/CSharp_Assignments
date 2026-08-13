using AssignmentTwo;
using AssignmentTwo.Model.EnumModels;
using AssignmentTwo.View;

namespace Assignments
{
    /// <summary>
    /// Applications entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method where application starts
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            ShapeView shapeView = new ShapeView();
            EmployeeView employeeView = new EmployeeView();
            BankView accountView = new BankView();

            Option option;
            int choice;
            bool exit = false;
            do
            {
                Console.WriteLine(
                    "----------------------------------" +
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
                            shapeView.DisplayMenu();
                            break;
                        case Option.CreateAndViewEmployee:
                            employeeView.DisplayMenu();
                            break;
                        case Option.CreateAndViewAccount:
                            accountView.DisplayMenu();
                            break;
                        case Option.Exit:
                            Helper.DisplaySuccessMessage("Exiting!!");
                            exit = true;
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
            while (!exit);
        }
    }
}