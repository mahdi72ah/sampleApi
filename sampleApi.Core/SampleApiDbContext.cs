using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using sampleApi.Core.Entities;
using sampleApi.Core.FluentApiConfigurations;

namespace sampleApi.Core
{
    public class SampleApiDbContext:DbContext
    {
        public SampleApiDbContext(DbContextOptions<SampleApiDbContext> options):base(options)
        {
            
        }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Users> Users => Set<Users>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
        }
    }
}
