using System;
using Moq;
using Popip.Infrastructure.Dtos;
using Popip.Model.Entities;
using Popip.Model.Repositories;
using Xunit;

namespace Popip.Service.Items
{
    public class ItemServicesTests
    {
        private readonly ItemService _itemService;
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly ItemDto _defaultItemRequested;
        public ItemServicesTests()
        {
            _itemRepository = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemRepository.Object, null, null);
            _defaultItemRequested = new ItemDto
            {
                Name = "Algun nombre",
                Description = "Una descripcion decente"
            };
            Item itemToReturn = null;
            _itemRepository.Setup(x => x.Create(It.IsAny<Item>()))
                .Callback<Item>(item =>
                {
                    itemToReturn = item;
                })
                .Returns(() => itemToReturn);
        }

        [Fact]
        public void CreateShouldReturnValidResponseAndItemRequested()
        {
            var response = _itemService.Create(_defaultItemRequested);
            var itemDtoResponse = response.Entity;
            Assert.Equal(_defaultItemRequested.Name, itemDtoResponse.Name);
            Assert.Equal(_defaultItemRequested.Description, itemDtoResponse.Description);
            Assert.True(response.IsValid);
        }

        [Fact]
        public void CreateSouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _itemService.Create(null));
            Assert.Equal("itemDto", exception.ParamName);
        }

        [Fact]
        public void CreateShouldSaveItemRequested()
        {
            var response = _itemService.Create(_defaultItemRequested);
            var itemDtoResponse = response.Entity;

            _itemRepository.Verify(x => x.Create(It.IsAny<Item>()), Times.Once);
        }
    }
}
