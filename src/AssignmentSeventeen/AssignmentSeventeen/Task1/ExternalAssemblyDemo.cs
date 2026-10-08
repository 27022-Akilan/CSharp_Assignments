using System.Reflection;

namespace AssignmentSeventeen.Task1
{
    /// <summary>
    /// Represents the functionalities to perform operations on external assemblies.
    /// </summary>
    public class ExternalAssemblyDemo
    {
        /// <summary>
        /// Loads the assembly.
        /// </summary>
        /// <returns>Assembly object.</returns>
        public Assembly LoadAssembly()
        {
            string pluginPath = Path.Combine(AppContext.BaseDirectory, "Plugin", "SampleProject.dll");
            return Assembly.LoadFrom(pluginPath);
        }

        /// <summary>
        /// Inspects the types and the displays the information related to it.
        /// </summary>
        /// <param name="assembly">Assembly from where it displays its types.</param>
        public void InspectAssemblyTypes(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"=============== {type} ===============");
                Console.ResetColor();

                this.DisplayProperties(type);
                this.DisplayFields(type);
                this.DisplayMethods(type);
                this.DisplayEvents(type);
                Console.WriteLine();
            }
        }

        private void DisplayProperties(Type type)
        {
            PropertyInfo[] properties = type!.GetProperties();
            Console.WriteLine("Properties :");
            foreach (PropertyInfo property in properties)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(property);
                Console.ResetColor();
            }
        }

        private void DisplayFields(Type type)
        {
            // To get all the fields irrespective to the protection level and all other stuffs.
            FieldInfo[] fields = type!.GetFields(BindingFlags.Public |
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Instance |
                                                     BindingFlags.Static);

            Console.WriteLine("Fields :");
            foreach (FieldInfo field in fields)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(field);
                Console.ResetColor();
            }
        }

        private void DisplayMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            Console.WriteLine("Events :");
            foreach (MethodInfo method in methods)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(method);
                Console.ResetColor();
            }
        }

        private void DisplayEvents(Type type)
        {
            EventInfo[] events = type.GetEvents();
            Console.WriteLine("Events :");
            foreach (EventInfo e in events)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(e);
                Console.ResetColor();
            }
        }
    }
}
