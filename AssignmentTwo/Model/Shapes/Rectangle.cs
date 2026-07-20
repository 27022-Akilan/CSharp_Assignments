namespace AssignmentTwo.Model.Shapes
{
    /// <summary>
    /// This is a Rectangle class inherits Shape
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">color</param>
        /// <param name="l">len</param>
        /// <param name="b">breadth</param>
        /// <param name="name">name</param>
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
        /// A <see cref="decimal"/> containing the radius of the circle.
        /// </value>
        public decimal Length { get; set; }

        /// <summary>
        /// Gets or sets Breadth
        /// </summary>
        /// <value>
        /// A <see cref="decimal"/> containing the radius of the circle.
        /// </value>
        public decimal Breadth { get; set; }

        /// <summary>
        /// THis is for calculating area
        /// </summary>
        /// <returns>decimal</returns>
        public override decimal GetArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
