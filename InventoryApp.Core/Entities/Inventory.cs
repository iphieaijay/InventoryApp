namespace InventoryApp.Core.Entities
{
    public class Inventory : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
