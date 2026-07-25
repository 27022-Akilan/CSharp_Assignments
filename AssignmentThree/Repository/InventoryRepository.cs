using AssignmentThree.Model;

namespace AssignmentThree.Repository
{
    /// <summary>
    /// Its used to store and retrive data (In-Memory)
    /// </summary>
    public class InventoryRepository
    {
        /// <summary>
        /// List to store the Inventory 
        /// </summary>
        private List<InventoryModel> _inventory = new List<InventoryModel>();
    }
}
