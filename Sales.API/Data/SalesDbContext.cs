using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.API.Models;

namespace Sales.API.Data
{
    public class SalesDbContext: DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}