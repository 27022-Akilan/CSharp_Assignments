namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// Abstract class for Shape
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class
        /// </summary>
        /// <param name="color">color</param>
        /// <param name="name">naem</param>
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
        /// <returns>string</returns>
        public string PrintDetails()
        {
            return $"Shape : {this.Name} , color : {this.Color} , area : {this.GetArea()}";
        }

        /// <summary>
        /// this is a abstract method for calculate area
        /// </summary>
        /// <returns>long</returns>
        public abstract decimal GetArea();
    }
}
