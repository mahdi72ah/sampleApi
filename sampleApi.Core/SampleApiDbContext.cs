using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using sampleApi.Core.Entities;

namespace sampleApi.Core
{
    public class SampleApiDbContext:DbContext
    {
        public SampleApiDbContext(DbContextOptions<SampleApiDbContext> options):base(options)
        {
            
        }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Product> Product => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
