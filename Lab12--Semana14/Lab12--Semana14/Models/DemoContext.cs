using Microsoft.EntityFrameworkCore;

namespace Lab12__Semana14.Models
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=CARLOS-ASPARRIN\\MSSQLSERVER2017;Database=Lab12_CursosDB;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public DbSet<Instructor> Instructores { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Instructor>().HasKey(i => i.IdInstructor);
            modelBuilder.Entity<Estudiante>().HasKey(e => e.IdEstudiante);
            modelBuilder.Entity<Curso>().HasKey(c => c.IdCurso);
            modelBuilder.Entity<Matricula>().HasKey(m => m.IdMatricula);
            modelBuilder.Entity<Pago>().HasKey(p => p.IdPago);

            // Instructor -> Cursos
            modelBuilder.Entity<Curso>()
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(c => c.IdInstructor);

            // Estudiante -> Matriculas
            modelBuilder.Entity<Matricula>()
                .HasOne<Estudiante>()
                .WithMany()
                .HasForeignKey(m => m.IdEstudiante);

            // Curso -> Matriculas
            modelBuilder.Entity<Matricula>()
                .HasOne<Curso>()
                .WithMany()
                .HasForeignKey(m => m.IdCurso);

            // Matricula -> Pagos
            modelBuilder.Entity<Pago>()
                .HasOne<Matricula>()
                .WithMany()
                .HasForeignKey(p => p.IdMatricula);

            // Soft Delete - Global Query Filters
            modelBuilder.Entity<Instructor>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Estudiante>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Curso>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Matricula>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Pago>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
