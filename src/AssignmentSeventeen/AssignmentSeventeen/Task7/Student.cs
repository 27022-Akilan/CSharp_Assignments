namespace AssignmentSeventeen.Task7
{
    /// <summary>
    /// Represents the properties of the Student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the Id of the student.
        /// </summary>
        /// <value>Id of the student.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        /// <value>Name of the student.</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the CGPA of the student.
        /// </summary>
        /// <value>CGPA of the student.</value>
        public double CGPA { get; set; }

        /// <summary>
        /// Gets or sets the List of subjects.
        /// </summary>
        /// <value>List of subjects.</value>
        public List<string>? Subjects { get; set; }
    }
}
