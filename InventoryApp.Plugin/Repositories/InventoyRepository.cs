using InventoryApp.Core.Entities;
using InventoryApp.UseCases.Interfaces;

namespace InventoryApp.Plugin.Repositories
{
    public class InventoyRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoyRepository()
        {
            _inventories = new List<Inventory>
            {
                new Inventory { Id = Guid.NewGuid(), Name = "Laptop", Quantity = 10, Price = 999.99 },
                new Inventory { Id = Guid.NewGuid(), Name = "Mouse", Quantity = 50, Price = 19.99 },
                new Inventory { Id = Guid.NewGuid(), Name = "Keyboard", Quantity = 30, Price = 49.99 },
                new Inventory { Id = Guid.NewGuid(), Name = "Monitor", Quantity = 20, Price = 199.99 }
            };
        }
        public Task<IEnumerable<Inventory>> GetByNameAsync(string name)
        {
           if(!string.IsNullOrEmpty(name)) 
                return Task.FromResult(_inventories.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase)));
           return Task.FromResult<IEnumerable<Inventory>>(_inventories);
        }
    }
}
