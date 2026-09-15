namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// Represents a generic Shape with basic properties and methods.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class
        /// </summary>
        /// <param name="color">color of the shape</param>
        /// <param name="name">name of the shape</param>
        public Shape(string name, string color)
        {
            this.Color = color;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets color
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the color of the shape.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the Name of the shape.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Prints the details of the shape
        /// </summary>
        /// <returns>String - Holds the entire shape information</returns>
        public string PrintDetails()
        {
            return $"Shape : {this.Name} , Color : {this.Color} , Area : {this.GetArea()}";
        }

        /// <summary>
        /// Abstract method for calculating area
        /// </summary>
        /// <returns>Decimal - Area of the Shape</returns>
        public abstract decimal GetArea();
    }
}
