using System;
using Xunit;
using Autofac.Extras.Moq;
using Popip.Model.Repositories;
using Popip.Model;
using Popip.Model.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using Popip.Service.Items;
using Moq;
using AutoMapper;
using FluentValidation;
using Popip.Infrastructure.Dtos;

namespace Popip.Tests.Services.Items
{
    public class GetAllShould
    {
        public GetAllShould()
        {
        }

        [Fact]
        public void NotReturnNull()
        {
            var mockRepository = new Mock<IItemRepository>();
            var result = mockRepository.Object.GetById(1);
            Assert.Null(result);
        }

        [Fact]
        public void SomeTest()
        {
            var context = new Mock<DbContext>();
            var mockRepository = new Mock<IItemRepository>();
            var result = mockRepository.Object.GetById(1);
            Assert.Null(result);
        }
    }
}
