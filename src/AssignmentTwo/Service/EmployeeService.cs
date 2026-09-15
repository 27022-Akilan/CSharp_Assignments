using AssignmentTwo.Model.Employees;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// To provide services for the Employee Management
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        ///  To Get the details of the Employee
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>String - Holds the entire information about the Employee</returns>
        public string GetDetails(Employee employee)
        {
            return employee.PrintDetails();
        }
    }
}
