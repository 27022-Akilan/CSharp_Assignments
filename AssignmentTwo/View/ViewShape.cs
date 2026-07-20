using AssignmentTwo.Model.Shapes;
using AssignmentTwo.Service;

namespace AssignmentTwo.View
{
    /// <summary>
    /// this is the view page
    /// </summary>
    internal class ViewShape
    {
        private ShapeService _sserve = new ShapeService();

        /// <summary>
        /// Entry point into service
        /// </summary>
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Create and view Circle \n2.Create and View Rectangle \n3.Exit \nEnter Your Choice ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        // Circle
                        case 1:
                            string? color = GetColor();
                            Console.WriteLine("Enter the radius");
                            string? r = Console.ReadLine() ?? string.Empty;
                            if (Helper.IsNumber(r, out decimal number))
                            {
                                Console.WriteLine(this._sserve.GetArea(new Circle("circle", color, number)));
                            }
                            else
                            {
                                Console.WriteLine("Enter valid number");
                            }

                            break;

                        // Rectangle
                        case 2:
                            color = GetColor();
                            Console.WriteLine("Enter the Length");
                            string? length = Console.ReadLine() ?? string.Empty;
                            Console.WriteLine("Enter the Breadth");
                            string? breadth = Console.ReadLine() ?? string.Empty;
                            if (Helper.IsNumber(length, out decimal resultLength) && Helper.IsNumber(breadth, out decimal resultBreadth))
                            {
                                Console.WriteLine(this._sserve.GetArea(new Rectangle("Rectangle", color, resultLength, resultBreadth)));
                            }
                            else
                            {
                                Console.WriteLine("Enter valid  Length and Breadth");
                            }

                            break;
                        case 3:
                            Console.WriteLine("Exiting!!!!");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
            }
            while (choice != 3);
        }

        private static string GetColor()
        {
            string color;
            do
            {
                Console.WriteLine("Enter the color");
                color = Console.ReadLine() ?? string.Empty;
                if (Helper.IsValidWord(color))
                {
                    return color;
                }

                Console.WriteLine("Invalid Color");
            }
            while (true);
        }
    }
}
