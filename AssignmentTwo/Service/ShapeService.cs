using AssignmentTwo.Model.Shapes;

namespace AssignmentTwo.Service
{
    /// <summary>
    /// This is a shape service
    /// </summary>
    public class ShapeService
    {
        /// <summary>
        /// this is the method to add the shapes
        /// </summary>
        /// <param name="shape">shape obj</param>
        /// <returns>string</returns>
        public string GetDetails(Shape shape)
        {
            return shape.PrintDetails();
        }
    }
}
