namespace AssignmentSixteen.Task7
{
    /// <summary>
    /// Represents the Triangle properties.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="name">Name of the Tri</param>
        /// <param name="baseLength">Base length of the triangle</param>
        /// <param name="height">Height of the triangle.</param>
        public Triangle(string name, decimal baseLength, decimal height)
            : base(name)
        {
            this.BaseLength = baseLength;
            this.Height = height;
        }

        /// <summary>
        /// Gets the base length.
        /// </summary>
        /// <value>Base Length of the triangle</value>
        public decimal BaseLength { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>Height of the triangle</value>
        public decimal Height { get; }

        /// <summary>
        /// To calculate area of the circle.
        /// </summary>
        /// <returns>Decimal - Returns the area of the triangle</returns>
        public override decimal CalculateArea()
        {
            return 0.5m * this.BaseLength * this.Height;
        }
    }
}
