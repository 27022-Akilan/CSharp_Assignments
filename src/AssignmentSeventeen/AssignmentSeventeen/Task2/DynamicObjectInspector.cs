using System.Reflection;
using SampleProject;

namespace AssignmentSeventeen.Task2
{
    /// <summary>
    /// Represents the functionalities to dynamically inspect the object.
    /// </summary>
    public class DynamicObjectInspector
    {
        /// <summary>
        /// Inspects the object dynamically and change it.
        /// </summary>
        /// <param name="studentMark">Students mark.</param>
        public void InspectObject(StudentMarks studentMark)
        {
            Type type = studentMark.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                object? value = property.GetValue(studentMark);
                Console.WriteLine($"Old value Property Name :{propertyName} Value : {value}");
                Console.WriteLine($"Now changing the {propertyName} to 100");
                property.SetValue(studentMark, 100);
            }
        }

        ///// <summary>
        ///// Displays the marks of the student.
        ///// </summary>
        ///// <param name="studentMark">Student mark</param>
        //public void DisplayInformation(StudentMarks studentMark)
        //{
        //    Type type = studentMark.GetType();

        //    PropertyInfo[] properties = type.GetProperties();

        //    foreach (PropertyInfo property in properties)
        //    {
        //        string propertyName = property.Name;
        //        object? value = property.GetValue(studentMark);
        //        Console.WriteLine($"Property Name :{propertyName} Value : {value}");
        //    }
        //}
    }
}
