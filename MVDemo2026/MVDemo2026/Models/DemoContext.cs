using Microsoft.EntityFrameworkCore;

namespace MVDemo2026.Models
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=CARLOS-ASPARRIN\\MSSQLSERVER2017;Database=UniversityDB_04;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer -> Invoices
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.Customers_CustomerID);

            // Invoice -> Details
            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Invoice)
                .WithMany()
                .HasForeignKey(d => d.Invoice_InvoiceID);

            // Product -> Details
            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.Product_ProductID);

            // Soft Delete - Global Query Filters
            modelBuilder.Entity<Customer>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Invoice>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Detail>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}