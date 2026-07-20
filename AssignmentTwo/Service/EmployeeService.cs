using AssignmentTwo.Model.Employees;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// To provide service
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        /// to get the details
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>string</returns>
        public string GetDetails(Employee employee)
        {
            return employee.PrintDetails();
        }
    }
}
