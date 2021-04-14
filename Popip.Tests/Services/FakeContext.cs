using System;
using Microsoft.EntityFrameworkCore;
using Popip.Model;
using Popip.Model.Entities;

namespace Popip.Tests.Services
{
    public class FakeContext : PopipContext
    {
        public FakeContext(DbContextOptions<PopipContext> options)
            : base(options)
        {
            Items = new FakeItemSet()
            {
                new Item()
                {
                    Id = 1,
                    Name = "Vaso",
                    Description = "Con agua"
                },
                new Item()
                {
                    Id = 2,
                    Name = "Plato",
                    Description = "Ponme comida"
                },new Item()
                {
                    Id = 3,
                    Name = "Cuchara",
                    Description = "Soy bueno en la sopel"
                },new Item()
                {
                    Id = 4,
                    Name = "Cuchillo",
                    Description = "Soy bueno cortando"
                },new Item()
                {
                    Id = 5,
                    Name = "Tenedor",
                    Description = "Soy bueno pinchando"
                },
            };
        }
    }
}
