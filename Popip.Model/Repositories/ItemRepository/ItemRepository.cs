using System;
using System.Collections.Generic;
using System.Linq;
using Popip.Model.Entities;

namespace Popip.Model.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public PopipContext _itemContext;
        public ItemRepository(PopipContext itemContext)
        {
            _itemContext = itemContext;
        }
        public Item Create(Item item)
        {
            var itemResult = _itemContext.Items.Add(item);
            _itemContext.SaveChanges();
            return itemResult.Entity;
        }

        public Item Delete(int id)
        {
            var itemToDelete = GetAll().FirstOrDefault(x => x.Id == id);
            itemToDelete.IsDeleted = true;
            itemToDelete.DetetedDate = DateTime.Now;
            _itemContext.SaveChanges();
            return itemToDelete;
        }

        public IEnumerable<Item> GetAll()
        {
            var items = _itemContext.Items.Where(x => !x.IsDeleted);
            return items;
        }

        public Item GetById(int id)
        {
            var item = GetAll().FirstOrDefault(x => x.Id == id);
            return item;
        }

        public Item Update(Item item)
        {
            item.UpdateDate = DateTime.Now;
            _itemContext.Items.Update(item);
            _itemContext.SaveChanges();
            return item;
        }
    }
}
