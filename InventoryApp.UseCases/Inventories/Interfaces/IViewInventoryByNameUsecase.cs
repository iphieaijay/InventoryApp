using InventoryApp.Core.Entities;

namespace InventoryApp.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByNameUsecase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}