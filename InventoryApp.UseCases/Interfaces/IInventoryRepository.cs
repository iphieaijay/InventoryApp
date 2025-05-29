using InventoryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.UseCases.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetByNameAsync(string name);
        //Task<Inventory> GetByIdAsync(Guid id);
        //Task<IEnumerable<Inventory>> GetAllAsync();
        //Task AddAsync(Inventory inventory);
        //Task UpdateAsync(Inventory inventory);
        //Task DeleteAsync(Guid id);
    }
}
