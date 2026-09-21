namespace AssignmentSixteen.Models.Shapes
{
    /// <summary>
    /// Represents rectangle properties.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="name">Name of the shape</param>
        /// <param name="length">Length of the rectangle</param>
        /// <param name="breadth">Breadth of the rectangle</param>
        public Rectangle(string name, decimal length, decimal breadth)
            : base(name)
        {
            Length = length;
            Breadth = breadth;
        }

        /// <summary>
        /// Gets the Length.
        /// </summary>
        /// <value>Length of the rectangle</value>
        public decimal Length { get; }

        /// <summary>
        /// Gets the Breadth
        /// </summary>
        /// <value>Breadth of the rectangle</value>
        public decimal Breadth { get; }

        /// <summary>
        /// To calculate area of the Rectangle
        /// </summary>
        /// <returns>Decimal - Returns the area of the Rectangle</returns>
        public override decimal CalculateArea()
        {
            return Length * Breadth;
        }

        /// <inheritdoc/>
        public override void DisplayDetails()
        {
            Console.WriteLine($"Shape name :{Name}" +
                              $"\nLength of the {Name} : {Length}" +
                              $"\nBreadth of the {Name} : {Breadth}" +
                              $"\nArea : {CalculateArea()}");
        }
    }
}
