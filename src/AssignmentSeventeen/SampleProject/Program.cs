using SampleProject;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Default arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("This is just a sample project for generating and using the Dll");
            string userName = "Akilan";

            User user1 = new User(userName);
            user1.DisplayUserDetails();
        }
    }
}