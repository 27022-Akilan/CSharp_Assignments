using AssignmentTwo.Model.Employees;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// to view the employees
    /// </summary>
    public class ViewEmployee
    {
        private EmployeeService _employeeService = new EmployeeService();

        /// <summary>
        /// Entry point into service
        /// </summary>
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Create and view Manager \n2.Create and View Developer \n3.Exit \nEnter Your Choice ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        // Manager
                        case 1:
                            string name;
                            double salary;
                            GetNameAndSalary(out name, out salary);
                            Console.WriteLine(this._employeeService.GetDetails(new Manager(name, salary)));
                            break;

                        // Developer
                        case 2:
                            GetNameAndSalary(out name, out salary);
                            Console.WriteLine(this._employeeService.GetDetails(new Developer(name, salary)));
                            break;
                        case 3:
                            Console.WriteLine("Exiting!!!!");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not a Number!!");
                }
            }
            while (choice != 3);
        }

        private static void GetNameAndSalary(out string employeeName, out double employeeSalary)
        {
            do
            {
                Console.WriteLine("Enter the Name");
                string? name = Console.ReadLine() ?? string.Empty;
                if (Helper.IsValidWord(name))
                {
                    employeeName = name;
                    break;
                }

                Console.WriteLine("Invalid Name!");
            }
            while (true);

            do
            {
                Console.WriteLine("Enter the Salary");
                string? salary = Console.ReadLine() ?? string.Empty;
                if (Helper.IsNumber(salary, out double resSalary))
                {
                    employeeSalary = resSalary;
                    break;
                }

                Console.WriteLine("Invalid salary!");
            }
            while (true);
        }
    }
}
