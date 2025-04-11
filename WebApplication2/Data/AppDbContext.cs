using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rowery> Rowery { get; set; }
        public DbSet<Klienci> Klienci { get; set; }
        public DbSet<Wypozyczenia> Wypozyczenia { get; set; }

        // Konstruktor z DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wypozyczenia>()
                .HasOne(w => w.Klient);

            modelBuilder.Entity<Wypozyczenia>()
                .HasOne(w => w.Rower);
            
            modelBuilder.Entity<Wypozyczenia>()
                .Property(w => w.KosztWypozyczenia)
                
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Rowery>()
                .Property(w => w.Cena)
                .HasColumnType("decimal(10,2)");

            
        }
    }
}