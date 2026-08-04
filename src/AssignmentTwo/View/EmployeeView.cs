using AssignmentTwo.Model;
using AssignmentTwo.Model.Employees;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// to view the employees
    /// </summary>
    public class EmployeeView
    {
        private EmployeeService _employeeService = new EmployeeService();

        /// <summary>
        /// Entry point to service
        /// </summary>
        public void Menu()
        {
            OptionForEmployee employeeOption;
            int choice;
            do
            {
                Console.WriteLine("--------------------------------------" +
                    "\n1.Create and view Manager " +
                    "\n2.Create and View Developer " +
                    "\n3.Exit " +
                    "\n--------------------------------------" +
                    "\nEnter Your Choice ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    employeeOption = (OptionForEmployee)choice;
                    switch (employeeOption)
                    {
                        // Manager
                        case OptionForEmployee.CreateAndViewManager:
                            if (!GetNameAndSalary(out string employeeName, out decimal employeeSalary))
                            {
                                break;
                            }

                            Helper.DisplaySuccessMessage(this._employeeService.GetDetails(new Manager(employeeName, employeeSalary)));
                            break;

                        // Developer
                        case OptionForEmployee.CreateAndViewDeveloper:

                            if (!GetNameAndSalary(out employeeName, out employeeSalary))
                            {
                                break;
                            }

                            Helper.DisplaySuccessMessage(this._employeeService.GetDetails(new Developer(employeeName, employeeSalary)));
                            break;

                        // Exit
                        case OptionForEmployee.Exit:
                            Helper.DisplaySuccessMessage("Exiting!!");
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
            while (choice != 3);
        }

        private static bool GetNameAndSalary(out string employeeName, out decimal salary)
        {
            salary = 0;
            bool getNameOutOfTrys = Helper.GetName(out employeeName);
            if (getNameOutOfTrys)
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
