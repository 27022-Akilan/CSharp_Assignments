namespace AssignmentSixteen.Task7
{
    /// <summary>
    /// Represents Circle properties.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius of the Circle</param>
        /// <param name="name">Name of the Shape</param>
        public Circle(string name, decimal radius)
            : base(name)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets the Radius.
        /// </summary>
        /// <value>Radius of the Circle</value>
        public decimal Radius { get; }

        /// <summary>
        /// To calculate area of the circle.
        /// </summary>
        /// <returns>Decimal - Returns the area of the circle</returns>
        public override decimal CalculateArea()
        {
            return (decimal)Math.PI * this.Radius * this.Radius;
        }
    }
}
