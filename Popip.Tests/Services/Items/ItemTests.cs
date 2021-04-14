using System;
using AutoMapper;
using FluentValidation;
using Moq;
using Popip.Infrastructure.Dtos;
using Popip.Infrastructure.Mappers;
using Popip.Infrastructure.Validators;
using Popip.Model.Repositories;
using Popip.Service.Items;
using Xunit;

namespace Popip.Tests.Services.Items
{
    public class ItemTests
    {
        private Mock<IItemRepository> itemRepositoryMock;
        public ItemTests()
        {
            itemRepositoryMock = new Mock<IItemRepository>();
        }

        [Fact]
        public void ReturnAnEnumerableWhenCallingGetAll()
        {
            var myProfile = new PopipProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            IValidator<ItemDto> validator = new ItemValidator();
            var serv = new ItemService(itemRepositoryMock.Object, mapper, validator);

            var elements = serv.GetAll();
            Assert.NotNull(elements);
        }
    }
}
