using System;
using Autofac.Extras.Moq;
using Moq;
using Popip.Infrastructure.Dtos;
using Popip.Model.Entities;
using Popip.Service.Items;
using Xunit;
using Xunit.Abstractions;

namespace Popip.Tests.Services.Items
{
    public class CreateShould
    {
        private ITestOutputHelper _output;
        public CreateShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Create Tests Initialized");
        }

        [Fact]
        public void PostItemSuccessfully()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var item = new ItemDto
                {
                    Name = "Vaso",
                    Description = "Con agua"
                };

                mock.Mock<IItemService>()
                    .Setup(x => x.Create(item));

                var cls = mock.Create<ItemService>();
                cls.Create(item);

                mock.Mock<IItemService>()
                    .Verify(x => x.Create(item), Times.Exactly(1), "Here's the bobop");
            }
        }
    }
}
