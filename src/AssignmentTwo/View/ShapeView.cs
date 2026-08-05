using AssignmentTwo.Model.EnumModels;
using AssignmentTwo.Model.Shapes;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// Entry point to the view
    /// </summary>
    public class ShapeView
    {
        private ShapeService _service = new ShapeService();

        /// <summary>
        ///  To display the menu
        /// </summary>
        public void DisplayMenu()
        {
            ShapeOption shapeOption;
            int choice;
            do
            {
                Console.WriteLine(
                    "\n----------------------------------------------------" +
                    "\n1.Create and view Circle Details " +
                    "\n2.Create and View Rectangle Details " +
                    "\n3.Exit " +
                    "\n----------------------------------------------------" +
                    "\nEnter Your Choice ");

                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    shapeOption = (ShapeOption)choice;
                    switch (shapeOption)
                    {
                        // Circle
                        case ShapeOption.CreateAndViewCircle:
                            string? color = GetColor();
                            if (color == "-1")
                            {
                                break;
                            }

                            decimal radius = Helper.GetValidQuantity("Radius", "m");
                            if (radius == -1)
                            {
                                Helper.DisplayFailedMessage("Exiting");
                                break;
                            }

                            Shape shape = new Circle("Circle", color, radius);
                            Helper.DisplaySuccessMessage(this._service.GetDetails(shape));
                            break;

                        // Rectangle
                        case ShapeOption.CreateAndViewRectangle:
                            color = GetColor();
                            if (color == "-1")
                            {
                                break;
                            }

                            decimal isValidLength = Helper.GetValidQuantity("Length", "m");
                            if (isValidLength == -1)
                            {
                                Helper.DisplayFailedMessage("Due to Out Of Tries , Exiting!");
                                break;
                            }

                            decimal isValidBreadth = Helper.GetValidQuantity("Breadth", "m");
                            if (isValidBreadth == -1)
                            {
                                Helper.DisplayFailedMessage("Due to Out Of Tries , Exiting!");
                                break;
                            }

                            shape = new Rectangle("Rectangle", color, isValidLength, isValidBreadth);
                            Helper.DisplaySuccessMessage(this._service.GetDetails(shape));
                            break;
                        case ShapeOption.Exit:
                            Helper.DisplaySuccessMessage("Exiting!!!!");
                            break;
                        default:
                            Helper.DisplayFailedMessage("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Helper.DisplayFailedMessage("Invalid Choice , You must enter a number only");
                }
            }
            while (choice != 3);
        }

        /// <summary>
        /// To get the Color
        /// </summary>
        /// <returns>returns valid color else -1 for out of tries</returns>
        private static string GetColor()
        {
            int tries = 3;
            string color;
            do
            {
                tries--;
                Console.WriteLine("Enter the color");
                color = Console.ReadLine() ?? string.Empty;
                if (Helper.IsValidWord(color))
                {
                    return color;
                }

                Helper.DisplayWarningMessage($"Invalid Color. No.Of tries left is {tries}");
            }
            while (tries != 0);
            return "-1";
        }
    }
}
