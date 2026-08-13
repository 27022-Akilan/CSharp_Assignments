namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// Represents Circle with additional properties and methods and also derived from the Shape
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of the circle</param>
        /// <param name="radius">Radius of the Circle</param>
        /// <param name="name">Name of the Shape</param>
        public Circle(string name, string color, decimal radius)
            : base(name, color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets Radius
        /// </summary>
        /// <value>
        /// A <see cref="decimal"/> containing the radius of the circle.
        /// </value>
        public decimal Radius { get; set; }

        /// <summary>
        /// To calculate area of the circle
        /// </summary>
        /// <returns>Decimal - Returns the area of the circle</returns>
        public override decimal GetArea()
        {
            return (decimal)Math.PI * this.Radius * this.Radius;
        }
    }
}
