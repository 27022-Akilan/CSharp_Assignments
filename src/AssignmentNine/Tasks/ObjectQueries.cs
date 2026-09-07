namespace AssignmentNine.Tasks
{
    /// <summary>
    /// Represents the task three.
    /// </summary>
    public class ObjectQueries
    {
        /// <summary>
        /// Perform operation on arrays.
        /// </summary>
        public void PerformArrayOperations()
        {
            ConsoleHelper.DisplayInfoMessage("\n===============================" +
                                             "\n   --- Object Queries ---" +
                                             "\n===============================");
            int[] array = { 10, 27, 1, 9, 56, 299, 78, 2, 8, 2 };

            Console.WriteLine($"\nArray: [{string.Join(", ", array)}]");
            int? number = array.Distinct().OrderByDescending(a => a).Skip(1).Cast<int?>().FirstOrDefault();
            if (number == null)
            {
                Console.WriteLine("No distinct second largest number found");
            }
            else
            {
                Console.WriteLine($"\nThe Second largest number is : {number}");
            }

            int target = 10;
            Console.WriteLine();
            var pairs = array.SelectMany(
                (x, i) => array.Skip(i + 1)
                              .Where(y => y + x == target)
                              .Select(y => (x, y))).Distinct();

            if (!pairs.Any())
            {
                Console.WriteLine($"No unique pairs found for the target {target}");
                ConsoleHelper.Clean();
                return;
            }

            Console.WriteLine($"\nThe  Unique pairs that match to the target {target} is :" +
                              "\n===================");
            foreach ((int x, int y) in pairs)
            {
                Console.WriteLine($"{x} - {y}");
            }

            Console.WriteLine("===================");
            ConsoleHelper.Clean();
        }
    }
}
