using System;
using Microsoft.EntityFrameworkCore;
using Popip.Model.Entities;

namespace Popip.Model
{
    public class PopipContext : DbContext
{
        public DbSet<Item> Items { get; set; }

        public PopipContext(DbContextOptions<PopipContext> options)
            : base(options)
        {
        }
    }
}
