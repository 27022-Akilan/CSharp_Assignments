using System.Reflection;
using AssignmentSeventeen.Task1;
using AssignmentSeventeen.Task2;
using AssignmentSeventeen.Task3;
using AssignmentSeventeen.Task4;
using AssignmentSeventeen.Task5;
using AssignmentSeventeen.Task6;
using AssignmentSeventeen.Task7;
using SampleProject;

namespace AssignmentSeventeen
{
    /// <summary>
    /// Represents the navigation of the menu.
    /// </summary>
    public class MenuNavigator
    {
        /// <summary>
        /// Navigates the menu.
        /// </summary>
        public void NavigateMenu()
        {
            ExternalAssemblyDemo externalAssemblyDemo = new ExternalAssemblyDemo();
            Assembly assembly = externalAssemblyDemo.LoadAssembly();
            externalAssemblyDemo.InspectAssemblyTypes(assembly);

            StudentMarks student1Mark = new StudentMarks();
            student1Mark.EnglishMark = 30;
            student1Mark.MathMark = 20;
            student1Mark.ScienceMark = 10;
            DynamicObjectInspector objectInspector = new DynamicObjectInspector();
            objectInspector.InspectObject(student1Mark);
            Console.WriteLine("After dynamically changing it.");
            student1Mark.DisplayMarks();

            DynamicMethodInvoker methodInvoker = new DynamicMethodInvoker();
            methodInvoker.InvokeMethod("DisplayMarks");

            DynamicTypeBuilder typeBuilder = new DynamicTypeBuilder();
            typeBuilder.ConstructClass();

            PluginHost pluginHost = new PluginHost();
            pluginHost.ManagePlugins();

            InterfaceMocker interfaceMocker = new InterfaceMocker();
            interfaceMocker.MockInterface();

            Student student = new Student
            {
                Id = 1,
                Name = "Akil",
                CGPA = 9.1,
                Subjects = new List<string> { "c#", "Java" },
            };
            ReflectionSerializer reflectionSerializer = new ReflectionSerializer();
            Console.WriteLine($"{reflectionSerializer.Serialize(student)}");
        }
    }
}
