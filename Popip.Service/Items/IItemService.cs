using System.Collections.Generic;
using Popip.Infrastructure.Dtos;
using Popip.Core;

namespace Popip.Service.Items
{
    public interface IItemService
    {
        IEnumerable<ItemDto> GetAll();
        ItemDto GetById(int id);
        IEntityValidatorResult<ItemDto> Create(ItemDto itemDto);
        IEntityValidatorResult<ItemDto> Update(int id, ItemDto itemDto);
        IEntityValidatorResult<ItemDto> Delete(int id);
    }
}
