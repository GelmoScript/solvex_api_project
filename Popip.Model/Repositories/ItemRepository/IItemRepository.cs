using System.Collections.Generic;
using Popip.Model.Entities;

namespace Popip.Model.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item Create(Item item);
        Item GetById(int id);
        Item Update(Item item);
        Item Delete(int id);
    }
}
