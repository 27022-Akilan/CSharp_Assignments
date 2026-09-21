using AssignmentSixteen.Helper;
using AssignmentSixteen.Models.Shapes;

namespace AssignmentSixteen.Task7
{
    /// <summary>
    /// Represents the operations performed on the shapes.
    /// </summary>
    public class ShapeManager
    {
        /// <summary>
        /// Performs operations on the list of shapes.
        /// </summary>
        public void ManageShape()
        {
            Console.WriteLine("=====Task 7=====");
            List<Shape> shapes = new List<Shape>();
            Shape rectangle = new Rectangle("Rectangle", 5, 4);
            Shape circle = new Circle("Circle", 5);
            Shape triangle = new Triangle("Triangle", 3, 7);
            shapes.Add(rectangle);
            shapes.Add(circle);
            shapes.Add(triangle);

            foreach (Shape shape in shapes)
            {
                DisplayShapeDetails(shape);
            }

            ConsoleHelper.WaitAndClear();
        }

        private static void DisplayShapeDetails(Shape shape)
        {
            shape.DisplayDetails();
        }
    }
}
