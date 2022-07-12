using Microsoft.EntityFrameworkCore;

namespace CinemasAPI.Entities
{
    public class CinemaDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\sqlexpress;Database=CinemaAPI;Trusted_Connection=True";
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addreses { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Cinema>()
                .Property(c => c.IsOpen)
                .IsRequired();

            modelBuilder.Entity<Cinema>()
                .Property(c => c.ContactEmail)
                .IsRequired();

            modelBuilder.Entity<Cinema>()
                .Property(c => c.ContactNumber)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Film>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Film>()
                .Property(f => f.Description)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Film>()
                .Property(f => f.Minutes)
                .IsRequired();

            modelBuilder.Entity<Film>()
                .Property(f => f.Price)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
