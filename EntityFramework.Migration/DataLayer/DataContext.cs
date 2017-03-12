using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entity;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasColumnType("DECIMAL").IsRequired();
            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany().HasForeignKey(c => c.CategotyId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
