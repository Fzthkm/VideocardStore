using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Магазин.Models
{
    public class context : DbContext
    {
        public DbSet<tovar> tovari { get; set; }
        public DbSet<zakaz> zakazi { get; set; }
        public DbSet<otziv> otzivi { get; set; }
        public context(DbContextOptions<context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
