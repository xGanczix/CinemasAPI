using Microsoft.EntityFrameworkCore;

namespace CinemasAPI.Entities
{
    public class CinemaDbContext : DbContext
    {
        private string _connectionString = "Server=localhost\\sqlexpress;Database=CinemaAPI;Trusted_Connection=True";
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addreses { get; set; }
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
