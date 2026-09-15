using AssignmentTwo.Model.Employees;
using AssignmentTwo.Model.EnumModels;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// To view the employees
    /// </summary>
    public class EmployeeView
    {
        private EmployeeService _employeeService = new EmployeeService();

        /// <summary>
        /// Displays the Menu for accessing Employee operations
        /// </summary>
        public void DisplayMenu()
        {
            EmployeeOption employeeOption;
            int choice;
            bool exit = false;
            do
            {
                Console.WriteLine(
                    "--------------------------------------" +
                    "\n1.Create and view Manager " +
                    "\n2.Create and View Developer " +
                    "\n3.Exit " +
                    "\n--------------------------------------" +
                    "\nEnter Your Choice ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    employeeOption = (EmployeeOption)choice;
                    switch (employeeOption)
                    {
                        // Manager
                        case EmployeeOption.CreateAndViewManager:
                            if (!GetNameAndSalary(out string employeeName, out decimal employeeSalary))
                            {
                                break;
                            }

                            Helper.DisplaySuccessMessage(this._employeeService.GetDetails(new Manager(employeeName, employeeSalary)));
                            break;

                        // Developer
                        case EmployeeOption.CreateAndViewDeveloper:

                            if (!GetNameAndSalary(out employeeName, out employeeSalary))
                            {
                                break;
                            }

                            Helper.DisplaySuccessMessage(this._employeeService.GetDetails(new Developer(employeeName, employeeSalary)));
                            break;

                        // Exit
                        case EmployeeOption.Exit:
                            Helper.DisplaySuccessMessage("Exiting!!");
                            exit = true;
                            break;
                        default:
                            Helper.DisplayFailedMessage("Invalid Choice , You must only between 1 to 3");
                            break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Invalid choice , You must enter a number only");
                }
            }
            while (!exit);
        }

        private static bool GetNameAndSalary(out string employeeName, out decimal salary)
        {
            salary = 0;
            bool getName = Helper.GetName(out employeeName);
            if (!getName)
            {
                Helper.DisplayFailedMessage("Due to Out Of Tries, Exiting!");
                return false;
            }

            salary = Helper.GetValidQuantity("Salary", "rs");
            if (salary == -1)
            {
                Helper.DisplayFailedMessage("Due to Out Of Tries, Exiting!");
                return false;
            }

            return true;
        }
    }
}
