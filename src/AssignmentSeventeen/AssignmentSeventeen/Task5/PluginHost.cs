using System.Reflection;
using Contract;

namespace AssignmentSeventeen.Task5
{
    /// <summary>
    /// Represents the functionalities to manage plugins.
    /// </summary>
    public class PluginHost
    {
        /// <summary>
        /// Manages the plugins.
        /// </summary>
        public void ManagePlugins()
        {
            List<IPlugin> pluginList = new List<IPlugin>();
            string[] pluginFiles = Directory.GetFiles(@"..\..\..\..\Plugins", "*.dll");

            foreach (string pluginFile in pluginFiles)
            {
                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);

                Type[] types = pluginAssembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.IsClass && !type.IsInterface && type.GetInterfaces().Contains(typeof(IPlugin)))
                    {
                        Console.WriteLine($"Valid plugin found : {type.FullName}");
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type)!;
                        pluginList.Add(plugin);
                    }
                }
            }

            int i = 1;
            foreach (IPlugin plugin in pluginList)
            {
                Console.WriteLine($"{i}.{plugin.GetType().Name}");
            }

            Console.Write("Enter the Serial Number of the plugIn you need to choose : ");
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int choice) && choice > 0 && choice <= pluginList.Count)
            {
                IPlugin chosePlugin = pluginList[choice - 1];
                Console.Write("Enter the string to be encrypted : ");
                string message = Console.ReadLine() ?? string.Empty;
                string encryptedMessage = chosePlugin.Encryption(message);
                Console.WriteLine($"Encrypted message : {encryptedMessage}");
                string decryptedMessage = chosePlugin.Decryption(encryptedMessage);
                Console.WriteLine($"Decrypted message : {decryptedMessage}");
                return;
            }

            Console.WriteLine("Invalid choice !!");
        }
    }
}
