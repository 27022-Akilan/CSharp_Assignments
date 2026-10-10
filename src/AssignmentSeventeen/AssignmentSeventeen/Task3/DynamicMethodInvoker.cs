using System.Reflection;
using SampleProject;

namespace AssignmentSeventeen.Task3
{
    /// <summary>
    /// Represents the functionalities for invoking the method dynamically.
    /// </summary>
    public class DynamicMethodInvoker
    {
        /// <summary>
        /// Invokes the method using the method name.
        /// </summary>
        /// <param name="methodName">Name of the method to be invoked.</param>
        public void InvokeMethod(string methodName)
        {
            StudentMarks studentMarks = new StudentMarks();
            Type type = studentMarks.GetType();

            MethodInfo? method = type.GetMethod(methodName);
            if (method == null)
            {
                Console.WriteLine("No method found !!!");
                return;
            }

            Console.WriteLine("Invoking the method...");
            method.Invoke(studentMarks, null);
        }
    }
}
