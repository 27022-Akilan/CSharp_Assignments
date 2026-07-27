namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// This is a circle class inherits Shape
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">color</param>
        /// <param name="radius">radius</param>
        /// <param name="name">shape</param>
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
        /// This is for calculating area
        /// </summary>
        /// <returns>decimal</returns>
        public override decimal GetArea()
        {
            return (decimal)Math.PI * this.Radius * this.Radius;
        }
    }
}
