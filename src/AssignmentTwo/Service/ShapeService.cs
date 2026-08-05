using AssignmentTwo.Model.Shapes;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// This is a shape service
    /// </summary>
    public class ShapeService
    {
        /// <summary>
        /// To Get the entire details of the Shape
        /// </summary>
        /// <param name="shape">Shape object</param>
        /// <returns>String - Holds the entire information about the Shape</returns>
        public string GetDetails(Shape shape)
        {
            return shape.PrintDetails();
        }
    }
}
