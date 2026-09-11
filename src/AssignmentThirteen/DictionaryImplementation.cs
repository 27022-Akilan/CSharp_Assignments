namespace AssignmentThirteen
{
    /// <summary>
    /// Represents the student info (name - mark) in dictionary format.
    /// </summary>
    public class DictionaryImplementation
    {
        private Dictionary<string, int> _studentsMark = new Dictionary<string, int>();

        /// <summary>
        /// Performs operation like Add,Delete and remove student and their marks.
        /// </summary>
        public void PerformOperations()
        {
            Console.WriteLine("==================================================================" +
                              "\n     Representing student and their marks using Dictionary" +
                              "\n==================================================================");

            this.AddStudentMark("Kavin", 90);
            this.AddStudentMark("Akilan", 89);
            this.AddStudentMark("Alice", 77);
            this.DisplayStudentsMark();

            this.RemoveStudent("Jai");
            this.RemoveStudent("Alice");
            this.DisplayStudentsMark();
        }

        private void AddStudentMark(string studentName, int mark)
        {
            if (this._studentsMark.TryAdd(studentName, mark))
            {
                Console.WriteLine($"Student :{studentName} Mark : {mark} added successfully");
                return;
            }

            Console.WriteLine($"Student : {studentName} already exists so cannot be added.");
        }

        private void RemoveStudent(string studentName)
        {
            if (this._studentsMark.Remove(studentName))
            {
                Console.WriteLine($"\n{studentName} removed.");
                return;
            }

            Console.WriteLine($"\nStudent : {studentName} not found so cannot be deleted.");
        }

        private void DisplayStudentsMark()
        {
            Console.WriteLine("\n\nThe marks of each student is :");
            foreach (var student in this._studentsMark)
            {
                Console.WriteLine($"Student name : {student.Key}  Mark : {student.Value}");
            }
        }
    }
}
