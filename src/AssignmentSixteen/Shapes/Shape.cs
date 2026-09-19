namespace AssignmentSixteen.Task7
{
    /// <summary>
    /// Represents a generic Shape with basic properties and methods.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="name">Name of the shape</param>
        public Shape(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of the Shape
        /// </summary>
        /// <value>Name of the shape</value>
        public string? Name { get; }

        /// <summary>
        /// Calculates area of the particular shape.
        /// </summary>
        /// <returns>decimal</returns>
        public abstract decimal CalculateArea();
    }
}
