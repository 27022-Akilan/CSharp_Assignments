using AssignmentTwo.Model.Shapes;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// this is the view page
    /// </summary>
    internal class ShapeView
    {
        private ShapeService _service = new ShapeService();

        /// <summary>
        /// Entry point into service
        /// </summary>
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n----------------------------------------------------" +
                    "\n1.Create and view Circle Details " +
                    "\n2.Create and View Rectangle Deatails " +
                    "\n3.Exit " +
                    "\n----------------------------------------------------" +
                    "\nEnter Your Choice ");

                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        // Circle
                        case 1:
                            string? color = GetColor();
                            if (color == "-1")
                            {
                                break;
                            }

                            decimal radius = Helper.GetValidQuantity("Radius");
                            if (radius == -1)
                            {
                                Helper.WriteFailed("Exiting");
                                break;
                            }

                            Shape shape = new Circle("Circle", color, radius);
                            Helper.WriteSuccess(this._service.GetDetails(shape));
                            break;

                        // Rectangle
                        case 2:
                            color = GetColor();
                            if (color == "-1")
                            {
                                break;
                            }

                            decimal isValidLength = Helper.GetValidQuantity("Length");
                            if (isValidLength == -1)
                            {
                                Helper.WriteFailed("Due to Out Of Trys , Exiting!");
                                break;
                            }

                            decimal isValidBreadth = Helper.GetValidQuantity("Breadth");
                            if (isValidBreadth == -1)
                            {
                                Helper.WriteFailed("Due to Out Of Trys , Exiting!");
                                break;
                            }

                            shape = new Rectangle("Rectangle", color, isValidLength, isValidBreadth);
                            Console.WriteLine(this._service.GetDetails(shape));
                            break;
                        case 3:
                            Helper.WriteSuccess("Exiting!!!!");
                            break;
                        default:
                            Helper.WriteFailed("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Helper.WriteFailed("Invalid Choice , You must enter a number only");
                }
            }
            while (choice != 3);
        }

        /// <summary>
        /// To get the Color
        /// </summary>
        /// <returns>returns valid color else -1 for out of trys</returns>
        private static string GetColor()
        {
            int trys = 3;
            string color;
            do
            {
                trys--;
                Console.WriteLine("Enter the color");
                color = Console.ReadLine() ?? string.Empty;
                if (Helper.IsValidWord(color))
                {
                    return color;
                }

                Helper.WriteWarning($"Invalid Color. No.Of trys left is {trys}");
            }
            while (trys != 0);
            return "-1";
        }
    }
}
