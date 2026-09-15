namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// Represents Rectangle with additional properties and methods and also derived from the Shape
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">Color of the Rectangle</param>
        /// <param name="l">Length of the rectangle</param>
        /// <param name="b">Breadth of the rectangle</param>
        /// <param name="name">Name of the shape</param>
        public Rectangle(string name, string color, decimal l, decimal b)
            : base(name, color)
        {
            this.Length = l;
            this.Breadth = b;
        }

        /// <summary>
        /// Gets or sets Length
        /// </summary>
        /// <value>
        /// A <see cref="decimal"/> containing the length of the rectangle.
        /// </value>
        public decimal Length { get; set; }

        /// <summary>
        /// Gets or sets Breadth
        /// </summary>
        /// <value>
        /// A <see cref="decimal"/> containing the breadth of the rectangle.
        /// </value>
        public decimal Breadth { get; set; }

        /// <summary>
        /// To calculate area of the Rectangle
        /// </summary>
        /// <returns>Decimal - Returns the area of the Rectangle</returns>
        public override decimal GetArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
