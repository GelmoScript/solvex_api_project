using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Popip.Api.Users;
using Popip.Infrastructure.Dtos;
using Popip.Service.Items;

namespace Popip.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetById(id);
            if (item is null)
                return NotFound();

            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(ItemDto item)
        {
            var itemResult = _itemService.Create(item);
            if (!itemResult.IsValid)
                return BadRequest(itemResult.Errors);

            return Created("", itemResult.Entity);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ItemDto item)
        {
            var itemResult = _itemService.Update(id, item);
            if (!itemResult.IsValid)
                return BadRequest(itemResult.Errors);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itemResult = _itemService.Delete(id);
            if (!itemResult.IsValid)
                return BadRequest(itemResult.Errors);
            return Ok(itemResult.Entity);
        }
    }
}
