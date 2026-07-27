namespace AssignmentThree.View
{
    /// <summary>
    /// Menu Page
    /// </summary>
    internal class InventoryView
    {
        /// <summary>
        /// Displays the menu and allows the user to navigate 
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("Inventoy App");
            do
            {
                Console.WriteLine("======================================================" +
               "\n1.Add Product" +
               "\n2.Edit Product" +
               "\n3.Delete Product" +
               "\n4.Search Product" +
               "\n5.Display Produt" +
               "\n======================================================");
            }
            while (true);

        }
    }
}
