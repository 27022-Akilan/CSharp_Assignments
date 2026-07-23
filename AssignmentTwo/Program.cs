using AssignmentTwo;
using AssignmentTwo.View;

namespace Assignments
{
    /// <summary>
    /// THis is the basse prgrm entry point
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// THis is the entry point
        /// </summary>
        /// <param name="args">Default args</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("1.Shape \n2.Employee \n3.Account \nEnter Your Choice");
            string? ch = Console.ReadLine();

            if (int.TryParse(ch, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewShape viewShape = new ViewShape();
                        viewShape.Menu();
                        break;
                    case 2:
                        ViewEmployee viewEmployee = new ViewEmployee();
                        viewEmployee.Menu();
                        break;
                    case 3:
                        ViewAccounts viewAccount = new ViewAccounts();
                        viewAccount.Menu();
                        break;
                    case 4:
                        Console.WriteLine("Exiting!!");
                        break;
                    default:
                        Console.WriteLine("Enter valid number between 1 to 4");
                        break;
                }
            }
            else
            {
                Helper.WriteFailed("Enter a valid number , you didnt enter a number");
            }
        }
    }
}