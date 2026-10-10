namespace SampleProject
{
    /// <summary>
    /// Represents the students marks.
    /// </summary>
    public class StudentMarks
    {
        /// <summary>
        /// Gets or sets the English mark.
        /// </summary>
        /// <value>Marks scored in English.</value>
        public double EnglishMark { get; set; }

        /// <summary>
        /// Gets or sets the Math mark.
        /// </summary>
        /// <value>Marks scored in math.</value>
        public double MathMark { get; set; }

        /// <summary>
        /// Gets or sets the Science mark.
        /// </summary>
        /// <value>Marks scored in science.</value>
        public double ScienceMark { get; set; }

        /// <summary>
        /// Displays the Students the Marks.
        /// </summary>
        public void DisplayMarks()
        {
            Console.WriteLine($"English Mark : {this.EnglishMark}" +
                              $"\nMaths Mark : {this.MathMark}" +
                              $"\nScience Mark : {this.ScienceMark}");
        }
    }
}
