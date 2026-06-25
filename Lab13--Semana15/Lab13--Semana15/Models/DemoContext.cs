using Microsoft.EntityFrameworkCore;

namespace Lab13__Semana15.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }

        public DemoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=CARLOS-ASPARRIN\\MSSQLSERVER2017;Database=Lab13_Semana15;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Customer>().HasKey(c => c.IdCustomers);
            modelBuilder.Entity<Invoice>().HasKey(i => i.IdInvoices);
            modelBuilder.Entity<Product>().HasKey(p => p.IdProducts);
            modelBuilder.Entity<Detail>().HasKey(d => d.IdDetails);

            // Customer -> Invoices
            modelBuilder.Entity<Invoice>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(i => i.Customers_idCustomers);

            // Product -> Details
            modelBuilder.Entity<Detail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(d => d.Products_idProducts);

            // Invoice -> Details
            modelBuilder.Entity<Detail>()
                .HasOne<Invoice>()
                .WithMany()
                .HasForeignKey(d => d.Invoices_idInvoices);

            // Soft Delete - Global Query Filters
            modelBuilder.Entity<Customer>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Invoice>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Detail>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
