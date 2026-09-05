using GarbageCollector.Model;

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
            Console.WriteLine($"The initial memory before object creation is : {GC.GetTotalMemory(false)}");
            List<Person>? people = new List<Person>();
            for (int i = 0; i < 1000000; i++)
            {
                people.Add(new Person());
            }

            Console.ReadKey();
            Console.WriteLine($"Generation of the List : {GC.GetGeneration(people)}");
            Console.WriteLine($"\nThe memory after object creation is : {GC.GetTotalMemory(false)}");
            people = null;
            Console.WriteLine("\nCollecting the garbage unreferenced objects ....");
            Console.ReadKey();
            GC.Collect();
            Console.WriteLine($"\nThe memory after object destruction is : {GC.GetTotalMemory(true)}");
            Console.WriteLine("\nCollected the unreferenced objects.");
        }
    }
}