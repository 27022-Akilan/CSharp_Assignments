using System.Diagnostics;
using System.Reflection;
using AssignmentSeventeen.Enums;
using AssignmentSeventeen.IOHelper;
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
            bool isRunning = true;
            while (isRunning)
            {
                this.DisplayMenu();

                bool isValidEnum = InputReader.GetInput<MenuOption>(
                                                         "Enter your option : ",
                                                         InputValidator.GetEnumOption<MenuOption>,
                                                         out MenuOption option);

                if (!isValidEnum)
                {
                    continue;
                }

                switch (option)
                {
                    case MenuOption.AnalyzeAssembly:
                        ExternalAssemblyDemo externalAssemblyDemo = new ExternalAssemblyDemo();
                        Assembly assembly = externalAssemblyDemo.LoadAssembly();
                        externalAssemblyDemo.InspectAssemblyTypes(assembly);
                        break;
                    case MenuOption.DynamicObjectInspector:
                        this.HandleDynamicObjectInspector();
                        break;
                    case MenuOption.DynamicMethodInvoker:
                        DynamicMethodInvoker methodInvoker = new DynamicMethodInvoker();
                        methodInvoker.InvokeMethod("DisplayMarks");
                        break;
                    case MenuOption.DynamicTypeBuilder:
                        DynamicTypeBuilder typeBuilder = new DynamicTypeBuilder();
                        typeBuilder.ConstructClass();
                        break;
                    case MenuOption.PluginInspection:
                        PluginHost pluginHost = new PluginHost();
                        pluginHost.ManagePlugins();
                        break;
                    case MenuOption.MockFramework:
                        InterfaceMocker interfaceMocker = new InterfaceMocker();
                        interfaceMocker.MockInterface();
                        break;
                    case MenuOption.Serialization:
                        this.HandleSerialization();
                        break;
                    case MenuOption.Exit:
                        isRunning = false;
                        break;
                }
            }
        }

        private void HandleDynamicObjectInspector()
        {
            StudentMarks student1Mark = new StudentMarks();
            student1Mark.EnglishMark = 30;
            student1Mark.MathMark = 20;
            student1Mark.ScienceMark = 10;
            DynamicObjectInspector objectInspector = new DynamicObjectInspector();
            objectInspector.InspectObject(student1Mark);
            Console.WriteLine("After dynamically changing it.");
            student1Mark.DisplayMarks();
        }

        private void HandleSerialization()
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Akil",
                CGPA = 9.1,
                Subjects = new List<string> { "c#", "Java" },
            };
            ReflectionSerializer reflectionSerializer = new ReflectionSerializer();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"The serialized data is : \n{reflectionSerializer.Serialize(student)}");
            stopwatch.Stop();
            Console.WriteLine($"Time taken by reflection to serialize is : {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            DynamicSerializer serializer = new DynamicSerializer();
            string result = serializer.Serialize(student);
            stopwatch.Stop();
            Console.WriteLine($"The serialized data is : \n{result}");
            Console.WriteLine($"Time taken by reflection.emit to serialize is : {stopwatch.ElapsedMilliseconds}");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("==================================" +
                              "\n1.Analyze assembly" +
                              "\n2.Dynamic object inspector" +
                              "\n3.Dynamic method invoker" +
                              "\n4.Dynamic TypeBuilder" +
                              "\n5.Plugin Inspection" +
                              "\n6.Mock Framework" +
                              "\n7.Serialization" +
                              "\n8.Exit" +
                              "\n==================================");
        }
    }
}
