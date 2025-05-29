using InventoryApp.Core.Entities;
using InventoryApp.UseCases.Interfaces;
using InventoryApp.UseCases.Inventories.Interfaces;
using System.Threading.Tasks;

namespace InventoryApp.UseCases.Inventories
{
    public class ViewInventoryByNameUsecase : IViewInventoryByNameUsecase
    {
        private readonly IInventoryRepository _inventoryRepo;
        public ViewInventoryByNameUsecase(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inventoryRepo.GetByNameAsync(name);
        }
    }
}
