using AssignmentTwo.Model.Shapes;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// This is a shape service
    /// </summary>
    public class ShapeService
    {
        /// <summary>
        /// To add the shapes
        /// </summary>
        /// <param name="shape">Shape object</param>
        /// <returns>string</returns>
        public string GetDetails(Shape shape)
        {
            return shape.PrintDetails();
        }
    }
}
