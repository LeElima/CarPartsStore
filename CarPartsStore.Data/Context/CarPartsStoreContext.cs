using CarPartsStore.Data.EntitiesConfiguration;
using CarPartsStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.Data.Context
{
    public class CarPartsStoreContext : DbContext
    {
        public CarPartsStoreContext(DbContextOptions<CarPartsStoreContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarPartsStoreContext).Assembly);
        }
    }
    
}
